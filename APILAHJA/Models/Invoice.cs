using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APILAHJA.Models
{
    public interface ITModel { }
    public class Invoice : ITModel
    {
        [Key]
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required string Status { get; set; }
        public required string Url { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}
