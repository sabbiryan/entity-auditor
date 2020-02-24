using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataSource.Students
{
    public class StudentBase
    {
        [Key]
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }

        public override string ToString()
        {
            return $"{StudentId} ({Name} - {Course})";
        }
    }
}
