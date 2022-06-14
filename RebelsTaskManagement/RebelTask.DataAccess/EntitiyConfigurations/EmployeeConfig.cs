using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.EntitiyConfigurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(emp => emp.Id);

            builder.Property(emp => emp.FirstName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(emp => emp.LastName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(emp => emp.Department)
                .WithMany()
                .HasForeignKey(emp => emp.DepartmentId);

            builder.Property(emp => emp.Title)
                .HasColumnType("varchar(100)");

            builder.Property(emp => emp.HireDate)
                .HasColumnType("date");

            builder.Property(emp => emp.LeaveDate)
                .HasColumnType("date");

            builder.HasData
                (
                        new Employee() { Id = 1, FirstName = "Jason", LastName = "Statham", DepartmentId = 1, Title = "Yazılım geliştirici",HireDate=Convert.ToDateTime("01.01.2012") ,LeaveDate=null},
                        new Employee() { Id = 2, FirstName = "Arnold", LastName = "Swatcz", DepartmentId = 1, Title = "Yazılım geliştirici", HireDate = Convert.ToDateTime("05.10.2015"), LeaveDate = null },
                        new Employee() { Id = 3, FirstName = "Bruce", LastName = "Wayne", DepartmentId = 1, Title = "Yazılım geliştirici", HireDate = Convert.ToDateTime("01.05.2014"), LeaveDate =Convert.ToDateTime("01.05.2014") },
                        new Employee() { Id = 4, FirstName = "Bryy", LastName = "Allan", DepartmentId = 2, Title = "İş analisti", HireDate = Convert.ToDateTime("16.08.2014"), LeaveDate = null },
                        new Employee() { Id = 5, FirstName = "Mark", LastName = "Buffalo", DepartmentId = 2, Title = "İş analisti", HireDate = Convert.ToDateTime("16.08.2014"), LeaveDate = Convert.ToDateTime("05.09.2015") },
                        new Employee() { Id = 6, FirstName = "Elvis", LastName = "Presley", DepartmentId = 3, Title = "Grafik tasarımc", HireDate = Convert.ToDateTime("20.02.2018"), LeaveDate = null },
                        new Employee() { Id = 7, FirstName = "Freddie", LastName = "Mercury", DepartmentId = 4, Title = "Proje Yöneticisi", HireDate = Convert.ToDateTime("01.07.2010"), LeaveDate = null },
                        new Employee() { Id = 8, FirstName = "Alan", LastName = "Walker", DepartmentId = 4, Title = "Ar-ge yöneticisi", HireDate = Convert.ToDateTime("01.08.2011"), LeaveDate = null }


                );




        }
    }
}
