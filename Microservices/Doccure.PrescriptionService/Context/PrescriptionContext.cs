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
         public DbSet<Prescription> Prescriptions { get; set; }
         public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
 

    }
}
