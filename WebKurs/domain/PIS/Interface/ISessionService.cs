namespace PIS.Interface
{
    public interface ISessionService
    {
        public T Get<T>(string key);

        public void Set<T>(string key, T value);

        public void Remove(string key);
        public void Clear();
    }
}
