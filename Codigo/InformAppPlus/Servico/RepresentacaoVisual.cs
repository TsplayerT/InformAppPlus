using System;
using System.Threading.Tasks;
using InformAppPlus.Controle;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace InformAppPlus.Servico
{
    public static class RepresentacaoVisual
    {
        public enum TipoAdicaoImagem
        {
            Nenhum,
            TirarFoto,
            AbrirGaleriaFoto
        }

        public static async Task<string> ImagemDispositivo(TipoAdicaoImagem tipoAdicaoImagem, Action acaoInicial = null, Action acaoFinal = null)
        {
            var mensagem = string.Empty;

            if (!CrossMedia.Current.IsCameraAvailable)
            {
                mensagem = "A câmera do seu dispositivo não está disponível.";
            }
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                mensagem = "Seu dispositivo não suporta captura de imagem.";
            }
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                mensagem = "Seu dispositivo não tem suporte para recuperação de imagem da galeria.";
            }

            if (!string.IsNullOrEmpty(mensagem))
            {
                await Principal.Mensagem(mensagem);

                return null;
            }
            if (tipoAdicaoImagem == TipoAdicaoImagem.Nenhum)
            {
                return null;
            }

            return await Device.InvokeOnMainThreadAsync(async () =>
            {
                MediaFile file = null;

                acaoInicial?.Invoke();

                switch (tipoAdicaoImagem)
                {
                    case TipoAdicaoImagem.TirarFoto:
                        file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true
                        });
                        break;
                    case TipoAdicaoImagem.AbrirGaleriaFoto:
                        file = await CrossMedia.Current.PickPhotoAsync();
                        break;
                }
                
                acaoFinal?.Invoke();

                return file?.Path;

            }).ConfigureAwait(false);
        }
    }
}
