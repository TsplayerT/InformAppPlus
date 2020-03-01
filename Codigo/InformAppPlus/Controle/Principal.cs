using System.Threading.Tasks;
using Com.OneSignal;
using InformAppPlus.Servico;
using InformAppPlus.Utilidade;
using Xamarin.Forms;

namespace InformAppPlus.Controle
{
    public partial class Principal
    {
        private static NavigationPage Navegacao { get; set; }

        public Principal()
        {
            InitializeComponent();

            Parallel.Invoke(() =>
            {
                Navegacao = new NavigationPage(Constantes.Paginas[Constantes.TipoPagina.Menu]);
                MainPage = Navegacao;
            }, () =>
            {
                OneSignal.Current.StartInit(Constantes.AppId).EndInit();
            }, DependencyService.Register<IProcessamento>);
        }

        public static async Task<bool> Mensagem(string titulo)
        {
            if (Current?.MainPage != null)
            {
                await Current.MainPage.DisplayAlert(string.Empty, titulo, "OK");

                return true;
            }

            return false;
        }

        public static async Task<bool> Popup(string mensagem, string positivo = "Sim", string negativo = "Não")
        {
            if (Current?.MainPage != null)
            {
                return await Current.MainPage.DisplayAlert(string.Empty, mensagem, positivo, negativo);
            }

            return false;
        }

        public static async Task<string> PopupRespostaFixa(string titulo, params string[] opcoes)
        {
            if (Current?.MainPage != null && (opcoes?.Length ?? 0) > 1)
            {
                return await Current.MainPage.DisplayActionSheet(titulo, null, null, opcoes);
            }

            return null;
        }

        public static async Task<string> PopupRespostaDinamica(string titulo, string marcaAgua = null)
        {
            if (Current?.MainPage != null)
            {
                return await Current.MainPage.DisplayPromptAsync(titulo, null, "OK", null, marcaAgua, -1, Keyboard.Url, null);
            }

            return null;
        }

        public static async Task<bool> MudarPagina(Constantes.TipoPagina tipoPagina)
        {
            if (Navegacao != null)
            {
                await Navegacao.PushAsync(Constantes.Paginas[tipoPagina], true);

                return true;
            }

            return false;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}