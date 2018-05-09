using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cecs475.Scheduling.Web.Controllers
{
    public class SemesterTermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static SemesterTermDto From(Model.SemesterTerm term)
        {
            return new SemesterTermDto
            {
                Id = term.Id,
                Name = term.Name
            };
        }
    }

    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private Model.CatalogContext mContext = new Model.CatalogContext();

        //[HttpGet]
        //[Route("")]
        //public IEnumerable<CourseSectionDto> GetCourseSections()
        //{
        //    return mContext.SemesterTerms.Select(CourseSectionDto.From);
        //}

        [HttpGet]
        [Route("{year}/{term}")]
        public IEnumerable<CourseSectionDto> GetCourseSection(String year, String term)
        {
            String termName = term + " "+year;
            var semesterTerm = mContext.SemesterTerms.Where(c => c.Name == termName).SingleOrDefault();

            return GetCourseSection(semesterTerm);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IEnumerable<CourseSectionDto> GetCourseSection(int id)
        {
            var semesterTerm = mContext.SemesterTerms.Where(s => s.Id == id).SingleOrDefault();

            return GetCourseSection(semesterTerm);

        }

        [HttpGet]
        [Route("{terms}")]
        public IEnumerable<SemesterTermDto> GetSemesterTerms()
        {
            var terms = mContext.SemesterTerms.ToList();

            return terms.Select(SemesterTermDto.From);
        }

        private IEnumerable<CourseSectionDto> GetCourseSection(Model.SemesterTerm term)
        {
            if (term == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                HttpStatusCode.NotFound, $"Invalid semester found"));
            }
            return term.CourseSections.Select(CourseSectionDto.From);
        }
    }
}