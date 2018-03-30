using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class AccountController : BaseController
    {
        private IHostingEnvironment _hostingEnvironment;
        private IAppStoreAccountService _appStoreAccountService;

        public AccountController(IHostingEnvironment hostingEnvironment,
            IAppStoreAccountService appStoreAccountService)
        {
            _hostingEnvironment = hostingEnvironment;
            _appStoreAccountService = appStoreAccountService;
        }

        /// <summary>
        /// 账号列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 查询账号列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ListJson([FromBody]AccountQuery query)
        {
            var res = _appStoreAccountService.QueryAccount(query);
            var result = new DataSourceResult()
            {
                rows = res,
                total = res.Count
            };
            return JsonNet(result);
        }

        public IActionResult Export()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // 添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("aspnetcore");
                //添加头
                worksheet.Cells[1, 1].Value = "AppId";
                worksheet.Cells[1, 2].Value = "Password";
                worksheet.Cells[1, 3].Value = "Url";
                //添加值
                worksheet.Cells["A2"].Value = 1000;
                worksheet.Cells["B2"].Value = "LineZero";
                worksheet.Cells["C2"].Value = "http://www.cnblogs.com/linezero/";

                worksheet.Cells["A3"].Value = 1001;
                worksheet.Cells["B3"].Value = "LineZero GitHub";
                worksheet.Cells["C3"].Value = "https://github.com/linezero";
                worksheet.Cells["C3"].Style.Font.Bold = true;

                package.Save();
            }
            return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
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
                var accounts = new List<AppStoreAccount>();
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                int appIdCol = 0;
                int passwordCol = 0;

                for (int i = 1; i < rowCount; i++)
                {
                    if (worksheet.Cells[1, i].Value.ToString() == "AppId")
                    {
                        appIdCol = i;
                    }
                    else if (worksheet.Cells[1, i].Value.ToString() == "Password")
                    {
                        passwordCol = i;
                    }
                }

                if (appIdCol == 0)
                    throw new ArgumentException("该excel中不存在AppId列");
                if (passwordCol == 0)
                    throw new ArgumentException("该excel中不存在Password列");

                for (int row = 2; row <= rowCount; row++)
                {
                    var account = new AppStoreAccount()
                    {
                        AppId = worksheet.Cells[row, appIdCol].Value.ToString(),
                        Password = worksheet.Cells[row, passwordCol].Value.ToString()

                    };
                    accounts.Add(account);
                }
                _appStoreAccountService.BatchSaveAppStoreAccounts(accounts);
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult Delete(int id)
        {
            _appStoreAccountService.Delete(id);
            return ReturnResult.Success();
        }
    }
}