


using APILAHJA.Dso;
using APILAHJA.Dto;
using APILAHJA.Helper.Translation;
using APILAHJA.Models;
using APILAHJA.VM;
using AutoMapper;
using System.Reflection;

namespace APILAHJA.Config
{

   
    public class MappingConfig : Profile
    {


        public static bool CheckIgnoreAutomateMapper(Type type)
        {
            var attribute = type.GetCustomAttribute<IgnoreAutomateMapperAttribute>();

            // Return true if the attribute exists and IgnoreMapping is true, otherwise false
            return attribute != null && attribute.IgnoreMapping;
        }

        public MappingConfig()
        {


            var assembly = Assembly.GetExecutingAssembly();

            var models = assembly.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();
            var dtos = assembly.GetTypes().Where(t => typeof(ITBuildDto).IsAssignableFrom(t) && t.IsClass).ToList();
            var vms = assembly.GetTypes().Where(t => typeof(ITVM).IsAssignableFrom(t) && t.IsClass).ToList();
            var dsos = assembly.GetTypes().Where(t => typeof(ITDso).IsAssignableFrom(t) && t.IsClass).ToList();

 
            // map daynamic  Model and DTO
            foreach (var model in models)
            {

                if (!CheckIgnoreAutomateMapper(model))
                {


                    var dtoMatches = dtos.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var dto in dtoMatches)
                    {
                        if (!CheckIgnoreAutomateMapper(dto))
                        {
                            CreateMap(model, dto).ReverseMap().ForAllMembers(opt => opt.MapFrom((src, dest, destMember, context) =>
                            {
                                return HelperTranslation.MapToTranslationData(src, dest, destMember);
                            }));
                        }


                       
                    }

                }
               
            }



            //  map daynamic  VM and DSO

            foreach (var dso in dsos)
            {
                if (!CheckIgnoreAutomateMapper(dso))
                {
                    var vmMatches = vms.Where(v => v.Name.Contains(dso.Name.Replace("RequestDso", "").Replace("ResponseDso", ""), StringComparison.OrdinalIgnoreCase)).ToList();
                    foreach (var vm in vmMatches)
                    {
                        if (!CheckIgnoreAutomateMapper(vm))
                        {
                            CreateMap(dso, vm).ReverseMap();
                        }
                    }
                }
            }
        }
    }
}