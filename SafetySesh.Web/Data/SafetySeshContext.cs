using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SafetySesh.Web.Data
{
    public class SafetySeshContext : DbContext
    {
        public DbSet<SafetyDiscussion> SafetyDiscussions { get; set; }
    }

    public class SafetyDiscussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string Observer { get; set; }

        public DateTime? Date { get; set; }

        public string Location { get; set; }

        public string Collegue { get; set; }

        public string Subject { get; set; }

        public string Outcomes { get; set; }
    }
}