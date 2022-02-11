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

        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<HospitalInfo> HospitalInfos { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PolicyApprovalDetails> PolicyApprovalDetails { get; set; }
        public virtual DbSet<PolicyRequestDetails> PolicyRequestDetails { get; set; }
        public virtual DbSet<PolicyTotalDescriptions> PolicyTotalDescriptions { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-RP9BI5I\SQLEXPRESS01; database=InsuranceDB; uid=sa;pwd=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CompanyDetails>(entity =>
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


            modelBuilder.Entity<HospitalInfo>(entity =>
            {
                entity.ToTable("HospitalInfo");

                entity.Property(e => e.HospitalName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__policies__AFB3EC0D5F9171FC");

                entity.ToTable("policiesonemployees");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("empId");

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.PolicyId).HasColumnName("policy_id");

                entity.Property(e => e.Policyduration)
                    .HasColumnType("decimal(7,2)")
                    .HasColumnName("policyduration");

                entity.Property(e => e.Policyname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("policyname");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("tartdate");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__policieso__polic__4E88ABD4");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Policydesc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("policydesc");

                entity.Property(e => e.Policyname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("policyname");
            });

            modelBuilder.Entity<PolicyApprovalDetails>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PolicyRequestDetails>(entity =>
            {
                entity.Property(e => e.Companyname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Policyname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PolicyTotalDescriptions>(entity =>
            {
                entity.ToTable("PolicyTotalDescription");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyDesc)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("policydes");

                entity.Property(e => e.PolicydurationinMonths).HasColumnName("policydurationinMonths");

                entity.Property(e => e.Policyname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("policyname");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserLogi__536C85E5FB91014A");

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
