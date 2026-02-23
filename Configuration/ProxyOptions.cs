using System.ComponentModel;
using Emby.Web.GenericEdit;

namespace MediaInfoKeeper.Configuration
{
    public class ProxyOptions : EditableOptionsBase
    {
        public override string EditorTitle => "Proxy";

        [DisplayName("启用代理")]
        [Description("开启后所有 HttpClient 请求将走代理。")]
        public bool EnableProxyServer { get; set; } = false;

        [DisplayName("代理服务器地址")]
        [Description("示例：http://user:pass@127.0.0.1:7890 或 socks5://127.0.0.1:1080")]
        public string ProxyServerUrl { get; set; } = "http://127.0.0.1:7890";

        [DisplayName("忽略证书验证")]
        [Description("开启后忽略代理或远端证书错误。")]
        public bool IgnoreCertificateValidation { get; set; } = false;

        [DisplayName("写入环境变量")]
        [Description("同步写入 http_proxy/https_proxy/HTTP_PROXY/HTTPS_PROXY，便于 ffprobe 等外部进程访问需要代理的资源。")]
        public bool WriteProxyEnvVars { get; set; } = true;
        
        [DisplayName("启用压缩传输")]
        [Description("允许元数据服务器返回 gzip/deflate/br 压缩内容，并自动解压以减少网络流量。")]
        public bool EnableGzip { get; set; } = true;

        [DisplayName("使用替代 TMDB 配置")]
        [Description("开启后按域名重写 TMDB 请求：api.themoviedb.org / image.tmdb.org。")]
        public bool EnableAlternativeTmdb { get; set; } = false;

        [DisplayName("替代 TMDB API 地址")]
        [Description("默认替代地址为 https://api.tmdb.org，留空使用系统默认 https://api.themoviedb.org。")]
        public string AlternativeTmdbApiUrl { get; set; } = "https://api.tmdb.org";

        [DisplayName("替代 TMDB 图像地址")]
        [Description("请自备替代地址，留空使用系统默认 https://image.tmdb.org。")]
        public string AlternativeTmdbImageUrl { get; set; } = string.Empty;

        [DisplayName("替代 TMDB API 密钥")]
        [Description("请自备 API 密钥，留空使用系统默认。")]
        public string AlternativeTmdbApiKey { get; set; } = string.Empty;
    }
}
