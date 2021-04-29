using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NotebookAPI.Models;

namespace NotebookAPI.Controllers
{
    public class ContactTypesController : ApiController
    {
        private PersonContext db = new PersonContext();

        // GET: api/ContactTypes
        public IQueryable<ContactType> GetContactTypes()
        {
            return db.ContactTypes;
        }
                
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}