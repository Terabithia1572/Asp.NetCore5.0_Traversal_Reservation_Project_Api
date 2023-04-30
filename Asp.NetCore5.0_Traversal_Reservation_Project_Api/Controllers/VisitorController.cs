using Asp.NetCore5._0_Traversal_Reservation_Project_Api.DAL.Context;
using Asp.NetCore5._0_Traversal_Reservation_Project_Api.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Traversal_Reservation_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        VisitorContext visitorContext = new();
        [HttpGet]
        public IActionResult VisitorList()
        {
            var values = visitorContext.Visitors.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            visitorContext.Add(visitor);
            visitorContext.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            var values = visitorContext.Visitors.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            var values = visitorContext.Visitors.Find(id);
            if(values==null)
            {
                return NotFound();

            }
            else
            {
                visitorContext.Remove(values);
                visitorContext.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            var values = visitorContext.Find<Visitor>(visitor.VisitorID);
            if(values==null)
            {
                return NotFound();
            }
            else
            {
                values.Name = visitor.Name;
                values.Surname = visitor.Surname;
                values.Mail = visitor.Mail;
                values.City = visitor.City;
                values.Country = visitor.Country;
                visitorContext.Update(values);
                visitorContext.SaveChanges();
                return Ok();
            }
        }
    }
}
