using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Peoples_Marks.DAL;
using Peoples_Marks.Models;

namespace Peoples_Marks.Controllers
{
    public class MarksController : ApiController
    {
        private PeopleContext db = new PeopleContext();

        // GET: api/Marks
        public IEnumerable<PeopleDTO> GetMarks()
        {
            List<PeopleDTO> list = new List<PeopleDTO>();

            var peoples = db.Peoples.ToList();
            foreach (var mark in db.Marks)
            {
                var people = peoples.FirstOrDefault(x => x.Id == mark.PeopleId);
                if (people != null)
                {
                    list.Add(new PeopleDTO()
                    {
                        FirstName = people.FirstName,
                        LastName = people.LastName,
                        Value = mark.Value
                    });
                }             
            }

            return list;
        }

        // POST: api/Marks
        [HttpPost]
        public async Task<IHttpActionResult> PostMark([FromBody] PeopleDTO newPeople)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var error = "";

            try
            {
                var neePeople = db.Peoples.Add(new People() { FirstName = newPeople.FirstName, LastName = newPeople.LastName });
                await db.SaveChangesAsync();
                db.Marks.Add(new Mark() { Value = newPeople.Value, PeopleId = neePeople.Id });
                await db.SaveChangesAsync();
            }catch(Exception ex)
            {
                error = "Error on saveng data";
                return BadRequest(error);
            }
            return Ok(newPeople);
        }
    }
}