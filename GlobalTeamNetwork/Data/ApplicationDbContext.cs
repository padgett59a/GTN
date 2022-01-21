using System;
using System.Collections.Generic;
using System.Text;
using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlobalTeamNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<SemesterCore> SemesterCores { get; set; }
        public DbSet<CourseCore> CourseCores { get; set; }
        public DbSet<SessionCore> SessionCores { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TranslationStep> TranslationSteps { get; set; }
        public DbSet<ExamTranslationStep> ExamTranslationSteps { get; set; }
        public DbSet<MasteringStep> MasteringSteps { get; set; }
        public DbSet<MediaType> MediaTypes {get; set; }
        public DbSet<Person> Persons {get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<TableName> TableNames { get; set; }
        public DbSet<TxLog> TxLogs { get; set; }
    }
}
