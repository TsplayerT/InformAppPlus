using System.Threading.Tasks;

namespace InformAppPlus.Servico
{
    public interface IProcessamento
    {
        Task<byte[]> ComprimirImagem(byte[] bytes, double largura, double altura, int qualidade);
    }
}
