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

        public DbSet<Language> Languages { get; set; }
        public DbSet<TranslationStep> TranslationSteps { get; set; }
        public DbSet<MasteringStep> MasteringSteps { get; set; }
        public DbSet<MediaType> MediaTypes {get; set; }
    }
}
