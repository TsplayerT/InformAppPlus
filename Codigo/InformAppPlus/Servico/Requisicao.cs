using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace InformAppPlus.Servico
{
    public class Requisicao
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        [JsonProperty("headings")]
        public Dictionary<TipoLinguagem, string> Titulo { get; set; }
        [JsonProperty("subtitle")]
        public Dictionary<TipoLinguagem, string> Subtitulo { get; set; }
        [JsonProperty("contents")]
        public Dictionary<TipoLinguagem, string> Mensagem { get; set; }
        [JsonProperty("included_segments")]
        public List<string> Segmentos { get; set; }
        [JsonProperty("priority")]
        public int? Prioridade { get; set; }
        [JsonProperty("send_after")]
        public DateTime? DataAgendada { get; set; }
        [JsonProperty("url")]
        public string Url{ get; set; }
        [JsonProperty("big_picture")]
        public string UrlImagem{ get; set; }
        [JsonProperty("android_channel_id")]
        public string CategoriaId { get; set; }

        public enum TipoLinguagem
        {
            [EnumMember(Value = "en")]
            Ingles,
            [EnumMember(Value = "pt")]
            Portugues
        }

        public static string MensagemErroTratado(string json) => JsonConvert.DeserializeObject<Falha>(json).Erros.Aggregate((p, s) => $"{p}, {s}");
    }
}