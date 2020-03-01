using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using InformAppPlus.Servico;
using InformAppPlus.Utilidade;
using Xamarin.Forms;

namespace InformAppPlus.Controle.Pagina
{
    public partial class CriarNotificacoes
    {
        public static BindableProperty PrioridadeProperty = BindableProperty.Create(nameof(Prioridade), typeof(bool), typeof(CriarNotificacoes), default(bool));
        public bool Prioridade
        {
            get => (bool)GetValue(PrioridadeProperty);
            set => SetValue(PrioridadeProperty, value);
        }
        public static BindableProperty TextoTituloProperty = BindableProperty.Create(nameof(TextoTitulo), typeof(string), typeof(CriarNotificacoes), string.Empty);
        public string TextoTitulo
        {
            get => (string)GetValue(TextoTituloProperty);
            set => SetValue(TextoTituloProperty, value);
        }
        public static BindableProperty TextoMensagemProperty = BindableProperty.Create(nameof(TextoMensagem), typeof(string), typeof(CriarNotificacoes), string.Empty);
        public string TextoMensagem
        {
            get => (string)GetValue(TextoMensagemProperty);
            set => SetValue(TextoMensagemProperty, value);
        }
        public static BindableProperty TextoEstadoAtualProperty = BindableProperty.Create(nameof(TextoEstadoAtual), typeof(string), typeof(CriarNotificacoes), string.Empty);
        public string TextoEstadoAtual
        {
            get => (string)GetValue(TextoEstadoAtualProperty);
            set => SetValue(TextoEstadoAtualProperty, value);
        }
        public static BindableProperty BotaoEnviarHabilitadoProperty = BindableProperty.Create(nameof(BotaoEnviarHabilitado), typeof(bool), typeof(CriarNotificacoes), true);
        public bool BotaoEnviarHabilitado
        {
            get => (bool)GetValue(BotaoEnviarHabilitadoProperty);
            set => SetValue(BotaoEnviarHabilitadoProperty, value);
        }
        public static BindableProperty ListaReportaItensProperty = BindableProperty.Create(nameof(ListaReportaItens), typeof(List<string>), typeof(CriarNotificacoes), new List<string>());
        public List<string> ListaReportaItens
        {
            get => (List<string>)GetValue(ListaReportaItensProperty);
            set => SetValue(ListaReportaItensProperty, value);
        }
        public static BindableProperty TemporizadorProperty = BindableProperty.Create(nameof(Temporizador), typeof(Timer), typeof(CriarNotificacoes), default(Timer));
        public Timer Temporizador
        {
            get => (Timer)GetValue(TemporizadorProperty);
            set => SetValue(TemporizadorProperty, value);
        }
        public static BindableProperty DataAgendadaProperty = BindableProperty.Create(nameof(DataAgendada), typeof(DateTime), typeof(CriarNotificacoes), default(DateTime));
        public DateTime DataAgendada
        {
            get => (DateTime)GetValue(DataAgendadaProperty);
            set => SetValue(DataAgendadaProperty, value);
        }
        public static BindableProperty HoraAgendadaProperty = BindableProperty.Create(nameof(HoraAgendada), typeof(TimeSpan), typeof(CriarNotificacoes), default(TimeSpan));
        public TimeSpan HoraAgendada
        {
            get => (TimeSpan)GetValue(HoraAgendadaProperty);
            set => SetValue(HoraAgendadaProperty, value);
        }
        public static BindableProperty EscolhedorHoraAbertoProperty = BindableProperty.Create(nameof(EscolhedorHoraAberto), typeof(bool), typeof(CriarNotificacoes), default(bool));
        public bool EscolhedorHoraAberto
        {
            get => (bool)GetValue(EscolhedorHoraAbertoProperty);
            set => SetValue(EscolhedorHoraAbertoProperty, value);
        }
        public static BindableProperty ImagemEscolhidaProperty = BindableProperty.Create(nameof(ImagemEscolhida), typeof(bool), typeof(CriarNotificacoes), default(bool));
        public bool ImagemEscolhida
        {
            get => (bool)GetValue(ImagemEscolhidaProperty);
            set => SetValue(ImagemEscolhidaProperty, value);
        }
        public static BindableProperty BotaoImagemHabilitadoProperty = BindableProperty.Create(nameof(BotaoImagemHabilitado), typeof(bool), typeof(CriarNotificacoes), true);
        public bool BotaoImagemHabilitado
        {
            get => (bool)GetValue(BotaoImagemHabilitadoProperty);
            set => SetValue(BotaoImagemHabilitadoProperty, value);
        }
        public static BindableProperty TextoBotaoImagemProperty = BindableProperty.Create(nameof(TextoBotaoImagem), typeof(string), typeof(CriarNotificacoes), Constantes.TextoBotaoEscolherImagem);
        public string TextoBotaoImagem
        {
            get => (string)GetValue(TextoBotaoImagemProperty);
            set => SetValue(TextoBotaoImagemProperty, value);
        }
        public static BindableProperty CorBotaoImagemProperty = BindableProperty.Create(nameof(CorBotaoImagem), typeof(Color), typeof(CriarNotificacoes), Constantes.CorBotaoSemImagem);
        public Color CorBotaoImagem
        {
            get => (Color)GetValue(CorBotaoImagemProperty);
            set => SetValue(CorBotaoImagemProperty, value);
        }
        public static BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(CriarNotificacoes), string.Empty);
        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);
        }
        public static BindableProperty ImagemProperty = BindableProperty.Create(nameof(Imagem), typeof(ImageSource), typeof(CriarNotificacoes), default(ImageSource), propertyChanged: ImagemPropertyChanged);
        public ImageSource Imagem
        {
            get => (ImageSource)GetValue(ImagemProperty);
            set => SetValue(ImagemProperty, value);
        }
        public static BindableProperty ImagemUrlProperty = BindableProperty.Create(nameof(ImagemUrl), typeof(string), typeof(CriarNotificacoes), string.Empty);
        public string ImagemUrl
        {
            get => (string)GetValue(ImagemUrlProperty);
            set => SetValue(ImagemUrlProperty, value);
        }
        public static BindableProperty CarregandoImagemProperty = BindableProperty.Create(nameof(CarregandoImagem), typeof(bool), typeof(CriarNotificacoes), default(bool), propertyChanged: CarregandoImagemPropertyChanged);
        public bool CarregandoImagem
        {
            get => (bool)GetValue(CarregandoImagemProperty);
            set => SetValue(CarregandoImagemProperty, value);
        }

        public CriarNotificacoes()
        {
            InitializeComponent();

            Appearing += delegate
            {
                var dataAtual = DateTime.Now.ToLocalTime();

                DataAgendada = dataAtual.Date;
                HoraAgendada = dataAtual.TimeOfDay;

                Temporizador = new Timer(estado =>
                {
                    var dataHoraLocal = DateTime.Now.ToLocalTime();
                    var horaAtualLocal = dataHoraLocal.TimeOfDay;
                    var dataAtualLocal = dataHoraLocal.Date;

                    if (DataAgendada.Ticks < dataAtualLocal.Ticks)
                    {
                        DataAgendada = dataAtualLocal;
                    }
                    if (!EscolhedorHoraAberto && HoraAgendada.Ticks < horaAtualLocal.Ticks)
                    {
                        HoraAgendada = horaAtualLocal;
                    }
                }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            };

            Disappearing += delegate
            {
                Temporizador.Dispose();
            };

            BindingContext = this;
        }

        public enum TipoEntrada
        {
            Nenhum,
            Titulo,
            Mensagem
        }

        public Dictionary<TipoEntrada, bool> CamposInvalidos() => new Dictionary<TipoEntrada, bool>
        {
            { TipoEntrada.Titulo, TextoTitulo.Any() },
            { TipoEntrada.Mensagem, TextoMensagem.Any() }
        };

        public string MensagemCamposInvalidos(Dictionary<TipoEntrada, bool> camposInvalidos)
        {
            if (camposInvalidos.All(x => x.Value))
            {
                return string.Empty;
            }
            if (camposInvalidos.Count(x => !x.Value) == 1)
            {
                return $"O campo {Convert.ToString(camposInvalidos.First().Key)} está inválido!";
            }

            var mensagem = $"Os campos {camposInvalidos.Where(x => !x.Value).Select(x => Convert.ToString(x.Key)).Aggregate((p, s) => $"{p}, {s}")}";

            mensagem.ToArray()[mensagem.LastIndexOf(',')] = 'e';

            return $"{mensagem} estão inválidos!";
        }

        private void Hora_OnFocused(object sender, FocusEventArgs e)
        {
            EscolhedorHoraAberto = true;
        }

        private void Hora_OnUnfocused(object sender, FocusEventArgs e)
        {
            EscolhedorHoraAberto = false;
        }

        private async void Enviar_OnClicked(object sender, EventArgs e)
        {
            BotaoEnviarHabilitado = false;

            var parametro = new Requisicao
            {
                Titulo = new Dictionary<Requisicao.TipoLinguagem, string>
                {
                    { Requisicao.TipoLinguagem.Ingles, TextoTitulo }
                },
                Mensagem = new Dictionary<Requisicao.TipoLinguagem, string>
                {
                    { Requisicao.TipoLinguagem.Ingles, TextoMensagem }
                },
                Segmentos = new List<string>
                {
                    "All"
                },
                Url = Url
            };

            if (DataAgendada == default && HoraAgendada == default)
            {
                parametro.DataAgendada = DateTime.Now;
            }
            else if (DataAgendada == default && HoraAgendada != default)
            {
                parametro.DataAgendada = Convert.ToDateTime(DateTime.Now.Date.Add(HoraAgendada));
            }
            else if (DataAgendada != default && HoraAgendada == default)
            {
                parametro.DataAgendada = DataAgendada.Date.Add(DateTime.Now.TimeOfDay);
            }
            else
            {
                parametro.DataAgendada = DataAgendada.Date.Add(HoraAgendada);
            }
            if (Prioridade)
            {
                parametro.Prioridade = 10;
                parametro.CategoriaId = "c6d02774-ae2f-4047-b27d-e5271fd74150";
            }

            if (string.IsNullOrEmpty(ImagemUrl) && Imagem != null && !Imagem.IsEmpty)
            {
                ImagemUrl = await DefinirUrlImagem(Imagem);
            }
            parametro.UrlImagem = ImagemUrl;

            var resultadoNotificacao = await Conexao.CriarNotificacaoAsync(parametro);

            if (resultadoNotificacao?.Item1.HttpStatusCodeSuccess() ?? false)
            {
                var mensagem = resultadoNotificacao.Item2;

                if (!string.IsNullOrEmpty(mensagem))
                {
                    await Principal.Mensagem(mensagem);
                }
            }

            BotaoEnviarHabilitado = true;
        }

        private async Task<string> DefinirUrlImagem(ImageSource imagem) => await Device.InvokeOnMainThreadAsync(async () =>
        {
            if (imagem is FileImageSource source)
            {
                var bytes = File.ReadAllBytes(source.File);
                var base64 = Convert.ToBase64String(bytes);
                var base64Data = Regex.Match(base64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;

                if (string.IsNullOrEmpty(base64Data))
                {
                    base64Data = base64;
                }

                if (base64Data.IsBase64String() || Regex.IsMatch(base64Data, @"^(?:[A-Z0-9+\/]{4})*(?:[A-Z0-9+\/]{2}==|[A-Z0-9+\/]{3}=|[A-Z0-9+\/]{4})$"))
                {
                    var resultadoImagem = await Conexao.SubirImagemAsync(base64);

                    if (resultadoImagem?.Item1.HttpStatusCodeSuccess() ?? false)
                    {
                        return resultadoImagem.Item2;
                    }
                    await Principal.Mensagem($"Nãoi foi possível salvar a imagem por que a requisição retornou: {resultadoImagem?.Item1.ValorTratado()}");
                }
                else
                {
                    await Principal.Mensagem("Não foi possível converter a imagem em Base64 para salvar, por favor tente nnovamente com outra imagem!");
                }
            }

            return null;
        });

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Prioridade = !Prioridade;
        }

        private async void Hora_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is TimePicker objeto && EscolhedorHoraAberto && e.PropertyName.ToLower() == TimePicker.TimeProperty.PropertyName.ToLower())
            {
                var horaAtual = DateTime.Now.ToLocalTime().TimeOfDay;

                if (objeto.Time.Ticks < horaAtual.Ticks)
                {
                    await Principal.Mensagem("Não é possível agendar uma notiicação para o passado!");

                    //adição de 1 segundo para esse evento não entrar em Loop / conflito com o Temporizador
                    objeto.Time = horaAtual.Add(TimeSpan.FromSeconds(1));
                }
            }
        }

        private async void EscolherImagem_OnClicked(object sender, EventArgs e)
        {
            if (Imagem?.IsEmpty ?? true)
            {
                var listaOpcoes = new List<string>
                {
                    "Url",
                    "Tirar foto",
                    "Abrir galeria"
                };
                var opcao = await Principal.PopupRespostaFixa(string.Empty, listaOpcoes.ToArray());

                if (opcao == listaOpcoes[0])
                {
                    var url = await Principal.PopupRespostaDinamica("Digite a URL da imagem", "https://google.com.br");

                    if (string.IsNullOrEmpty(url))
                    {
                        return;
                    }
                    if (Regex.IsMatch(url, "(https?:)?//?[^'\" <>]+?\\.(jpg|jpeg|gif|png)"))
                    {
                        await Device.InvokeOnMainThreadAsync(async () =>
                        {
                            CarregandoImagem = true;

                            Imagem = ImageSource.FromUri(new Uri(url));

                            if (Imagem != null && !Imagem.IsEmpty)
                            {
                                ImagemUrl = url;
                            }
                            else
                            {
                                await Principal.Mensagem("Não foi possível carregar a imagem, por favor tente novamente ou use outra!");
                            }

                            CarregandoImagem = false;
                        });
                    }
                    else
                    {
                        await Principal.Mensagem("Não foi possível carregar essa imagem, por favor preencha com outro URL!");
                    }
                }
                else if (opcao == listaOpcoes[1] || opcao == listaOpcoes[2])
                {
                    var tipoAdicaoImagem = opcao == listaOpcoes[1] ? RepresentacaoVisual.TipoAdicaoImagem.TirarFoto : RepresentacaoVisual.TipoAdicaoImagem.AbrirGaleriaFoto;
                    var urlImagem = await RepresentacaoVisual.ImagemDispositivo(tipoAdicaoImagem, () => CarregandoImagem = true, () => CarregandoImagem = false);

                    if (!string.IsNullOrEmpty(urlImagem))
                    {
                        Imagem = urlImagem;
                    }
                }
            }
            else
            {
                var resposta = await Principal.Popup("Tem certeza que deseja remover a imagem?");

                if (resposta)
                {
                    Imagem = default;
                }
            }
        }

        private static void ImagemPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ImageSource imageSource = default;

            if (newvalue is ImageSource imagem)
            {
                imageSource = imagem;
            }

            if (bindable is CriarNotificacoes objeto)
            {
                var comImagem = !imageSource?.IsEmpty ?? false;

                objeto.ImagemEscolhida = comImagem;
                objeto.TextoBotaoImagem = comImagem ? Constantes.TextoBotaoRemoverImagem : Constantes.TextoBotaoEscolherImagem;
                objeto.CorBotaoImagem = comImagem ? Constantes.CorBotaoComImagem : Constantes.CorBotaoSemImagem;
            }
        }
        private static void CarregandoImagemPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is CriarNotificacoes objeto && newvalue is bool carregandoImagem)
            {
                objeto.BotaoEnviarHabilitado = !carregandoImagem;
                objeto.BotaoImagemHabilitado = !carregandoImagem;
            }
        }

    }
}
