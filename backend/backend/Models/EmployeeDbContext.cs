using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> o) : base(o)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Employee>().Property(s => s.empId).HasColumnName("empId");
            modelBuilder.Entity<Employee>().Property(s => s.username).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.password).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.firstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.lastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.address).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.Phone).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(s => s.age).IsRequired();
            modelBuilder.Entity<Employee>().Property(s => s.birthday).IsRequired();
            modelBuilder.Entity<Employee>().Property(s => s.role).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        empId = 1,
                        username = "thanhhai",
                        email = "dohai30112002@gmail.com",
                        password = "111",
                        firstName = "Đỗ Văn",
                        lastName = "Thanh Hải",
                        address = "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk",
                        Phone = "0837418189",
                        age = 20,
                        birthday = new DateTime(2002, 11, 30, 13, 45, 0),
                        role = 1,
                    },
                    new Employee
                    {
                        empId = 2,
                        username = "admin",
                        email = "haido30112002@gmail.com",
                        password = "222",
                        firstName = "Đỗ",
                        lastName = "Hải",
                        address = "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk",
                        Phone = "0837418189",
                        age = 20,
                        birthday = new DateTime(2002, 11, 30, 13, 45, 0),
                        role = 2,
                    });
        }

        public DbSet<Employee> employees { get; set; }
    }
}
