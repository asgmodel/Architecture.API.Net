using APILAHJA.Data;
using APILAHJA.Dto;
using APILAHJA.Models;
using APILAHJA.Repositorys.Base;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APILAHJA.Repositorys.Builder
{
    public interface IInvoiceBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto>
     where TBuildRequestDto : class
     where TBuildResponseDto : class
    {
        Task<TBuildResponseDto>  getData(int id);
    }
    public  class InvoiceBuilderRepository : BaseBuilderRepository<Invoice, InvoiceBuildRequestDto, InvoiceBuildResponseDto>, IInvoiceBuilderRepository<InvoiceBuildRequestDto, InvoiceBuildResponseDto>
    {

        public InvoiceBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<InvoiceBuildResponseDto> getData(int id)
        {

            var entity = await _repository.GetByAsync(e => EF.Property<int>(e, "Id") == id);
            return MapToBuildResponseDto(entity);
        }

       
    }
    

}
