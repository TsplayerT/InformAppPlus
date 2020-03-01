using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using InformAppPlus.Controle;
using InformAppPlus.Modelo;
using InformAppPlus.Utilidade;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace InformAppPlus.Servico
{
    public static class Conexao
    {
        private static HttpClient ClienteImagem { get; }
        private static HttpClient ClienteNotificacao { get; }
        public static string CaminhoConexaoImagem => "https://api.imgur.com/3/";
        public static string CaminhoConexaoNotificacao => "https://onesignal.com/api/v1/";

        static Conexao()
        {
            ClienteImagem = new HttpClient
            {
                BaseAddress = new Uri(CaminhoConexaoImagem)
            };
            ClienteNotificacao = new HttpClient
            {
                BaseAddress = new Uri(CaminhoConexaoNotificacao)
            };

            ClienteImagem.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-Id", Constantes.ClientId);
            ClienteNotificacao.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Constantes.RestApiId);
        }

        public static async Task<Tuple<HttpStatusCode, string>> CriarNotificacaoAsync(Requisicao parametro)
        {
            parametro.AppId = Constantes.AppId;

            var parametroJson = JsonConvert.SerializeObject(parametro);
            var parametroString = new StringContent(parametroJson, Encoding.UTF8, "application/json");

            try
            {
                var resposta = await ClienteNotificacao.PostAsync("notifications", parametroString).ConfigureAwait(false);
                var conteudo = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                return new Tuple<HttpStatusCode, string>(resposta.StatusCode, resposta.IsSuccessStatusCode ? conteudo : Requisicao.MensagemErroTratado(conteudo));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    await Principal.Mensagem(ex.Message);
                }
            }

            return default;
        }

        public static async Task<Tuple<HttpStatusCode, ListaNotificacao>> VerNotificacoesAsync(CancellationToken tokenCancelamento = default)
        {
            try
            {
                var resposta = await ClienteNotificacao.GetAsync($"notifications?app_id={Constantes.AppId}&limit={50}", tokenCancelamento).ConfigureAwait(false);
                var conteudo = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (resposta.IsSuccessStatusCode)
                {
                    return new Tuple<HttpStatusCode, ListaNotificacao>(resposta.StatusCode, JsonConvert.DeserializeObject<ListaNotificacao>(conteudo));
                }

                return new Tuple<HttpStatusCode, ListaNotificacao>(resposta.StatusCode, null);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    await Principal.Mensagem(ex.Message);
                }
            }

            return default;
        }

        public static async Task<Tuple<HttpStatusCode, string>> SubirImagemAsync(string base64, CancellationToken tokenCancelamento = default) => await Device.InvokeOnMainThreadAsync(async () => 
        {
            try
            {
                var regexConteudoHtml = new Regex(@"<[^>]*?>");
                var content = new StringContent(base64, Encoding.UTF8);
                var resposta = await ClienteImagem.PostAsync("upload", content, tokenCancelamento).ConfigureAwait(false);
                var conteudo = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (resposta.IsSuccessStatusCode)
                {
                    var resultado = JsonConvert.DeserializeObject<ImgurResposta>(conteudo);

                    return new Tuple<HttpStatusCode, string>(resposta.StatusCode, resultado?.Dados?.Link);
                }
                if (regexConteudoHtml.IsMatch(conteudo))
                {
                    var conteudoHtml = regexConteudoHtml.Replace(conteudo, string.Empty);

                    return new Tuple<HttpStatusCode, string>(resposta.StatusCode, conteudoHtml);
                }

                await Principal.Mensagem(Requisicao.MensagemErroTratado(conteudo));

                return new Tuple<HttpStatusCode, string>(resposta.StatusCode, null);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    await Principal.Mensagem(ex.Message);
                }
            }

            return default;
        });
    }
}
