using APILAHJA.Dto;
using APILAHJA.Models;
using APILAHJA.Repositorys.Share;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace APILAHJA.Services
{

    public class BaseService
    {
        protected readonly   IMapper _mapper;

        protected readonly ILogger _logger;

        public BaseService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

       
        public IMapper GetMapper()
        {
            return _mapper;
        }
    }

}
