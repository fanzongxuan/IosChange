using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Data.Data;
using Change.Model;
using Change.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chane.Api.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    public class CommentController : BaseController
    {
        private readonly ICommentsService _commentsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentsService"></param>
        public CommentController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult BatchInsertComments(List<Comment> comments)
        {
            _commentsService.BatchInsertComments(comments);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult Delete(int id)
        {
            _commentsService.Delete(id);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 随机获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<Comment> GetRandom()
        {
            var res = _commentsService.GetRandom();
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<Comment> Add(AddCommentModel comment)
        {
            var entity = new Comment()
            {
                Title = comment.Title,
                Content = comment.Content
            };
            var res = _commentsService.Add(entity);
            return ReturnResult.Success(res);
        }
    }
}