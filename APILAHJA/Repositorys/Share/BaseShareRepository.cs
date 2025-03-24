using APILAHJA.Dto;
using APILAHJA.Models;
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

    public abstract class BaseShareRepository<TShareRequestDto, TShareResponseDto, TBuildRequestDto, TBuildResponseDto>
        : IBaseShareRepository<TShareRequestDto, TShareResponseDto>
        where TShareRequestDto : class
        where TShareResponseDto : class
        where TBuildRequestDto : class
        where TBuildResponseDto : class
    {
        private readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseShareRepository(IMapper mapper, ILoggerFactory logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper instance cannot be null.");
            _logger = logger.CreateLogger(typeof(BaseShareRepository<TShareRequestDto, TShareResponseDto, TBuildRequestDto, TBuildResponseDto>).FullName) ?? throw new ArgumentNullException(nameof(logger), "Logger instance cannot be null.");

            if (!IsAllowCreate())
            {
                _logger.LogError("Creation failed: Specified types do not meet the required conditions.");
                throw new InvalidOperationException("Creation of this repository is not allowed for the specified types.");
            }

            _logger.LogInformation("BaseShareRepository initialized successfully.");
        }

        private static bool IsAllowCreate()
        {
            return typeof(ITShareDto).IsAssignableFrom(typeof(TShareRequestDto)) &&
                   typeof(ITShareDto).IsAssignableFrom(typeof(TShareResponseDto)) &&
                   typeof(ITBuildDto).IsAssignableFrom(typeof(TBuildResponseDto)) &&
                   typeof(ITBuildDto).IsAssignableFrom(typeof(TBuildRequestDto));
        }

        protected TBuildRequestDto MapToBuildRequestDto(TShareRequestDto shareRequestDto)
        {
            if (shareRequestDto == null)
            {
                _logger.LogError("Mapping failed: TShareRequestDto is null.");
                throw new ArgumentNullException(nameof(shareRequestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<TBuildRequestDto>(shareRequestDto);
        }

        protected TShareResponseDto MapToShareResponseDto(TBuildResponseDto buildResponseDto)
        {
            if (buildResponseDto == null)
            {
                _logger.LogError("Mapping failed: TBuildResponseDto is null.");
                throw new ArgumentNullException(nameof(buildResponseDto), "The build response DTO cannot be null.");
            }

            return _mapper.Map<TShareResponseDto>(buildResponseDto);
        }

        protected TShareResponseDto MapToShareResponseDto(TShareRequestDto shareRequestDto)
        {
            if (shareRequestDto == null)
            {
                _logger.LogError("Mapping failed: TShareRequestDto is null.");
                throw new ArgumentNullException(nameof(shareRequestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<TShareResponseDto>(shareRequestDto);
        }

        protected TShareRequestDto MapToShareRequestDto(TBuildRequestDto buildRequestDto)
        {
            if (buildRequestDto == null)
            {
                _logger.LogError("Mapping failed: TBuildRequestDto is null.");
                throw new ArgumentNullException(nameof(buildRequestDto), "The build request DTO cannot be null.");
            }

            return _mapper.Map<TShareRequestDto>(buildRequestDto);
        }

        protected TBuildResponseDto MapToBuildResponseDto(TShareResponseDto shareResponseDto)
        {
            if (shareResponseDto == null)
            {
                _logger.LogError("Mapping failed: TShareResponseDto is null.");
                throw new ArgumentNullException(nameof(shareResponseDto), "The share response DTO cannot be null.");
            }

            return _mapper.Map<TBuildResponseDto>(shareResponseDto);
        }
    }
}
