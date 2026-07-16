using Doccure.AppointmentService.Dtos.AppointmentDetail;

namespace Doccure.AppointmentService.Services.AppointmentDetailService
{
    public interface IAppointmentDetailService
    {
        Task CreateAsync(CreateAppointmentDetailDto dto);
        Task<ResultAppointmentDetailDto> GetAllAppointmentDetailAsync(int appointmentId);
        Task UpdateAsync(UpdateAppointmentDetailDto dto);        
    }
}
