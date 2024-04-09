namespace PIS.Interface
{
    using PIS.Memory;
    using System;

    public interface IChatService
    {
        public Task<List<Message>> GetAllMessage();

        public Task AddMessage(string text);

        public Task LikeMessage(string id);

        public Task DislikeMessage(string id);

        public Task UnLikeMessage(string id);

        public Task UnDislikeMessage(string id);

        public Task AddComment(string id, string text);
    }
}
