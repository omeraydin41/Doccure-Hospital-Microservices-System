using Doccure.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Doccure.PrescriptionService.Context
{
    public class PrescriptionContext:DbContext
    {
        // Program.cs'ten gönderilecek ayarları kabul eden constructor
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options) : base(options)
        {

        }
         DbSet<Prescription> Prescriptions { get; set; }
         DbSet<PrescriptionItem> PrescriptionItems { get; set; }
 

    }
}
