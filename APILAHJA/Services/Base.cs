using APILAHJA.Dto;
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

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }
    }

}
