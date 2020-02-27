using System.Collections.Generic;
using Newtonsoft.Json;

namespace InformAppPlus.Modelo
{
    public class ListaNotificacao
    {
        [JsonProperty("total_count")]
        public int? Total { get; set; }
        [JsonProperty("offset")]
        public int? Deslocamento { get; set; }
        [JsonProperty("limit")]
        public int? Limite { get; set; }
        [JsonProperty("notifications")]
        public List<Notificacao> Notificacoes { get; set; }
    }
}
