using AutoMapper;
using Doccure.AppointmentService.Dtos.AppointmentDtos;

namespace Doccure.AppointmentService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Entities.Appointment, ResultAppointmentDto>().ReverseMap();  //appointment entity ile resultappointmentdto arasında mapleme yapılır ve reversemap ile ters mapleme de yapılır
            CreateMap<Entities.Appointment, GetAppointmentByIdDto>().ReverseMap(); //appointment entity ile getappointmentbyiddto arasında mapleme yapılır ve reversemap ile ters mapleme de yapılır
            CreateMap<Entities.Appointment, CreateAppointmentDto>().ReverseMap();  //appointment entity ile createappointmentdto arasında mapleme yapılır ve reversemap ile ters mapleme de yapılır
            CreateMap<Entities.Appointment, UpdateAppointmentDto>().ReverseMap();  //appointment entity ile updateappointmentdto arasında mapleme yapılır ve reversemap ile ters mapleme de yapılır
        }
    }
}
