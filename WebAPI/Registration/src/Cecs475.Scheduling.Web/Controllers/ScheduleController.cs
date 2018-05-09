using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cecs475.Scheduling.Web.Controllers
{
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

            var semesterTerm = mContext.SemesterTerms.Where(c => c.Name == year).SingleOrDefault();

            if (semesterTerm == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                HttpStatusCode.NotFound, $"Invalid semester found"));
            }
            return IEnumerable<CourseSectionDto.From(semesterTerm.CourseSections)>;
        }

        [HttpGet]
        [Route("{id:int")]
        public IEnumerable<CourseSectionDto> GetCourseSection(int id)
        {
            var semesterTerm = mContext.SemesterTerms.Where(s => s.Id == id).SingleOrDefault();

        }
    }
}