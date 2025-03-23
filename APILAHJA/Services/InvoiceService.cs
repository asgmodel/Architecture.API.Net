using APILAHJA.Dso;
using APILAHJA.Dto;
using APILAHJA.Repositorys.Builder;
using APILAHJA.Repositorys.Share;
using APILAHJA.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace APILAHJA.Services
{


    public  interface IInvoiceService<TServiceRequestDso, TServiceResponseDso>

       where TServiceRequestDso : class
       where TServiceResponseDso : class
    {
        Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
       
    }
    public class InvoiceService: BaseService, IInvoiceService<InvoiceRequestDso, InvoiceResponseDso>
    {
        private readonly IInvoiceShareRepository _invoiceShareRepository;

        public InvoiceService(IInvoiceShareRepository invoiceShareRepository,IMapper mapper, ILogger logge) : base(mapper, logge)
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
