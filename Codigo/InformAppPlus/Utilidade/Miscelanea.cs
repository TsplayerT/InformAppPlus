using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace InformAppPlus.Utilidade
{
    public static class Miscelanea
    {
        public static bool IsBase64String(this string base64)
        {
            var buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out _);
        }

        public static bool HttpStatusCodeSuccess(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.OK
                   || statusCode == HttpStatusCode.Created
                   || statusCode == HttpStatusCode.Accepted
                   || statusCode == HttpStatusCode.NonAuthoritativeInformation
                   || statusCode == HttpStatusCode.NoContent
                   || statusCode == HttpStatusCode.ResetContent
                   || statusCode == HttpStatusCode.PartialContent;
        }

        public static byte[] Compress(this byte[] data)
        {
            var output = new MemoryStream();

            using (var dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }

        public static TK Converter<T, TK>(this T valor)
        {
            try
            {
                return (TK)Convert.ChangeType(valor, typeof(TK));
            }
            catch
            {
                try
                {
                    return (TK)(object)valor;
                }
                catch
                {
                    return default;
                }
            }
        }

        public static string ValorTratado<T>(this T valor, string valorPadrao = null)
        {
            var valorConvertido = Converter<T, string>(valor);

            return string.IsNullOrEmpty(valorConvertido) ? string.IsNullOrEmpty(valorPadrao) ? "NULL" : valorPadrao : valorConvertido;
        }
    }
}
