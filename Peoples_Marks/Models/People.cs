using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Peoples_Marks.Models
{
    public class People
    {
        public int Id { get; set; }

        [Index("IX_FullName", 1, IsUnique = true)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Index("IX_FullName", 2, IsUnique = true)]
        public string LastName { get; set; }
    }
}