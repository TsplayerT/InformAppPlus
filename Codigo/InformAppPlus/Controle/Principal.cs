using System.Threading.Tasks;
using Com.OneSignal;
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

            Navegacao = new NavigationPage(Constantes.Paginas[Constantes.TipoPagina.Menu]);
            MainPage = Navegacao;

            OneSignal.Current.StartInit(Constantes.AppId).EndInit();
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