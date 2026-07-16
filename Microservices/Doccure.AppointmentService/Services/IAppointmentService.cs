using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;

namespace Doccure.AppointmentService.Services
{
    public interface IAppointmentService
    {
        Task<List<ResultAppointmentDto>> GetAllAsync(); //liste işlemi için appointemn turunde bir liste döndürür
        Task<GetAppointmentByIdDto> GetByIdAsync(int id);//id ile tek bir appointment döndürür
        Task CreateAsync(CreateAppointmentDto dto);//appointment nesnesi uzerinden işlem yapar ve yeni bir appointment oluşturur
        Task UpdateAsync(UpdateAppointmentDto dto);//appointment nesnesi uzerinden işlem yapar ve mevcut bir appointment günceller
        Task DeleteAsync(int id);//silmek için id alır 
    }
}
