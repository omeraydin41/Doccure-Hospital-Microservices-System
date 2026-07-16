using AutoMapper;
using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(AppointmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Tüm randevuları listeleme (Gerekirse ilişkili tabloları Include ile yükler)
        public async Task<List<ResultAppointmentDto>> GetAllAsync()
        {
          var values =await _context.Appointments.ToListAsync();//listeleme işlemi yapılır ve tüm randevular alınır
            return _mapper.Map<List<ResultAppointmentDto>>(values);//mapleme işlemi yapılır ve ResultAppointmentDto türünde bir liste döndürülür
        }

        // ID parametresine göre tek bir randevu getirme
        public async Task<GetAppointmentByIdDto> GetByIdAsync(int id)
        {
           var values =await _context.Appointments.FindAsync(id);//id ile tek bir randevu bulunur
            return _mapper.Map<GetAppointmentByIdDto>(values);//mapleme işlemi yapılır ve GetAppointmentByIdDto türünde bir nesne döndürülür
        }

        // Yeni bir randevu oluşturma
        public async Task CreateAsync(CreateAppointmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);//maplama yapıldı 
            value.Status="pending";//satatus değeri pending olarak ayarlandı
            await _context.Appointments.AddAsync(value);//ekleme yapıldı
            await _context.SaveChangesAsync();//değişiklikler kaydedildi
        }

        // 4. Mevcut randevuyu güncelleme
        public async Task UpdateAsync(UpdateAppointmentDto dto)
        {
           var value = await _context.Appointments.FindAsync(dto.AppointmentId);//id ile randevu bulunur
           value.AppointmentDate = dto.AppointmentDate;//randevu tarihi güncellenir
           value.Status = dto.Status;//status güncellenir
            _context.Appointments.Update(value);//güncelleme yapılır
            await _context.SaveChangesAsync();//değişiklikler kaydedilir
        }

        // ID parametresine göre randevu silme
        public async Task DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);//dışardan alınan id ile randevu bulunur
            _context.Appointments.Remove(appointment);//bulunan randevu silinir
            await _context.SaveChangesAsync();//değişiklikler kaydedilir
        }
    }
}

