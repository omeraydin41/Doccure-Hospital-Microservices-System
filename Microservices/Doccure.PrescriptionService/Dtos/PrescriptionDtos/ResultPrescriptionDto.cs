namespace Doccure.PrescriptionService.Dtos.PrescriptionDtos
{
    public class ResultPrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }
    /* 
        JSON FORMATI (Okuma / GET Cevabı):
        {
          "prescriptionId": 1,
          "appointmentId": 101,
          "doctorId": "DOC-12345",
          "patientId": "PAT-67890",
          "createdDate": "2026-07-20T09:30:00Z",
          "prescriptionItems": [
            {
              "medicineName": "Parol 500mg Tablet",
              "usage": "Günde 2 kez (Tok karnına)",
              "duration": "5 gün"
            }
          ]
        }
    */
}
