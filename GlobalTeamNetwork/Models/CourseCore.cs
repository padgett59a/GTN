using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class CourseCoreSName //Course Object having Semester Name (vice SemsterCode)
    {
        [Key]
        public Int32 CourseCoreID { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public string CourseLetterCode { get; set; }
        public Int16? CourseNumberCode { get; set; }
        public Boolean HasWorkbook { get; set; }
        public Boolean HasVideoText { get; set; }
        public string? InstructorName { get; set; }
        public Boolean VideosInHand { get; set; }
        public Boolean MasteringFilesInHand { get; set; }
        public Boolean TextFilesInHand { get; set; }
        public string? Notes { get; set; }
    }

/*
     CourseCoreID
     CourseName
     SemesterCode
     CourseLetterCode
     CourseNumberCode
     HasWorkbook
     HasVideoText
     InstructorID
     VideosInHand
     MasteringFilesInHand
     TextFilesInHand
     Notes
*/


    public class CourseCore
    {
        [Key]
        public Int32 CourseCoreID { get; set; }
        public string CourseName { get; set; }
        public string SemesterCode { get; set; }
        public string CourseLetterCode { get; set; }
        public Int16? CourseNumberCode { get; set; }
        public Boolean HasWorkbook{ get; set; }
        public Boolean HasVideoText { get; set; }
        public Int32? InstructorID { get; set; }
        public Boolean VideosInHand { get; set; }
        public Boolean MasteringFilesInHand { get; set; }
        public Boolean TextFilesInHand { get; set; }
        public string Notes { get; set; }
    }
}
