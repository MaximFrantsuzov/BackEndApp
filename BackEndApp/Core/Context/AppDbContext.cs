using BackEndApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Core.Context
{
    public class AppDbContext : DbContext
    {
        //Класс контекста данных, создание БД sql   с помощью миграции
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
        }
        public DbSet<Departament> Departamentes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HistoryDepartament> HistoryDepartamentes { get;set; }
        public DbSet<HistorySubdivision> HistorySubdivisions { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
      
 
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<WorkActivity> WorkActivities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departament>()
                .HasOne(departament => departament.Subdivision)
                .WithMany(subdivision => subdivision.Departaments)
                .HasForeignKey(departament => departament.SubdivisionId);
                
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Departament)
                .WithMany(departament=> departament.Employees)
                .HasForeignKey(employee => employee.DepartamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.JobTitle)
                .WithMany(jobtitle => jobtitle.Employees)
                .HasForeignKey(employee => employee.TitleJobId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<HistoryDepartament>()
                .HasOne(historydepartament => historydepartament.Departament)
                .WithMany(departament => departament.HistoryDepartaments)
                .HasForeignKey(historydepartament => historydepartament.DepartamentId);

            modelBuilder.Entity<HistorySubdivision>()
                .HasOne(historysubdivision => historysubdivision.Subdivision)
                .WithMany(subdivision => subdivision.HistorySubdivisions)
                .HasForeignKey(historysubdivision => historysubdivision.SubdivisionId);

           

            modelBuilder.Entity<WorkActivity>()
                .HasOne(workactivity => workactivity.Employee)
                .WithMany(employee => employee.WorkActivities)
                .HasForeignKey(workactivity => workactivity.EmployeeId);

            modelBuilder.Entity<WorkActivity>()
                .HasOne(workactivity => workactivity.Departament)
                .WithMany(departament => departament.WorkActivities)
                .HasForeignKey(workactivity => workactivity.DepartamentId);

           

            modelBuilder.Entity<Employee>()
                .Property(employee => employee.Sex)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(employee => employee.LevelEducation)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Departament)
                .WithMany(departament => departament.Employees)
                .HasForeignKey(employee => employee.DepartamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
          
         

          
          
            modelBuilder.Entity<HistoryDepartament>()
                .Property(historydepartament => historydepartament.TypeEventDepSub)
                .HasConversion<string>();

            modelBuilder.Entity<HistorySubdivision>()
                .Property(historysubdivision => historysubdivision.TypeEventDepSub)
                .HasConversion<string>();

          

        }
     
       
    }
}
