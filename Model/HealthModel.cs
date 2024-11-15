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
        public string? Decleration { get; set; }
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


    //public class HealthModel
    //{
    //    [BsonId]
    //    [BsonRepresentation(BsonType.ObjectId)]
    //    public string? Id { get; set; }

    //    public int AutoNumber { get; set; }

    //    [Required(ErrorMessage = "The Name field is required.")]
    //    public string Name { get; set; }


    //    public string BillNo { get; set; }


    //    public string BillId { get; set; }


    //    public string Description { get; set; }

    //    [Required(ErrorMessage = "The EmailId field is required.")]
    //    public string EmailId { get; set; }

    //    [Required(ErrorMessage = "The PhoneNo field is required.")]
    //    public string PhoneNo { get; set; }

    //    [Required(ErrorMessage = "The Address field is required.")]
    //    public AddressModel? Address { get; set; }

    //    [Required(ErrorMessage = "The Items field is required.")]
    //    public List<ItemModel> Items { get; set; }

    //    public int SubTotal { get; set; }
    //    public int Discount { get; set; }
    //    public int FinalAmount { get; set; }

    //    public int AmountPaid { get; set; }
    //    public int Balance { get; set; }

    //    public string? Decleration { get; set; }

    //    public bool IsDeleted { get; set; } = false;

    //    public DateTime Date { get; set; } = DateTime.Now;
    //}

    //public class ItemModel
    //{
    //    [Display(Name = "Item_Description")]
    //    [StringLength(500, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string Description { get; set; }

    //    public int AppliedQty { get; set; }
    //    public string Price { get; set; }
    //    public int Gst { get; set; }
    //    public int Amount { get; set; }
    //}

    //public class AddressModel
    //{
    //    [Display(Name = "Address Line 1")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string Building { get; set; }

    //    [Display(Name = "Street")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max{1} characters long.")]
    //    public string Street { get; set; }

    //    [Display(Name = "Landmark")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string Landmark { get; set; }

    //    [Display(Name = "City")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string City { get; set; }

    //    [Display(Name = "District")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string District { get; set; }

    //    [Display(Name = "Pincode")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]
    //    public string Pincode { get; set; }

    //    [Display(Name = "State")]
    //    public string State { get; set; }

    //    [Display(Name = "Country")]
    //    [StringLength(150, ErrorMessage = "The {0} must be at max{1} characters long.")]
    //    public string Country { get; set; } = "India";
    //}
}





//public enum Gstpercentage
//{
//enum1,
//enum2,  
//enum3,
//enum4,
//enum5,

//  }


//public enum Quantity
//{
//   Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9, Quantity10

//}






