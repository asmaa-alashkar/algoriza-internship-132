using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EF
{
    public class BackEndDBContext : DbContext
    {
        public BackEndDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Discound> Discounds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Booking>().HasOne(t => t.Patient).WithMany(t => t.Bookings)
                .HasForeignKey(t => t.PatientId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Booking>().HasOne(t => t.Doctor).WithMany(t => t.Bookings)
               .HasForeignKey(t => t.DoctorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Booking>().HasOne(t => t.Appointment).WithMany(t => t.Bookings)
                    .HasForeignKey(t => t.AppointmentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Booking>().HasOne(t => t.Discound).WithMany(t => t.Bookings)
                .HasForeignKey(t => t.DiscoundId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(t => t.Doctor).WithMany(t => t.Requests)
                .HasForeignKey(t => t.DoctorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(t => t.Specialization).WithMany(t => t.Requests)
                .HasForeignKey(t => t.SpecializationId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(t => t.Time).WithMany(t => t.Requests)
                .HasForeignKey(t => t.TimeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(t => t.Discound).WithMany(t => t.Requests)
                .HasForeignKey(t => t.DiscoundId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doctor>().HasOne(t => t.Specialization).WithMany(t => t.Doctors)
                .HasForeignKey(t => t.SpecializationId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
