namespace PIS.Memory
{
    using global::PIS.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using global::PIS.Interface;

    public class EmailRepository : IEmailRepository
    {
        private readonly IMongoCollection<Email> _emailCollection;

        public EmailRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _emailCollection = database.GetCollection<Email>("Email");
        }

        public async Task SaveEmail(Email email)
        {
            await _emailCollection.InsertOneAsync(email);
        }
    }
}
