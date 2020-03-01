using System.Collections.Generic;
using System.Reflection;
using InformAppPlus.Controle.Pagina;
using Xamarin.Forms;

namespace InformAppPlus.Utilidade
{
    public class Constantes
    {
        public static string AppId => "065fc6dd-75b5-4b07-84e6-98ad139aec9b";
        public static string RestApiId => "NmUwMmI4MGItYmQ1YS00ZjkyLWEyZDEtZjBlZWQ3MGVhNGUw";
        public static string ClientId => "82e55a7b69d639f";

        public static string TextoBotaoEscolherImagem => "Escolher Imagem";
        public static string TextoBotaoRemoverImagem => "Remover Imagem";
        
        public static Color CorBotaoSemImagem => Color.FromHex("#64fa64");
        public static Color CorBotaoComImagem => Color.FromHex("#fa6464");

        public static ImageSource LogoImagemSource => ImageSource.FromResource("InformAppPlus.Recurso.Imagem.logo.png", typeof(Constantes).GetTypeInfo().Assembly);

        public enum TipoPagina
        {
            Nenhum,
            Menu,
            VerNotificacoes,
            CriarNotificacoes
        }

        public static Dictionary<TipoPagina, Page> Paginas => new Dictionary<TipoPagina, Page>
        {
            { TipoPagina.Menu, new Controle.Pagina.Menu() },
            { TipoPagina.CriarNotificacoes, new CriarNotificacoes() },
            { TipoPagina.VerNotificacoes, new VerNotificacoes() }
        };

    }
}