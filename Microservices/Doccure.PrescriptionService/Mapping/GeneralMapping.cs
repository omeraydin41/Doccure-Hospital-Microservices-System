using AutoMapper;
using Doccure.PrescriptionService.Dtos.PrescriptionDtos;
using Doccure.PrescriptionService.Entities;

namespace Doccure.PrescriptionService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Prescription, ResultPrescriptionDto>();

            CreateMap<CreatePrescriptionDto, Prescription>();//her map çift yonlu olmak zorunda değil 

            CreateMap<PrescriptionItem, PrescriptionItemDto>().ReverseMap();
        }
    }
}
