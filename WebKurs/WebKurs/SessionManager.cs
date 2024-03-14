namespace WebKurs
{
    using System.Text.Json;

    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Get<T>(string key)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString(key);
            return session == null ? default : JsonSerializer.Deserialize<T>(session);
        }

        public void Set<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }
    }
}
