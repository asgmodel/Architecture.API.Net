using APILAHJA.Helper.Translation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APILAHJA.VM
{

    public interface ITVM { }
    public class VMInvoiceCreate: ITVM
    {
        
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required TranslationData Status { get; set; }
        public required string Url { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public TranslationData? Description { get; set; }

    }

    public class VMInvoiceOutput: ITVM
    {
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required string Status { get; set; }
        public required string Url { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Description { get; set; }

    }

}
