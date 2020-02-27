using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InformAppPlus.Servico;
using Xamarin.Forms;

namespace InformAppPlus.Controle.Pagina
{
    public partial class CriarNotificacoes
    {
        public static BindableProperty PrioridadeProperty = BindableProperty.Create(nameof(Prioridade), typeof(int), typeof(CriarNotificacoes), default(int));
        public int Prioridade
        {
            get => (int)GetValue(PrioridadeProperty);
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
        public static BindableProperty BotaoSubtrairHabilitadoProperty = BindableProperty.Create(nameof(BotaoSubtrairHabilitado), typeof(bool), typeof(CriarNotificacoes), defaultValueCreator: BotaoSubtrairHabilitadoDefaultValueCreator);
        public bool BotaoSubtrairHabilitado
        {
            get => (bool)GetValue(BotaoSubtrairHabilitadoProperty);
            set => SetValue(BotaoSubtrairHabilitadoProperty, value);
        }
        public static BindableProperty BotaoSomarHabilitadoProperty = BindableProperty.Create(nameof(BotaoSomarHabilitado), typeof(bool), typeof(CriarNotificacoes), defaultValueCreator: BotaoSomarHabilitadoDefaultValueCreator);
        public bool BotaoSomarHabilitado
        {
            get => (bool)GetValue(BotaoSomarHabilitadoProperty);
            set => SetValue(BotaoSomarHabilitadoProperty, value);
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
                    var dataAtualLocalTemporario = DateTime.Now.ToLocalTime();
                    var horaAtualTemporario = dataAtualLocalTemporario.TimeOfDay;
                    var dataAtualTemporario = dataAtualLocalTemporario.Date;

                    if (DataAgendada.Ticks < dataAtualTemporario.Ticks)
                    {
                        DataAgendada = dataAtualTemporario;
                    }
                    if (HoraAgendada.Ticks < horaAtualTemporario.Ticks)
                    {
                        HoraAgendada = horaAtualTemporario;
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

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            BotaoEnviarHabilitado = false;

            var mensagem = await Conexao.CriarNotificacaoAsync(TextoTitulo, TextoMensagem, DataAgendada, HoraAgendada, Prioridade);

            if (!string.IsNullOrEmpty(mensagem))
            {
                await Principal.Mensagem(mensagem);
            }

            BotaoEnviarHabilitado = true;
        }

        private static object BotaoSubtrairHabilitadoDefaultValueCreator(BindableObject bindable)
        {
            if (bindable is CriarNotificacoes objeto)
            {
                return objeto.Prioridade > 0;
            }

            return true;
        }
        private static object BotaoSomarHabilitadoDefaultValueCreator(BindableObject bindable)
        {
            if (bindable is CriarNotificacoes objeto)
            {
                return objeto.Prioridade < 10;
            }

            return true;
        }

        private void BotaoSubtrair_OnClicked(object sender, EventArgs e)
        {
            Prioridade--;

            BotaoSubtrairHabilitado = Prioridade > 0;
            BotaoSomarHabilitado = Prioridade < 10;
        }
        private void BotaoSomar_OnClicked(object sender, EventArgs e)
        {
            Prioridade++;

            BotaoSubtrairHabilitado = Prioridade > 0;
            BotaoSomarHabilitado = Prioridade < 10;
        }

        private async void DataHora_OnUnfocused(object sender, FocusEventArgs e)
        {
            var dataAtualLocalTemporario = DateTime.Now.ToLocalTime();
            var horaAtualTemporario = dataAtualLocalTemporario.TimeOfDay;
            var dataAtualTemporario = dataAtualLocalTemporario.Date;

            if (HoraAgendada.Ticks < horaAtualTemporario.Ticks || DataAgendada.Ticks < dataAtualTemporario.Ticks)
            {
                await Principal.Mensagem("Não é possível agendar uma notiicação para o passado!");
            }

            if (DataAgendada.Ticks < dataAtualTemporario.Ticks)
            {
                DataAgendada = dataAtualTemporario;
            }
            if (HoraAgendada.Ticks < horaAtualTemporario.Ticks)
            {
                HoraAgendada = horaAtualTemporario;
            }
        }

        private async void Prioridade_OnUnfocused(object sender, FocusEventArgs e)
        {
            if (Prioridade < 0)
            {
                await Principal.Mensagem("Não é possível colocar um valor menor que zero!");

                Prioridade = 0;
            }
            else if (Prioridade > 10)
            {
                await Principal.Mensagem("Não é possível colocar um valor maior que dez!");

                Prioridade = 10;
            }
        }
    }
}
