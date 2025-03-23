using APILAHJA.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APILAHJA.Dso
{

    public interface ITDso { }

    public class InvoiceRequestDso : InvoiceShareRequestDto, ITDso
    {

     
    }

    public class InvoiceResponseDso : InvoiceShareResponseDto, ITDso
    {
       public bool IsActive { get; set; }
    }
}
