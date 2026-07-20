namespace Doccure.PrescriptionService.Dtos.PrescriptionDtos
{
    public class CreatePrescriptionDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public List<PrescriptionItemDto> Items { get; set; }
    }
    /* 
         JSON FORMATI (Ekleme / POST İsteği):
         {
           "appointmentId": 101,
           "doctorId": "DOC-12345",
           "patientId": "PAT-67890",
           "items": [
             {
               "medicineName": "Parol 500mg Tablet",
               "usage": "Günde 2 kez (Tok karnına)",
               "duration": "5 gün"
             }
           ]
         }
         */
}
