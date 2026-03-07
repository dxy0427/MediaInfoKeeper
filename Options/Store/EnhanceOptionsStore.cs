namespace MediaInfoKeeper.Options.Store
{
    using System;
    using MediaInfoKeeper.Patch;
    using MediaInfoKeeper.Options;

    internal class EnhanceOptionsStore
    {
        private readonly PluginOptionsStore pluginOptionsStore;

        public EnhanceOptionsStore(PluginOptionsStore pluginOptionsStore)
        {
            this.pluginOptionsStore = pluginOptionsStore;
        }

        public EnhanceOptions GetOptions()
        {
            var options = this.pluginOptionsStore.GetOptionsForUi();
            var enhanceOptions = options.Enhance ?? new EnhanceOptions();
            enhanceOptions.Initialize();
            return enhanceOptions;
        }

        public void SetOptions(EnhanceOptions options)
        {
            var pluginOptions = this.pluginOptionsStore.GetOptions();
            var current = pluginOptions.Enhance ?? new EnhanceOptions();
            var next = options ?? new EnhanceOptions();

            if (!string.Equals(current.SearchScope, next.SearchScope, StringComparison.Ordinal))
            {
                ChineseSearch.UpdateSearchScope(next.SearchScope);
            }

            var isSimpleTokenizer =
                string.Equals(ChineseSearch.CurrentTokenizerName, "simple", StringComparison.Ordinal);
            next.EnhanceChineseSearchRestore = !next.EnhanceChineseSearch && isSimpleTokenizer;

            pluginOptions.Enhance = next;
            this.pluginOptionsStore.SetOptions(pluginOptions);
        }
    }
}
