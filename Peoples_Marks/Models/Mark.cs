using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peoples_Marks.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int PeopleId { get; set; }
    }
}