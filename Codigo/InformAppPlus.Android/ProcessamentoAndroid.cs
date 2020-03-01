using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using InformAppPlus.Servico;

[assembly: Xamarin.Forms.Dependency(typeof(IProcessamento))]
namespace InformAppPlus.Droid
{
    public class ProcessamentoAndroid : IProcessamento
    {
        public async Task<byte[]> ComprimirImagem(byte[] bytes, double largura, double altura, int qualidade)
        {
            var imagemOriginal = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            var imagemRedimensionada = Bitmap.CreateScaledBitmap(imagemOriginal, (int)largura, (int)altura, false);

            await using var memoryStream = new MemoryStream();
            imagemRedimensionada.Compress(Bitmap.CompressFormat.Png, qualidade, memoryStream);

            return memoryStream.ToArray();
        }
    }
}