using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Data.Data;
using Change.Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Change.Web.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentsService _commentsService;
        private IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="commentsService"></param>
        public CommentController(ICommentsService commentsService,
            IHostingEnvironment hostingEnvironment)
        {
            _commentsService = commentsService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ListJson([FromBody]CommentQuery query)
        {
            var res = _commentsService.Query(query);
            var result = new DataSourceResult()
            {
                rows = res,
                total = res.TotalCount
            };
            return JsonNet(result);
        }

        [HttpGet]
        public ReturnResult Delete(int id)
        {
            _commentsService.Delete(id);
            return ReturnResult.Success();
        }

        [HttpPost]
        public IActionResult Import(IFormFile excelfile)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
            {
                excelfile.CopyTo(fs);
                fs.Flush();
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var comments = new List<Comment>();
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                int titleCol = 0;
                int contentCol = 0;

                for (int i = 1; i <= colCount; i++)
                {
                    if (worksheet.Cells[1, i].Value.ToString().Trim().ToLower() == "title")
                    {
                        titleCol = i;
                    }
                    else if (worksheet.Cells[1, i].Value.ToString().Trim().ToLower() == "content")
                    {
                        contentCol = i;
                    }
                }

                if (titleCol == 0)
                    throw new ArgumentException("该excel中不存在title列");
                if (contentCol == 0)
                    throw new ArgumentException("该excel中不存在content列");

                for (int row = 2; row <= rowCount; row++)
                {
                    var comment = new Comment()
                    {
                        Title = worksheet.Cells[row, titleCol].Value.ToString(),
                        Content = worksheet.Cells[row, contentCol].Value.ToString()

                    };
                    comments.Add(comment);
                }
                _commentsService.BatchInsertComments(comments);
                return RedirectToAction("List");
            }
        }
    }
}