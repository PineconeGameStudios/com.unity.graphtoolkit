namespace Unity.GraphToolkit.Editor.Implementation
{
    class PublicLibraryHelper : ItemLibraryHelper
    {
        private ILibraryFilterProvider m_LibraryFilterProvider;

        public PublicLibraryHelper(GraphModel graphModel) : base(graphModel) { }
        public override IItemDatabaseProvider GetItemDatabaseProvider()
        {
            return m_DatabaseProvider ??= new PublicDatabaseProviderImp(GraphModel);
        }

        public override ILibraryFilterProvider GetLibraryFilterProvider()
        {
            return m_LibraryFilterProvider ??= new PublicLibraryFilterProvider();
        }
    }
}
