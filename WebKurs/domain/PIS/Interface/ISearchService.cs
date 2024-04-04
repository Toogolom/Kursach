namespace PIS.Interface
{
    using WebKurs.Models;
    public interface ISearchService
    {
        public Task<SearchModel> SearchResultAsync(SearchModel model);

    }
}
