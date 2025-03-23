using APILAHJA.Data;
using APILAHJA.Repositorys.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APILAHJA.Repositorys.Builder
{

    public interface IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto>
          where TBuildRequestDto : class
          where TBuildResponseDto : class
    {
        Task<IEnumerable<TBuildResponseDto>> GetAllAsync();
        Task<TBuildResponseDto?> GetByIdAsync(int id);
        Task<TBuildResponseDto?> FindAsync(Expression<Func<TBuildResponseDto, bool>> predicate);
        IQueryable<TBuildResponseDto> GetQueryable();

        Task<TBuildResponseDto> CreateAsync(TBuildRequestDto entity);
        Task<IEnumerable<TBuildResponseDto>> CreateRangeAsync(IEnumerable<TBuildRequestDto> entities);

        Task<TBuildResponseDto> UpdateAsync(TBuildRequestDto entity);

        Task DeleteAsync(int id);
        Task DeleteRangeAsync(Expression<Func<TBuildResponseDto, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<TBuildResponseDto, bool>> predicate);
        Task<int> CountAsync();

        Task SaveChangesAsync();
    }

    public abstract  class BaseBuilderRepository<TModel, TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto>
      where TModel : class
      where TBuildRequestDto : class
      where TBuildResponseDto : class
    {

        protected readonly IBaseRepository<TModel> _repository;
        protected readonly IMapper _mapper;
        ILogger _logger;
        public BaseBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger)
        {
      
            _repository = new BaseRepository<TModel>(dbContext, logger);
            _mapper = mapper;
            _logger = logger;
        }

        #region Get Methods

        public async Task<IEnumerable<TBuildResponseDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(entity => _mapper.Map<TBuildResponseDto>(entity));
        }

        public async Task<TBuildResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByAsync(e => EF.Property<int>(e, "Id") == id);
            return entity != null ? _mapper.Map<TBuildResponseDto>(entity) : null;
        }

        public async Task<TBuildResponseDto?> FindAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {

            return null; 
        }

        public IQueryable<TBuildResponseDto> GetQueryable()
        {
            var entities = _repository.GetAll();
            return entities.Select(e => _mapper.Map<TBuildResponseDto>(e)).AsQueryable();
        }

        #endregion

        #region Create Methods

        public async Task<TBuildResponseDto> CreateAsync(TBuildRequestDto entity)
        {
            var modelEntity = _mapper.Map<TModel>(entity);
            modelEntity= await _repository.CreateAsync(modelEntity);
            return _mapper.Map<TBuildResponseDto>(modelEntity);
        }

        public async Task<IEnumerable<TBuildResponseDto>> CreateRangeAsync(IEnumerable<TBuildRequestDto> entities)
        {
            var modelEntities = _mapper.Map<IEnumerable<TModel>>(entities);
            
            var listdto = new List<TBuildResponseDto>();
            foreach (var model in modelEntities)
            {
              var bresp=  await _repository.CreateAsync(model);
                listdto.Add(_mapper.Map<TBuildResponseDto>(bresp));
            }
            return listdto;
        }

        #endregion

        #region Update Methods

        public async Task<TBuildResponseDto> UpdateAsync(TBuildRequestDto entity)
        {
            var modelEntity = _mapper.Map<TModel>(entity);
            modelEntity= await _repository.UpdateAsync(modelEntity);
            return _mapper.Map<TBuildResponseDto>(modelEntity);
        }

        #endregion

        #region Delete Methods

        public async Task DeleteAsync(int id)
        {
            await _repository.RemoveAsync(e => EF.Property<int>(e, "Id") == id);
        }

        //public async Task DeleteRangeAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        //{
        //    // حذف الكائنات بناءً على شرط معين
        //    await _repository.RemoveAsync(e => predicate.Invoke(_mapper.Map<TBuildResponseDto>(e)));
        //}

        //#endregion

        //#region Helper Methods

        //// التحقق إذا كان يوجد كائن يلبي الشرط المعطى
        //public async Task<bool> ExistsAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        //{
        //    var exists = await _repository.Exists(e => predicate.Invoke(_mapper.Map<TBuildResponseDto>(e)));
        //    return exists;
        //}

        public async Task<int> CountAsync()
        {
            // عد عدد العناصر في القاعدة
            return await _repository.GetAll().CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            // حفظ التغييرات في القاعدة
            await _repository.SaveAsync();
        }

        public Task DeleteRangeAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
