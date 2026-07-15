namespace Doccure.AppointmentService.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }//mongodan geliyor 
        public int PatientId { get; set; }//identityden gelecek 
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual AppointmentDetail AppointmentDetail { get; set; }
        public virtual List<DoctorSchedule> DoctorSchedules { get; set; } 
    }
}
