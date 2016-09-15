using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace JournalInfo.Models
{
    public class JournalContext:DbContext
    {
        public DbSet<JournalData> JournalEntries { get; set; }
        public DbSet<JAttachments> JAttachments { get; set; }

        public DbSet<Login> Logins { get; set; }

    }
}