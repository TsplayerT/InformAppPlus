using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using InformAppPlus.Modelo;
using InformAppPlus.Servico;
using InformAppPlus.Utilidade;
using Xamarin.Forms;

namespace InformAppPlus.Controle.Pagina
{
    public partial class VerNotificacoes
    {
        public static BindableProperty TokenCancelamentoProperty = BindableProperty.Create(nameof(TokenCancelamento), typeof(CancellationToken), typeof(VerNotificacoes), default(CancellationToken));
        public CancellationToken TokenCancelamento
        {
            get => (CancellationToken)GetValue(TokenCancelamentoProperty);
            set => SetValue(TokenCancelamentoProperty, value);
        }
        public static BindableProperty CarregandoProperty = BindableProperty.Create(nameof(Carregando), typeof(bool), typeof(VerNotificacoes), true);
        public bool Carregando
        {
            get => (bool)GetValue(CarregandoProperty);
            set => SetValue(CarregandoProperty, value);
        }
        public static BindableProperty ListaNotificacaoProperty = BindableProperty.Create(nameof(ListaNotificacao), typeof(ObservableCollection<Notificacao>), typeof(VerNotificacoes), new ObservableCollection<Notificacao>());
        public ObservableCollection<Notificacao> ListaNotificacao
        {
            get => (ObservableCollection<Notificacao>)GetValue(ListaNotificacaoProperty);
            set => SetValue(ListaNotificacaoProperty, value);
        }

        public VerNotificacoes()
        {
            InitializeComponent();

            Appearing += async delegate
            {
                TokenCancelamento = CancellationToken.None;

                var resultadoChamada = await Conexao.VerNotificacoesAsync(TokenCancelamento);

                if (resultadoChamada?.Item1.HttpStatusCodeSuccess() ?? false)
                {
                    Carregando = false;

                    ListaNotificacao = new ObservableCollection<Notificacao>(resultadoChamada.Item2?.Notificacoes ?? new List<Notificacao>());
                }
                else
                {
                    await Principal.Mensagem($"Não foi possível listar as notificações porque a requisição retornou: {resultadoChamada?.Item1.ValorTratado()}");
                }
            };

            Disappearing += delegate
            {
                TokenCancelamento = new CancellationToken(true);
            };

            BindingContext = this;
        }

    }
}