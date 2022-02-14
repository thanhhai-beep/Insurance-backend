using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backend.Models
{
    public partial class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext()
        {
        }

        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalDetail> ApprovalDetails { get; set; }
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<HospitalInfo> HospitalInfos { get; set; }
        public virtual DbSet<Policy> Policys { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }
        public virtual DbSet<TotalDescription> TotalDescriptions { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-RP9BI5I\\SQLEXPRESS01; database=InsuranceDB; uid=sa;pwd=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ApprovalDetail>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ApprovalDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__ApprovalD__Emp_I__4316F928");
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CompanyURL");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99FEABA176");

                entity.ToTable("Employee");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Enddate).HasColumnType("datetime");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LName");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.Startdate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Employee__Compan__403A8C7D");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Employee__Policy__3F466844");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Feedback__Emp_Id__4E88ABD4");
            });

            modelBuilder.Entity<HospitalInfo>(entity =>
            {
                entity.ToTable("HospitalInfo");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.PolicyDesc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Policys__Company__3C69FB99");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__RequestDe__Compa__47DBAE45");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__RequestDe__Emp_I__45F365D3");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__RequestDe__Polic__46E78A0C");
            });

            modelBuilder.Entity<TotalDescription>(entity =>
            {
                entity.ToTable("TotalDescription");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.PolicyDesc)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TotalDescriptions)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__TotalDesc__Compa__4BAC3F29");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.TotalDescriptions)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__TotalDesc__Polic__4AB81AF0");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserLogi__536C85E52551D0EF");

                entity.ToTable("UserLogin");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
