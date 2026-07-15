using Doccure.AppointmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppointmentService.Context
{
    public class AppointmentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MD57CH6;initial catalog=DoccureAppointmentDb;integrated security=True");
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedule { get; set; }
    }
}
