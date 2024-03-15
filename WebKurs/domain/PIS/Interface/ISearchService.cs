namespace PIS.Interface
{
    using WebKurs.Models;
    public interface ISearchService
    {
        public SearchViewModel SearchResult(string query);
    }
}
