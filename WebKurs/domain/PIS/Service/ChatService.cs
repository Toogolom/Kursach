namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Memory;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ChatService : IChatService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ISessionService _sessionService;

        public ChatService(IMessageRepository messageRepository, ISessionService sessionService)
        {
            _messageRepository = messageRepository;
            _sessionService = sessionService;
        }

        public async Task<List<Message>> GetAllMessage()
        {
            return await _messageRepository.GetAllMessages();
        }

        public async Task AddMessage(string text)
        {
            string username = _sessionService.Get<string>("Username");
            Message message = new Message(username,text,DateTime.Now);
            await _messageRepository.AddMessage(message);
        }

        public async Task LikeMessage(string id)
        {
            string username = _sessionService.Get<string>("Username");
            await _messageRepository.AddLikeToMessage(id, username);
        }

        public async Task DislikeMessage(string id)
        {
            string username = _sessionService.Get<string>("Username");
            await _messageRepository.AddDislikeToMessage(id, username);
        }

        public async Task UnLikeMessage(string id)
        {
            string username = _sessionService.Get<string>("Username");
            await _messageRepository.RemoveLikeFromMessage(id, username);
        }

        public async Task UnDislikeMessage(string id)
        {
            string username = _sessionService.Get<string>("Username");
            await _messageRepository.RemoveDislikeFromMessage(id, username);
        }

        public async Task AddComment(string id, string text)
        {
            string username = _sessionService.Get<string>("Username");
            Message message = new Message(username, text, DateTime.Now);
            await _messageRepository.AddCommentToMessage(id, message);
        }
    }
}
