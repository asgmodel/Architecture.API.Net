using APILAHJA.Repositorys.Base;
using APILAHJA.Repositorys.Builder;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APILAHJA.Repositorys.Share
{

    public interface IBaseShareRepository<TShareRequestDto, TShareResponseDto> 
    where TShareRequestDto : class 
    where TShareResponseDto : class
{

}

    public abstract class BaseShareRepository<TShareRequestDto, TShareResponseDto, TBuildRequestDto, TBuildResponseDto> : IBaseShareRepository<TShareRequestDto, TShareResponseDto>
        where TShareRequestDto : class
        where TShareResponseDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        public BaseShareRepository(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }




        // دالة لتحويل TShareRequestDto إلى TBuildRequestDto
        protected TBuildRequestDto MapToBuildRequestDto(TShareRequestDto shareRequestDto)
        {
            if (shareRequestDto == null)
            {
                throw new ArgumentNullException(nameof(shareRequestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<TBuildRequestDto>(shareRequestDto);
        }


        // دالة لتحويل TBuildResponseDto إلى TShareResponseDto
        protected TShareResponseDto MapToShareResponseDto(TBuildResponseDto buildResponseDto)
        {
            if (buildResponseDto == null)
            {
                throw new ArgumentNullException(nameof(buildResponseDto), "The build response DTO cannot be null.");
            }

            return _mapper.Map<TShareResponseDto>(buildResponseDto);
        }

        // دالة لتحويل TShareRequestDto إلى TShareResponseDto
        protected TShareResponseDto MapToShareResponseDto(TShareRequestDto shareRequestDto)
        {
            if (shareRequestDto == null)
            {
                throw new ArgumentNullException(nameof(shareRequestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<TShareResponseDto>(shareRequestDto);
        }

        // دالة لتحويل TBuildRequestDto إلى TShareRequestDto
        protected TShareRequestDto MapToShareRequestDto(TBuildRequestDto buildRequestDto)
        {
            if (buildRequestDto == null)
            {
                throw new ArgumentNullException(nameof(buildRequestDto), "The build request DTO cannot be null.");
            }

            return _mapper.Map<TShareRequestDto>(buildRequestDto);
        }

        // دالة لتحويل TShareResponseDto إلى TBuildResponseDto
        protected TBuildResponseDto MapToBuildResponseDto(TShareResponseDto shareResponseDto)
        {
            if (shareResponseDto == null)
            {
                throw new ArgumentNullException(nameof(shareResponseDto), "The share response DTO cannot be null.");
            }

            return _mapper.Map<TBuildResponseDto>(shareResponseDto);
        }
    }

}
