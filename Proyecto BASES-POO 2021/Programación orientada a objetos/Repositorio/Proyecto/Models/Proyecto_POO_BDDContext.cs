using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proyecto.Models
{
    public partial class Proyecto_POO_BDDContext : DbContext
    {
        public Proyecto_POO_BDDContext()
        {
        }

        public Proyecto_POO_BDDContext(DbContextOptions<Proyecto_POO_BDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<ChronicDisease> ChronicDiseases { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inobservation> Inobservations { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<ManagementAccount> ManagementAccounts { get; set; }
        public virtual DbSet<ManagementLogin> ManagementLogins { get; set; }
        public virtual DbSet<Obserbation> Obserbations { get; set; }
        public virtual DbSet<Ocupation> Ocupations { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<SymptomCitizen> SymptomCitizens { get; set; }
        public virtual DbSet<SymptomReaction> SymptomReactions { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Proyecto_POO_BDD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AssistanceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("assistance_date");

                entity.Property(e => e.IdCitizen).HasColumnName("id_citizen");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdPriority).HasColumnName("id_priority");

                entity.Property(e => e.IdVaccination).HasColumnName("id_vaccination");

                entity.Property(e => e.IdVaccine).HasColumnName("id_vaccine");

                entity.Property(e => e.Observation).HasColumnName("observation");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reservation_date");

                entity.Property(e => e.VaccinationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("vaccination_date");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_ci__46E78A0C");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_em__47DBAE45");

                entity.HasOne(d => d.IdPriorityNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_pr__4316F928");

                entity.HasOne(d => d.IdVaccineNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdVaccine)
                    .HasConstraintName("FK__APPOINTME__id_va__48CFD27E");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Cabins)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CABIN__id_employ__4F7CD00D");
            });

            modelBuilder.Entity<ChronicDisease>(entity =>
            {
                entity.ToTable("CHRONIC_DISEASES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CommonName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("common_name");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("CITIZEN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.IdChronicDiseases).HasColumnName("id_chronic_diseases");

                entity.Property(e => e.IdOccupation).HasColumnName("id_occupation");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.HasOne(d => d.IdChronicDiseasesNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdChronicDiseases)
                    .HasConstraintName("FK__CITIZEN__id_chro__44FF419A");

                entity.HasOne(d => d.IdOccupationNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdOccupation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_occu__45F365D3");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Addresses)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("addresses");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.IdManagementAccount).HasColumnName("id_management_account");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdJob)
                    .HasConstraintName("FK__EMPLOYEE__id_job__4BAC3F29");

                entity.HasOne(d => d.IdManagementAccountNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdManagementAccount)
                    .HasConstraintName("FK__EMPLOYEE__id_man__4CA06362");
            });

            modelBuilder.Entity<Inobservation>(entity =>
            {
                entity.ToTable("INOBSERVATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Minutesymptom).HasColumnName("minutesymptom");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("symptom");

                entity.Property(e => e.Vaccine1)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("vaccine1");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Job1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("job");
            });

            modelBuilder.Entity<ManagementAccount>(entity =>
            {
                entity.ToTable("MANAGEMENT_ACCOUNT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PasswordManagement)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password_management");

                entity.Property(e => e.UserManagement)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_management");
            });

            modelBuilder.Entity<ManagementLogin>(entity =>
            {
                entity.ToTable("MANAGEMENT_LOGIN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("date_hour");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.ManagementLogins)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANAGEMEN__id_ca__5070F446");
            });

            modelBuilder.Entity<Obserbation>(entity =>
            {
                entity.HasKey(e => new { e.IdAppointment, e.IdSymptom })
                    .HasName("PK__OBSERBAT__C2F4CA7B430C1008");

                entity.ToTable("OBSERBATION");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.Property(e => e.IdSymptom).HasColumnName("id_symptom");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.Obserbations)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OBSERBATI__id_ap__49C3F6B7");

                entity.HasOne(d => d.IdSymptomNavigation)
                    .WithMany(p => p.Obserbations)
                    .HasForeignKey(d => d.IdSymptom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OBSERBATI__id_sy__4AB81AF0");
            });

            modelBuilder.Entity<Ocupation>(entity =>
            {
                entity.ToTable("OCUPATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CommonName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("common_name");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.ToTable("PRIORITY_");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Priority1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("priority_");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => new { e.IdEmployee, e.IdManagementLogin })
                    .HasName("PK__RECORD__60468A5B864D35B5");

                entity.ToTable("RECORD");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdManagementLogin).HasColumnName("id_management_login");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RECORD__id_emplo__4D94879B");

                entity.HasOne(d => d.IdManagementLoginNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdManagementLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RECORD__id_manag__4E88ABD4");
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("SYMPTOM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Symptom1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("symptom");
            });

            modelBuilder.Entity<SymptomCitizen>(entity =>
            {
                entity.ToTable("SYMPTOM_CITIZEN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()                    
                    .HasColumnName("id");

                entity.Property(e => e.IdAppointmen).HasColumnName("id_appointmen");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("symptom");

                entity.Property(e => e.Symptomminutes).HasColumnName("symptomminutes");
            });

            modelBuilder.Entity<SymptomReaction>(entity =>
            {
                entity.ToTable("SYMPTOM_REACTION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdSymptom).HasColumnName("id_symptom");

                entity.Property(e => e.ReactionTime).HasColumnName("reaction_time");

                entity.HasOne(d => d.IdSymptomNavigation)
                    .WithMany(p => p.SymptomReactions)
                    .HasForeignKey(d => d.IdSymptom)
                    .HasConstraintName("FK__SYMPTOM_R__id_sy__440B1D61");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("VACCINE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Vaccine1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("vaccine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
