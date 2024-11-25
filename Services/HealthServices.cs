using HealthApplication.Model;
using HealthApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace HealthApplication.Services
{
    public class HealthServices
    {

        private readonly IMongoCollection<HealthModel> _health;

        public HealthServices(IOptions<MongoDBSettings> MongoDBSettings)
        {
            var client = new MongoClient(MongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(MongoDBSettings.Value.DatabaseName);
            _health = database.GetCollection<HealthModel>("Health");
        }

        public async Task<List<HealthModel>> GetAllHealthAsync(string name = null, string billId = null)
        {
            var filterBuilder = Builders<HealthModel>.Filter;
            var filter = filterBuilder.Empty;
           // filter &= filterBuilder.Eq("IsDeleted", true);
            if (!string.IsNullOrEmpty(name)){

                filter &= filterBuilder.Regex("Name", name);
            }
            if (!string.IsNullOrEmpty(billId))
            {

                filter &= filterBuilder.Regex("BillId", billId);
            }
            return await _health.Find(filter).ToListAsync();
        }


        public async Task<HealthModel> GetAllHealthByIdAsync(string id) => await _health.Find(health => health.Id == id && health.IsDeleted).FirstOrDefaultAsync();


        public async Task CreateHealthAsync(HealthModel health)
        {
            await _health.InsertOneAsync(health);
        }

        public async Task<bool> UpdateHealthAsync(string id, HealthModel updatedHealth)
        {
            if(id!= updatedHealth.Id)
            {
                return false;
            }
            var result = await _health.ReplaceOneAsync(
                health => health.Id == id,
                updatedHealth
            );
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        //public async Task<int> GetNextAutoNoAsync()
        //{
        //    var highestAutoNumber = await _health
        //.SortByDescending(h => h.AutoNumber)
        //.Select(h => h.AutoNumber)
        //.Limit(1)
        //.FirstOrDefaultAsync();


        //    return highestAutoNumber + 1;

        //}

    }
}
