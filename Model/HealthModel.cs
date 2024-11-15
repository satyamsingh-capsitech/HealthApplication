using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace HealthApplication.Model
{
    public class HealthModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int AutoNumber { get; set; }

        public string Name { get; set; }

        public string BillNo { get; set; }
        public string BillId { get; set; }

        public string Description { get; set; }

        public string EmailId { get; set; }
        public string PhoneNo { get; set; }

        public AddressModel Address { get; set; }

        public List<ItemModel> Items { get; set; }

        public  int SubTotal { get; set; }
        public int Discount { get; set; }
        public int FinalAmount { get; set; }

        public int AmountPaid { get; set; }
        public int Balance {  get; set; }

        public string Decleration {  get; set; }

        public bool IsDeleted   { get; set; }= true;

        public DateTime Date {  get; set; }

    }

    public class ItemModel
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        [Display(Name = "Item_Description")]
        [StringLength(500, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Description { get; set; }
        public int AppliedQty { get; set; }  
        public string Price { get; set; }
        public int  Gst { get; set; } 
        public int Amount { get; set; }

        
    }

          public class AddressModel
            {
                /// Address line 1
                [Display(Name = "Address Line 1")]
                [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]

                public string Building { get; set; }

                /// Street/building/village name
                [Display(Name = "Street")]
                [StringLength(150, ErrorMessage = "The {0} must be at max{1} characters long.")]

                public string Street { get; set; }

                /// Landmark name        
                [Display(Name = "Landmark")]
                [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]

                public string Landmark { get; set; }

                /// City/town name or Address line 3
                [Display(Name = "City")]
                [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]

                public string City { get; set; }

                /// District name
                [Display(Name = "District")]
                [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]

                public string District { get; set; }

                /// Postal code
                [Display(Name = "Pincode")]
                [StringLength(150, ErrorMessage = "The {0} must be at max {1} characters long.")]

                public string Pincode { get; set; }

                /// State name
                [Display(Name = "State")]

                public string State { get; set; }

                /// Country 
                [Display(Name = "Country")]
                [StringLength(150, ErrorMessage = "The {0} must be at max{1} characters long.")]

                public string Country { get; set; } = "India";

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



}


