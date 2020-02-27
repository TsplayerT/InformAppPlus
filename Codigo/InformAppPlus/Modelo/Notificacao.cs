using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InformAppPlus.Modelo
{
    public class Notificacao
    {
        [JsonProperty("adm_big_picture")]
        public string AdministradorImagemGrande { get; set; }
        [JsonProperty("adm_group")]
        public string AdministradorGrupo { get; set; }
        [JsonProperty("adm_group_message")]
        public AdministradorGrupoMensagem AdministradorGrupoMensagem { get; set; }
        [JsonProperty("adm_large_icon")]
        public string AdministradorIconeGrande { get; set; }
        [JsonProperty("adm_small_icon")]
        public string AdministradorIconePequeno { get; set; }
        [JsonProperty("adm_sound")]
        public string AdministradorSom { get; set; }
        [JsonProperty("spoken_text")]
        public TextoFalado TextoFalado { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("alexa_ssml")]
        public object AlexaSsml { get; set; }
        [JsonProperty("alexa_display_title")]
        //ARRUMAR TIPO VARIÁVEL
        public object AlexaTituloExibicao { get; set; }
        [JsonProperty("amazon_background_data")]
        public bool? AmazonDadosFundo { get; set; }
        [JsonProperty("android_accent_color")]
        public string AndroidCorDestaque { get; set; }
        [JsonProperty("android_group")]
        public string AndroidGrupo { get; set; }
        [JsonProperty("android_group_message")]
        public AndroidGrupoMensagem AndroidGrupoMensagem { get; set; }
        [JsonProperty("android_led_color")]
        public string AndroidCorLed { get; set; }
        [JsonProperty("android_sound")]
        public string AndroidSom { get; set; }
        [JsonProperty("android_visibility")]
        public int? AndroidVisibilidade { get; set; }
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        [JsonProperty("big_picture")]
        public string ImageGrande { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("buttons")]
        public object Botoes { get; set; }
        [JsonProperty("canceled")]
        public bool? Cancelado { get; set; }
        [JsonProperty("chrome_big_picture")]
        public string ChromeImagemGrande { get; set; }
        [JsonProperty("chrome_icon")]
        public string ChromeIcone { get; set; }
        [JsonProperty("chrome_web_icon")]
        public string ChromeWebIcone { get; set; }
        [JsonProperty("chrome_web_image")]
        public string ChromeWebImagem { get; set; }
        [JsonProperty("chrome_web_badge")]
        public string ChromeWebCracha { get; set; }
        [JsonProperty("content_available")]
        public bool? ConteudoDisponivel { get; set; }
        [JsonProperty("contents")]
        public Mensagem Mensagem { get; set; }
        [JsonProperty("converted")]
        public int? Convertido { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("data")]
        public object Dados { get; set; }
        [JsonProperty("delayed_option")]
        public string OpcaoAtrasada { get; set; }
        [JsonProperty("delivery_time_of_day")]
        public string HoraEntrega { get; set; }
        [JsonProperty("errored")]
        public int? Erros { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("excluded_segments")]
        public List<object> SegmentosExcluidos { get; set; }
        [JsonProperty("failed")]
        public int? Falhas { get; set; }
        [JsonProperty("firefox_icon")]
        public string FirefoxIcone { get; set; }
        [JsonProperty("global_image")]
        public string ImagemGlobal { get; set; }
        [JsonProperty("headings")]
        public Titulo Titulo { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("include_player_ids")]
        public object DispositivosIncluidos { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("include_external_user_ids")]
        public object DispositivosExternosIncluidos { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("included_segments")]
        public List<object> SegmentosIncluidos { get; set; }
        [JsonProperty("thread_id")]
        public int? SegmentoId { get; set; }
        [JsonProperty("ios_badgeCount")]
        public int? IosQuantidadeCracha { get; set; }
        [JsonProperty("ios_badgeType")]
        public string IosTipoCracha { get; set; }
        [JsonProperty("ios_category")]
        public string IosCategoria { get; set; }
        [JsonProperty("ios_sound")]
        public string IosSom { get; set; }
        [JsonProperty("apns_alert")]
        public ApnsAlerta AlertaApns { get; set; }
        [JsonProperty("isAdm")]
        public bool? Administrador { get; set; }
        [JsonProperty("isAndroid")]
        public bool? Android { get; set; }
        [JsonProperty("isChrome")]
        public bool? Chrome { get; set; }
        [JsonProperty("isChromeWeb")]
        public bool? ChromeWeb { get; set; }
        [JsonProperty("isAlexa")]
        public bool? Alexa { get; set; }
        [JsonProperty("isFirefox")]
        public bool? Firefox { get; set; }
        [JsonProperty("isIos")]
        public bool? Ios { get; set; }
        [JsonProperty("isSafari")]
        public bool? Safari { get; set; }
        [JsonProperty("isWP")]
        public bool? Wp { get; set; }
        [JsonProperty("isWP_WNS")]
        public bool? WpWns { get; set; }
        [JsonProperty("isEdge")]
        public bool? Edge { get; set; }
        [JsonProperty("large_icon")]
        public string IconeGrande { get; set; }
        [JsonProperty("priority")]
        public int? Prioridade { get; set; }
        [JsonProperty("queued_at")]
        public double? PosicaoFila { get; set; }
        [JsonProperty("remaining")]
        public double? Restante { get; set; }
        [JsonProperty("send_after")]
        public double? Enviados { get; set; }
        [JsonIgnore]
        public DateTime DataHoraAgendado => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddHours(-3).AddSeconds(Enviados ?? 0);
        [JsonProperty("completed_at")]
        public double? Completos { get; set; }
        [JsonProperty("small_icon")]
        public string IconePequeno { get; set; }
        [JsonProperty("successful")]
        public int? Sucessos { get; set; }
        [JsonProperty("received")]
        public int? Recebidos { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("tags")]
        public object Etiquetas { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("filters")]
        public object Filtros { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("template_id")]
        public object ModeloId { get; set; }
        [JsonProperty("ttl")]
        public int? Ttl { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("web_url")]
        public object WebUrl { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("app_url")]
        public object AppUrl { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("web_buttons")]
        public object WebBotoes { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("web_push_topic")]
        public object WebTopicoEnvio { get; set; }
        [JsonProperty("wp_sound")]
        public string WpSom { get; set; }
        [JsonProperty("wp_wns_sound")]
        public string WpWnsSom { get; set; }
        [JsonProperty("platform_delivery_stats")]
        public EstatisticaEntregaPlataforma EstatisticaEntregaPlataforma { get; set; }
        //ARRUMAR TIPO VARIÁVEL
        [JsonProperty("ios_attachments")]
        public object IosAnexos { get; set; }
    }
    public class AdministradorGrupoMensagem
    {
        [JsonProperty("en")]
        public string Ingles { get; set; }
    }

    public class TextoFalado
    {
    }

    public class AndroidGrupoMensagem
    {
        [JsonProperty("en")]
        public string Ingles { get; set; }
    }

    public class Mensagem
    {
        [JsonProperty("en")]
        public string Ingles { get; set; }
    }

    public class Titulo
    {
        [JsonProperty("en")]
        public string Ingles { get; set; }
    }

    public class ApnsAlerta
    {
    }

    public class Android
    {
        [JsonProperty("successful")]
        public int? Sucessos { get; set; }
        [JsonProperty("failed")]
        public int? Falhas { get; set; }
        [JsonProperty("errored")]
        public int? Erros { get; set; }
    }

    public class EstatisticaEntregaPlataforma
    {
        [JsonProperty("android")]
        public Android Android { get; set; }
    }
}
