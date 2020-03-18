using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.DataAccess.Abstract
{
    public interface ICommentDal
    {
        Comment Get(int id);
        List<Comment> GetAll();
        bool Add(Comment entity);
        void Delete(int id);
        void Update(Comment entity);
    }
}
