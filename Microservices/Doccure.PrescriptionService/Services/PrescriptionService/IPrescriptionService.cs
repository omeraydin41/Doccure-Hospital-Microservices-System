using Doccure.PrescriptionService.Dtos.PrescriptionDtos;

namespace Doccure.PrescriptionService.Services.PrescriptionService
{
    public interface IPrescriptionService
    {
        // YENİ REÇETE EKLEME: Sisteme yeni bir reçete kaydetmek için kullanılır | Kullanılan DTO: CreatePrescriptionDto
        Task CreateAsync(CreatePrescriptionDto dto);

        // RANDEVUYA GÖRE REÇETE GETİRME: Belirli bir randevuya ait reçete detayını getirmek için kullanılır | Kullanılan DTO: ResultPrescriptionDto
        Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int appointment);

        // HASTAYA GÖRE REÇETELERİ LİSTELEME: Giriş yapan hastanın tüm reçete geçmişini listelemek için kullanılır | Kullanılan DTO: ResultPrescriptionDto (Liste olarak)
        Task<List<ResultPrescriptionDto>> GetByPatientIdAsync(string pateientId);

        // REÇETE ID'SİNE GÖRE REÇETE GETİRME: Benzersiz reçete kimliği (PrescriptionId) ile tek bir reçetenin detayını getirmek için kullanılır | Kullanılan DTO: ResultPrescriptionDto
        Task<ResultPrescriptionDto> GetByIdAsync(int id);

    }
}