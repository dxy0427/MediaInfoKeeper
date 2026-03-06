using System;
using System.Collections.Generic;
using System.ComponentModel;
using Emby.Web.GenericEdit;
using Emby.Web.GenericEdit.Common;
using MediaBrowser.Model.Attributes;

namespace MediaInfoKeeper.Options
{
    public class EnhanceChineseSearchOptions : EditableOptionsBase
    {
        public override string EditorTitle => "Enhance Search";

        [DisplayName("启用增强搜索")]
        [Description("支持中文模糊搜索与拼音搜索，默认关闭。")]
        public bool EnhanceChineseSearch { get; set; } = false;

        [Browsable(false)]
        public bool EnhanceChineseSearchRestore { get; set; } = false;

        public enum SearchItemType
        {
            Movie,
            Collection,
            Series,
            Season,
            Episode,
            Person,
            LiveTv,
            Playlist,
            Video
        }

        [Browsable(false)]
        public List<EditorSelectOption> SearchItemTypeList { get; set; } = new List<EditorSelectOption>();

        [DisplayName("搜索范围")]
        [Description("选择要参与搜索的类型，留空表示全部。")]
        [EditMultilSelect]
        [SelectItemsSource(nameof(SearchItemTypeList))]
        public string SearchScope { get; set; } =
            string.Join(",", new[] { SearchItemType.Movie, SearchItemType.Collection, SearchItemType.Series });

        [DisplayName("排除原始标题")]
        [Description("从搜索中排除 OriginalTitle 字段，默认关闭。")]
        public bool ExcludeOriginalTitleFromSearch { get; set; } = false;

        public void Initialize()
        {
            SearchItemTypeList.Clear();
            foreach (SearchItemType item in Enum.GetValues(typeof(SearchItemType)))
            {
                SearchItemTypeList.Add(new EditorSelectOption
                {
                    Value = item.ToString(),
                    Name = GetSearchItemTypeDisplayName(item),
                    IsEnabled = true
                });
            }
        }

        private static string GetSearchItemTypeDisplayName(SearchItemType item)
        {
            switch (item)
            {
                case SearchItemType.Movie:
                    return "电影";
                case SearchItemType.Collection:
                    return "合集";
                case SearchItemType.Series:
                    return "剧集";
                case SearchItemType.Season:
                    return "季";
                case SearchItemType.Episode:
                    return "集";
                case SearchItemType.Person:
                    return "人物";
                case SearchItemType.LiveTv:
                    return "直播电视";
                case SearchItemType.Playlist:
                    return "播放列表";
                case SearchItemType.Video:
                    return "视频";
                default:
                    return item.ToString();
            }
        }
    }
}
