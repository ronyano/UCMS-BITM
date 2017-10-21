using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class EnrollInACourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
         ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }
    }
}