using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JournalInfo.Models
{
    public class JournalData
    { 
        public int ID { get; set; }
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string BodyData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? JournalDate { get; set; }

        public virtual ICollection<JAttachments> JAttachments { get; set; }
    }

    public class JAttachments
    {
        public int ID { get; set; }     
        public string FilePath { get; set; }
        public string FileName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AttachedDate { get; set; }

        public virtual JournalData Journal { get; set; }

    }



}