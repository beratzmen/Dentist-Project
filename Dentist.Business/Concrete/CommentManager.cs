using Dentist.DataAccess.Abstract;
using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Business.Concrete
{
    public class CommentManager : ICommentDal
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this._commentDal = commentDal;
        }
        public bool Add(Comment entity)
        {
            return _commentDal.Add(entity);
        }

        public void Delete(int id)
        {
            _commentDal.Delete(id);
        }

        public Comment Get(int id)
        {
            return _commentDal.Get(id);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
