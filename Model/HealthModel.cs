using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace HealthApplication.Model
{

    public class HealthModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int AutoNumber { get; set; }
        public string Name { get; set; }
        public string BillNo { get; set; }
        public string BillId { get; set; }
        public string Description { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public AddressModel? Address { get; set; }
        public List<ItemModel> Items { get; set; }
        public int SubTotal { get; set; }
        public int Discount { get; set; }
        public int FinalAmount { get; set; }
        public int AmountPaid { get; set; }
        public int Balance { get; set; }
        //public string? Decleration { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class ItemModel
    {
        public string Description { get; set; }
        public int AppliedQty { get; set; }
        public string Price { get; set; }
        public int Gst { get; set; }
        public int Amount { get; set; }
    }

    public class AddressModel
    {
        public string Building { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}






