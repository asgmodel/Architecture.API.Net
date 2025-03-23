using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APILAHJA.Dto
{

    public class InvoiceBuildRequestDto
    {
       
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required string Status { get; set; }
        public required string Url { get; set; }
        public required string Url2 { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }

    public class InvoiceBuildResponseDto
    {
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required string Status { get; set; }
        public required string Url { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }


    public class InvoiceShareRequestDto: InvoiceBuildRequestDto
    {

    
    }

    public class InvoiceShareResponseDto: InvoiceBuildResponseDto
    {
       
    }
}
