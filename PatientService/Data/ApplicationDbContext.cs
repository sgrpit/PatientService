using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientService.Domain;

namespace PatientService.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PatientAppointment> PatientAppointment { get; set; }
        public DbSet<PatientsDetails> PatientsDetails { get; set; }

        
    }
}
