using APILAHJA.Dto;
using APILAHJA.Models;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APILAHJA.Repositorys.Builder
{
    public interface IInvoiceBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto>
     where TBuildRequestDto : class
     where TBuildResponseDto : class
    {
      
    }
    public  class InvoiceBuilderRepository : BaseBuilderRepository<Invoice, InvoiceBuildRequestDto, InvoiceBuildResponseDto>, IInvoiceBuilderRepository<InvoiceBuildRequestDto, InvoiceBuildResponseDto>
    {
        public InvoiceBuilderRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
    

}
