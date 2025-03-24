using APILAHJA.Helper.Translation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APILAHJA.Dto
{




    public interface ITBuildDto
    {

    }
    public class InvoiceBuildRequestDto: ITBuildDto
    {
       
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required TranslationData Status { get; set; }
        public required string Url { get; set; }
        public required string Url2 { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public TranslationData? Description { get; set; }
    }

    public class InvoiceBuildResponseDto: ITBuildDto
    {
        public required string Id { get; set; }
        public required string CustomerId { get; set; }
        public required string Status { get; set; }
        public required string Url { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Description { get; set; }
    }

    public interface ITShareDto
    {

    }
    public class InvoiceShareRequestDto: InvoiceBuildRequestDto, ITShareDto
    {

    
    }

    public class InvoiceShareResponseDto: InvoiceBuildResponseDto, ITShareDto
    {
       
    }
}
