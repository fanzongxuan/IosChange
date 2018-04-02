using Change.Common.Core;
using Change.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public interface ICommentsService
    {
        void BatchInsertComments(List<Comment> comments);

        void Delete(int id);

        Comment GetRandom();
        
        IPagedList<Comment> Query(CommentQuery query);

        Comment Add(Comment comment);
    }
}
