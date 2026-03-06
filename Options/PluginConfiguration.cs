using System.ComponentModel;
using Emby.Web.GenericEdit;

namespace MediaInfoKeeper.Options
{
    public class PluginConfiguration : EditableOptionsBase
    {
        public override string EditorTitle => "MediaInfoKeeper";

        public override string EditorDescription => "将媒体信息与章节保存为 JSON，并在需要时从 JSON 恢复。";

        // Main page
        [DisplayName("MediaInfo Keeper")]
        public MainPageOptions MainPage { get; set; } = new MainPageOptions();

        // Tab pages (order follows MainPageController)
        [DisplayName("IntroSkip")]
        public IntroSkipOptions IntroSkip { get; set; } = new IntroSkipOptions();

        [DisplayName("Search")]
        public EnhanceChineseSearchOptions EnhanceChineseSearch { get; set; } = new EnhanceChineseSearchOptions();

        [DisplayName("MetaData")]
        public MetaDataOptions MetaData { get; set; } = new MetaDataOptions();

        [DisplayName("Proxy")]
        public ProxyOptions Proxy { get; set; } = new ProxyOptions();

        [DisplayName("GitHub")]
        public GitHubOptions GitHub { get; set; } = new GitHubOptions();
    }
}
