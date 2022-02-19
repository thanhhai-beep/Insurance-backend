using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Client.Models
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-MDNKSPU\SQLEXPRESS01; database=InsuranceDB; uid=sa;pwd=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ApprovalDetail>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
                entity.Property(e => e.Reason).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<CompanyDetail>(entity =>
            {
                entity.ToTable("CompanyDetail");
                entity.HasKey(e => e.Id).HasName("PK__CompanyDetail");
                entity.Property(e => e.Address).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.CompanyUrl).HasMaxLength(50).IsUnicode(false).HasColumnName("CompanyURL");
                entity.Property(e => e.Phone).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB995524390A");
                entity.ToTable("Employee");
                entity.Property(e => e.Address).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Enddate).HasColumnType("datetime");
                entity.Property(e => e.Fname).HasMaxLength(20).IsUnicode(false).HasColumnName("FName");
                entity.Property(e => e.Image).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Lname).HasMaxLength(20).IsUnicode(false).HasColumnName("LName");
                entity.Property(e => e.Phone).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");
                entity.Property(e => e.Startdate).HasColumnType("datetime");
                entity.Property(e => e.IsAdmin).IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");
                entity.HasKey(e => e.Id).HasName("PK__Feedback");
                entity.Property(e => e.Content).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
                entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<HospitalInfo>(entity =>
            {
                entity.ToTable("HospitalInfo");
                entity.HasKey(e => e.Id).HasName("PK__HospitalInfo");
                entity.Property(e => e.Address).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.HospitalName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Phone).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Url).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("Policy");
                entity.HasKey(e => e.Id).HasName("PK__Policy");
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
                entity.Property(e => e.PolicyDesc).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.PolicyName).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.ToTable("RequestDetail");
                entity.HasKey(e => e.Id).HasName("PK__RequestDetail");
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");
                entity.Property(e => e.RequestDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<TotalDescription>(entity =>
            {
                entity.ToTable("TotalDescription");
                entity.HasKey(e => e.Id).HasName("PK__TotalDescription");
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
                entity.Property(e => e.PolicyDesc).HasMaxLength(250).IsUnicode(false);
                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
