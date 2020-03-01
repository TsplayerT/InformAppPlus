using System.Collections.Generic;
using Newtonsoft.Json;

namespace InformAppPlus.Servico
{
    public class ImgurResposta
    {
        [JsonProperty("data")]
        public Dados Dados { get; set; }
        [JsonProperty("success")]
        public bool? Sucesso { get; set; }
        [JsonProperty("status")]
        public int? Status { get; set; }
    }

    public class Dados
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Titulo { get; set; }
        [JsonProperty("description")]
        public string Descricao { get; set; }
        [JsonProperty("datetime")]
        public int? DataHora { get; set; }
        [JsonProperty("type")]
        public string Tipo { get; set; }
        [JsonProperty("animated")]
        public bool? Animado { get; set; }
        [JsonProperty("width")]
        public int? Largura { get; set; }
        [JsonProperty("height")]
        public int? Altura { get; set; }
        [JsonProperty("size")]
        public int? Tamanho { get; set; }
        [JsonProperty("views")]
        public int? Visualizacoes { get; set; }
        [JsonProperty("bandwidth")]
        public int? LarguraBanda { get; set; }
        [JsonProperty("vote")]
        public int? Votos { get; set; }
        [JsonProperty("favorite")]
        public bool? Favorito { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("nsfw")]
        public object Nsfw { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("section")]
        public object Secao { get; set; }
        [JsonProperty("account_url")]
        public string UrlConta { get; set; }
        [JsonProperty("account_id")]
        public int? IdConta { get; set; }
        [JsonProperty("is_ad")]
        public bool? Anuncio { get; set; }
        [JsonProperty("in_most_viral_url")]
        public bool? MaisViral { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("tags")]
        public List<object> Etiquetas { get; set; }
        [JsonProperty("ad_type")]
        public int? TipoAnuncio { get; set; }
        [JsonProperty("ad_url")]
        public string UrlAnuncio { get; set; }
        [JsonProperty("in_gallery")]
        public bool? EstaGaleria { get; set; }
        [JsonProperty("deletehash")]
        public string HashApagar { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }

}
