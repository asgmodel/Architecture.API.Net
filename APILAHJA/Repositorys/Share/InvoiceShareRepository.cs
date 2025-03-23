using APILAHJA.Data;
using APILAHJA.Dto;
using APILAHJA.Models;
using APILAHJA.Repositorys.Builder;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APILAHJA.Repositorys.Share
{
 

        public interface IInvoiceShareRepository :IBaseShareRepository<InvoiceShareRequestDto, InvoiceShareResponseDto>,IInvoiceBuilderRepository<InvoiceShareRequestDto, InvoiceShareResponseDto>
        {

        }


        public class InvoiceShareRepository : BaseShareRepository<InvoiceShareRequestDto, InvoiceShareResponseDto, InvoiceBuildRequestDto, InvoiceBuildResponseDto>,IInvoiceShareRepository

    {


            private readonly InvoiceBuilderRepository _builder;
            
            public InvoiceShareRepository(DataContext dbContext, IMapper mapper, ILogger logger) :base(mapper,logger) {
            
                _builder = new InvoiceBuilderRepository(dbContext, mapper, logger);
                 
            }

            public Task<int> CountAsync()
            {
                throw new NotImplementedException();
            }

            public async Task<InvoiceShareResponseDto> CreateAsync(InvoiceShareRequestDto entity)
            {
              
             var item=  this.MapToBuildRequestDto(entity);
             var result =await _builder.CreateAsync(item);
             return this.MapToShareResponseDto(result);
        }

            public Task<IEnumerable<InvoiceShareResponseDto>> CreateRangeAsync(IEnumerable<InvoiceShareRequestDto> entities)
            {
                throw new NotImplementedException();
            }

            public Task DeleteAsync(int id)
            {
                throw new NotImplementedException();
            }

            public Task DeleteRangeAsync(Expression<Func<InvoiceShareResponseDto, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public Task<bool> ExistsAsync(Expression<Func<InvoiceShareResponseDto, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public Task<InvoiceShareResponseDto?> FindAsync(Expression<Func<InvoiceShareResponseDto, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<InvoiceShareResponseDto>> GetAllAsync()
            {
                throw new NotImplementedException();
            }

            public Task<InvoiceShareResponseDto?> GetByIdAsync(int id)
            {
                throw new NotImplementedException();
            }

        public InvoiceShareResponseDto getData(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InvoiceShareResponseDto> GetQueryable()
            {
                throw new NotImplementedException();
            }

            public Task SaveChangesAsync()
            {
                throw new NotImplementedException();
            }

            public Task<InvoiceShareResponseDto> UpdateAsync(InvoiceShareRequestDto entity)
            {
                throw new NotImplementedException();
            }
        }

    }




