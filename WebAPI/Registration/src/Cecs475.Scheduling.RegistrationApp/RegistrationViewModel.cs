using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.RegistrationApp
{

    public class SemesterTermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ToString()
        {
            return Name;
        }
    }

    public class CourseSectionDto
    {
        public int Id { get; set; }
        public int SemesterTermId { get; set; }
        public Catalogcourse CatalogCourse { get; set; }
        public int SectionNumber { get; set; }

        public string ToString()
        {
            return CatalogCourse.DepartmentName + " " + CatalogCourse.CourseNumber + "-" + SectionNumber;
        }
    }

    public class Catalogcourse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string CourseNumber { get; set; }
        public int[] PrerequisiteCourseIds { get; set; }
    }

    public class RegistrationViewModel
    {
        /// <summary>
        /// A URL path to the registration web service.
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// The full name of the student who is registering.
        /// </summary>
        public string FullName { get; set; }

        public List<CourseSectionDto> SectionList { get; set; }

        public List<SemesterTermDto> SemesterList { get; set; }
    }
}
