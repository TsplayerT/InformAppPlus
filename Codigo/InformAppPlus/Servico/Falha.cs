using System.Collections.Generic;
using Newtonsoft.Json;

namespace InformAppPlus.Servico
{
    public class Falha
    {
        [JsonProperty("errors")]
        public List<string> Erros { get; set; }
        [JsonProperty("reference ")]
        public List<string> Referencias { get; set; }
    }
}