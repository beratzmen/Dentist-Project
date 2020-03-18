using Dentist.DataAccess.Abstract;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class ContactMailManager : IContactMailDal
    {
        IContactMailDal _contactMailDal;
        public ContactMailManager(IContactMailDal contactMailDal)
        {
            this._contactMailDal = contactMailDal;
        }
        public bool Add(ContactMail entity)
        {
            return _contactMailDal.Add(entity);
        }

        public bool Delete(int id)
        {
            return _contactMailDal.Delete(id);
        }

        public ContactMail Get(int id)
        {
            return _contactMailDal.Get(id);
        }

        public List<ContactMail> GetAll()
        {
            return _contactMailDal.GetAll();
        }

        public bool Update(ContactMail entity)
        {
            return _contactMailDal.Update(entity);
        }

        public bool StatusUpdate(int id, short status)
        {
            return _contactMailDal.StatusUpdate(id, status);
        }
    }
}
