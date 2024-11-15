
using MongoDB.Driver;
using HealthApplication.Model;
using Microsoft.Extensions.Options;
using HealthApplication.Models;

namespace HealthApplication.Services

{
    public class LoginServices
    {

        private readonly IMongoCollection<LoginModel> _login;

        public LoginServices(IOptions<MongoDBSettings> MongoDBSettings)
        {
            var client = new MongoClient(MongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(MongoDBSettings.Value.DatabaseName);
            _login = database.GetCollection<LoginModel>("Login");
        }

        public async Task<List<LoginModel>> GetAllLoginAsync() => await _login.Find(login => true).ToListAsync();
        //public async Task<LoginModel> GetLoginByIdAsync(string id)
        //{
        //    return await _login.Find(login => login.Id == id).FirstOrDefaultAsync();
        //}
        public async Task CreateLoginAsync(LoginModel login)
        {
            await _login.InsertOneAsync(login);
        }

        public async Task<LoginModel> ValidateUserAsync(string username, string password)
        {
            var user = await _login.Find(t => t.UserName == username).FirstOrDefaultAsync();
            if (user != null && password== user.Password)
            {
                return user;
            }
            return null;
        }
    }
}
