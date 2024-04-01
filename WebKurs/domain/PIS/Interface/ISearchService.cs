namespace PIS.Interface
{
    using WebKurs.Models;
    public interface ISearchService
    {
        public Task<SearchViewModel> SearchResultAsync(string query);
    }
}
