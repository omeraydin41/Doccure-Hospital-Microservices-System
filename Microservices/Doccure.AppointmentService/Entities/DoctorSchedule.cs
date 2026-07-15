namespace Doccure.AppointmentService.Entities
{
    public class DoctorSchedule // Doktor takvimi
    {
        public int DoctorScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public int? AppointmentId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Appointment Appointment { get; set; } // Navigation property to the Appointment entity

    }
}