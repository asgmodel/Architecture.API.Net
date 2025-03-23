using APILAHJA.Dso;
using APILAHJA.Dto;
using APILAHJA.Repositorys.Share;
using APILAHJA.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace APILAHJA.Services
{


    public  interface IInvoiceService
    {
        Task<InvoiceShareResponseDto> CreateAsync(VMInvoiceCreate entity);
       
    }
    public class InvoiceService: BaseService
    {
        private readonly IInvoiceShareRepository _invoiceShareRepository;
        

        public InvoiceService(IInvoiceShareRepository invoiceShareRepository,IMapper mapper): base(mapper)
        {
            _invoiceShareRepository = invoiceShareRepository;
        

        }


         
        public async Task<InvoiceResponseDso> CreateAsync(InvoiceRequestDso entity)
        {

            
            var result = await _invoiceShareRepository.CreateAsync(entity);

            var output = (InvoiceResponseDso)result;


            return output;
        }


       
    }

}
