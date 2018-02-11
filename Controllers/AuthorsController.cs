using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class AuthorsController : Controller
    {
        private readonly BookstoreContext db;

        public AuthorsController(BookstoreContext db)
        {
            this.db = db;

            if (this.db.Authors.Count() == 0)
            {
                this.db.Authors.Add(new Author {
                    id = 1,
                    FName = "George",
                    LName = "Smith"
                });

                this.db.Authors.Add(new Author {
                    id = 2,
                    FName = "Aaron",
                    LName = "Crawford"
                });
                this.db.SaveChanges();
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetById(int id)
        {
            var Author = db.Authors.Find(id);

            if(Author == null)
            {
                return NotFound();
            }
            return Ok(Author);
        }
    
         [HttpPost]
         public IActionResult Post([FromBody]Author author)
         {
             if(author == null)
             {
                 return BadRequest();
             }

             this.db.Authors.Add(author);
             this.db.SaveChanges();

             return CreatedAtRoute("GetAuthor", new {id = author.id}, author);
         }

         [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody]Author newAuthor)
         {
             if (newAuthor == null || newAuthor.id != id)
             {
                 return BadRequest();
             }
             var currentAuthor = this.db.Authors.FirstOrDefault(x => x.id == id);

             if (currentAuthor == null)
             {
                 return NotFound();
             }

             currentAuthor.FName = newAuthor.FName;
             currentAuthor.LName = newAuthor.LName;
             currentAuthor.Publisher = newAuthor.Publisher;

             this.db.Authors.Update(currentAuthor);
             this.db.SaveChanges();

             return NoContent();
         }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = this.db.Authors.FirstOrDefault(x => x.id == id);

            if(author == null)
            {
                return NotFound();
            }

            this.db.Authors.Remove(author);
            this.db.SaveChanges();

            return NoContent();
        }
    }
    
}
