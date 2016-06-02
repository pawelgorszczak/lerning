using System.Data.Entity;

namespace EntityFrameworkSchoolDB.Model
{
    internal class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("name=SchoolDbConnectionString")
        {
            Database.SetInitializer<SchoolDbContext>(new DropCreateDatabaseAlways<SchoolDbContext>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
         /*
        modelBuilder.Entity<Student>().Map(delegate(EntityMappingConfiguration<Student> studentConfiguration)
        {
            studentConfiguration.Properties(p => new { p.StudentId, p.StudentName });
            studentConfiguration.ToTable("StudentInfo");

        });
        Action<EntityMappingConfiguration<Student>> studentMappingAction = m =>
        { 
            m.Properties(p => new { p.StudentId, p.Height, p.Weight, p.Photo, p.DateOfBirth });
            m.ToTable("StudentInfoDetail");

        };
        modelBuilder.Entity<Student>().Map(studentMappingAction);
        modelBuilder.Entity<Standard>().ToTable("StandardInfo");
        */
        /*
        //Configure default schema
        modelBuilder.HasDefaultSchema("Admin");

        //Map entity to table
        modelBuilder.Entity<Student>().ToTable("StudentInfo");
        modelBuilder.Entity<Standard>().ToTable("StandardInfo", "dbo");
        */
        //{

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //}
    }
}