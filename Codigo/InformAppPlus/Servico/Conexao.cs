using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InformAppPlus.Controle;
using InformAppPlus.Modelo;
using InformAppPlus.Utilidade;
using Newtonsoft.Json;

namespace InformAppPlus.Servico
{
    public static class Conexao
    {
        private static HttpClient Cliente { get; }
        public static string CaminhoConexao => "https://onesignal.com/api/v1/";

        static Conexao()
        {
            Cliente = new HttpClient
            {
                BaseAddress = new Uri(CaminhoConexao)
            };

            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Constantes.RestApiId);
        }

        public static async Task<string> CriarNotificacaoAsync(string titulo, string mensagem, DateTime data = default, TimeSpan hora = default, int prioridade = default)
        {
            var parametro = new Requisicao
            {
                AppId = Constantes.AppId,
                Titulo = new Dictionary<Requisicao.TipoLinguagem, string>
                {
                    { Requisicao.TipoLinguagem.Ingles, titulo }
                },
                Subtitulo = new Dictionary<Requisicao.TipoLinguagem, string>
                {
                    { Requisicao.TipoLinguagem.Ingles, "subtexto" }
                },
                Mensagem = new Dictionary<Requisicao.TipoLinguagem, string>
                {
                    { Requisicao.TipoLinguagem.Ingles, mensagem }
                },
                Segmentos = new List<string>
                {
                    "All"
                }
            };

            if (data == default && hora == default)
            {
                parametro.DataAgendada = DateTime.Now;
            }
            else if (data == default && hora != default)
            {
                parametro.DataAgendada = Convert.ToDateTime(DateTime.Now.Date.Add(hora));
            }
            else if (data != default && hora == default)
            {
                parametro.DataAgendada = data.Date.Add(DateTime.Now.TimeOfDay);
            }
            else
            {
                parametro.DataAgendada = data.Date.Add(hora);
            }

            if (prioridade > 10)
            {
                parametro.Prioridade = 10;
            }
            else if (prioridade < 0)
            {
                parametro.Prioridade = 0;
            }
            else
            {
                parametro.Prioridade = prioridade;
            }

            var parametroJson = JsonConvert.SerializeObject(parametro);
            var parametroString = new StringContent(parametroJson, Encoding.UTF8, "application/json");

            try
            {
                var resposta = await Cliente.PostAsync("notifications", parametroString).ConfigureAwait(false);
                var conteudo = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                return resposta.IsSuccessStatusCode ? conteudo : Requisicao.MensagemErroTratado(conteudo);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    await Principal.Mensagem(ex.Message);
                }
            }

            return string.Empty;
        }

        public static async Task<ListaNotificacao> VerNotificacoesAsync(CancellationToken tokenCancelamento = default)
        {
            try
            {
                var resposta = await Cliente.GetAsync($"notifications?app_id={Constantes.AppId}&limit={50}", tokenCancelamento).ConfigureAwait(false);
                var conteudo = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (resposta.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ListaNotificacao>(conteudo);
                }

                await Principal.Mensagem(Requisicao.MensagemErroTratado(conteudo));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    await Principal.Mensagem(ex.Message);
                }
            }

            return new ListaNotificacao();
        }
    }
}
