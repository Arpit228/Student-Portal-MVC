using System;
using System.Collections.Generic;

#nullable disable

namespace Student_Register.Models
{
    public partial class StudentArpit
    {
        public int Rollno { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public int? Cid { get; set; }

        public virtual CourseArpit CidNavigation { get; set; }
    }
}
