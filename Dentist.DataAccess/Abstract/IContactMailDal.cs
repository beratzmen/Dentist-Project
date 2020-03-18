using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface IContactMailDal
    {
        ContactMail Get(int id);
        List<ContactMail> GetAll();
        bool Add(ContactMail entity);
        bool Delete(int id);
        bool Update(ContactMail entity);
        bool StatusUpdate(int id,short status);
    }
}
