using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class ContactMailController : ApiController
    {
        ContactMailManager _contactService = new ContactMailManager(new EfContactMailRepository());

        [HttpGet]
        public List<ContactMail> GetAll()
        {
            return _contactService.GetAll();
        }
        [HttpGet]
        public ContactMail Get(int id)
        {
            return _contactService.Get(id);
        }
        [HttpGet]
        public bool StatusUpdate(int id, short status)
        {
            return _contactService.StatusUpdate(id, status);
        }

        [HttpPut]
        public bool Put(ContactMail entity)
        {
            return _contactService.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _contactService.Delete(id);
        }

        [HttpPost]
        public ApiResponse Add(ContactMail entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _contactService.Add(entity);
            response.Data = entity;
            return response;
        }
    }
}
