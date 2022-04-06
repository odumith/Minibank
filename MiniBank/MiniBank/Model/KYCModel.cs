using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Model
{
    public class KYCModel
    {
       // [Key]
        public int id { get; set; }
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Key]
        public string Nuban { get; set; }
       // public string ResponseCode { get; set; }
       // public string ResponseMessage { get; set; }
        public decimal Amount { get; set; }
        public byte[] Image { get; set; }
        // public string Image { get; set; }
    }

    public class KYC
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
    public class fileup
    {
        public IFormFile Image { get; set; }
    }
    public class KYCResponse
    {
        public string Nuban { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class topup
    {
        public decimal Amount { get; set; }
        public string Nuban { get; set; }
    }

}
