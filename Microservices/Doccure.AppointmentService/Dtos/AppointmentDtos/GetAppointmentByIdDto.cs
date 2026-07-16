namespace Doccure.AppointmentService.Dtos.AppointmentDtos
{
    public class GetAppointmentByIdDto
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }//mongodan geliyor 
        public int PatientId { get; set; }//identityden gelecek 
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }

    }
}
