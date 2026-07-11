using AutoMapper;
using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Entities;

namespace Doccure.DoctorService.Mapping
{
    public class GeneralMapping : Profile
    {
        protected GeneralMapping()//constructor tanımladık
        {
            CreateMap<Doctor,ResultDoctorDto>().ReverseMap(); //doctor classını gorduğunde resultDoctorDto ya map etmesini söylüyoruz. ReverseMap ile tam tersi de geçerli olacak şekilde ayarlıyoruz.
            CreateMap<Doctor,UpdateDoctorDto>().ReverseMap(); //updateDoctorDto ile doctor classını map etmesini söylüyoruz. ReverseMap ile tam tersi de geçerli olacak şekilde ayarlıyoruz.
            CreateMap<Doctor,CreateDoctorDto>().ReverseMap(); //createDoctorDto ile doctor classını map etmesini söylüyoruz. ReverseMap ile tam tersi de geçerli olacak şekilde ayarlıyoruz.
            CreateMap<Doctor,GetByIdDoctorDto>().ReverseMap();//getByIdDoctorDto ile doctor classını map etmesini söylüyoruz. ReverseMap ile tam tersi de geçerli olacak şekilde ayarlıyoruz.
        }
    }
}
