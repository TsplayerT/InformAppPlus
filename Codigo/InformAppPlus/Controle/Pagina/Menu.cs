using System;
using InformAppPlus.Utilidade;

namespace InformAppPlus.Controle.Pagina
{
    public partial class Menu
    {
        public Menu()
        {
            InitializeComponent();
        }

        private async void BotaoCriarNotificacao_OnClicked(object sender, EventArgs e)
        {
            await Principal.MudarPagina(Constantes.TipoPagina.CriarNotificacoes);
        }

        private async void BotaoVerNotificacoes_OnClicked(object sender, EventArgs e)
        {
            await Principal.MudarPagina(Constantes.TipoPagina.VerNotificacoes);
        }
    }
}