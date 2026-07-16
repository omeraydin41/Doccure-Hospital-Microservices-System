namespace Doccure.AppointmentService.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public int DoctorId { get; set; }//mongodan geliyor 
        public int PatientId { get; set; }//identityden gelecek 
        public DateTime AppointmentDate { get; set; }
        public decimal Price { get; set; }

    }
}
