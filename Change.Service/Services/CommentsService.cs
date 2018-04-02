using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Change.Common.Core;
using Change.Data;
using Change.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Change.Service.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ChangeDbContext _dbContext;

        public CommentsService(ChangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BatchInsertComments(List<Comment> comments)
        {
            if (comments == null || comments.Count == 0)
                throw new ArgumentNullException("comments不能为空！");

            foreach (var comment in comments)
            {
                comment.CreateTime = DateTime.Now;
                _dbContext.Comment.Add(comment);
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id不能为0");
            var comment = _dbContext.Comment.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            comment.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public Comment GetRandom()
        {
            string sql = $"select *from Comment where isdeleted=false order by rand() limit 1";
            var res = _dbContext.Set<Comment>().FromSql(sql).FirstOrDefault();
            if(res!=null)
              Delete(res.Id);
            return res;
        }

        public IPagedList<Comment> Query(CommentQuery query)
        {
            var queryable = _dbContext.Comment.AsQueryable().Where(x => x.IsDeleted == false);
            if (!string.IsNullOrWhiteSpace(query.Title))
                queryable = queryable.Where(x => x.Title.Contains(query.Title));

            return new PagedList<Comment>(queryable, query.PageIndex, query.PageSize);
        }

        public Comment Add(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException("comment不能为空");
            comment.CreateTime=DateTime.Now;
            _dbContext.Comment.Add(comment);
            _dbContext.SaveChanges();
            return comment;
        }
    }
}
