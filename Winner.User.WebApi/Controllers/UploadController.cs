using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.User.Api.Models;
using Winner.User.Entities;
using Winner.WebApi.Contract;
using Javirs.Common;
using Winner.FileSystem.Client;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;

namespace Winner.User.Api.Controllers
{
    public class UploadController : ApiControllerBase
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        // 检查文件是否存在
        public JsonResult CheckExists(List<FileHashInfo> hashlist)
        {
            FileSystemClient client = new FileSystemClient(AppConfig.FileSystem_AppID, AppConfig.FileSystem_AppSecret);
            string[] hashcodes = new string[hashlist.Count];
            int[] sizes = new int[hashlist.Count];
            for (int i = 0; i < hashlist.Count; i++)
            {
                var item = hashlist[i];
                hashcodes[i] = item.HashCode;
                sizes[i] = item.Size;
            }
            return Json(client.CheckFile(hashcodes, sizes));
        }
        // 上传文件到服务器
        public JsonResult Service()
        {
            List<IPostFileData> list = new List<IPostFileData>();
            foreach (string key in Request.Files.Keys)
            {
                HttpPostedFileBase file = Request.Files[key];
                string filename = file.FileName;
                if (filename.IndexOf(".") < 0)
                {
                    filename = filename + ".jpg";
                }
                byte[] filebytes = new byte[file.ContentLength];
                file.InputStream.Read(filebytes, 0, filebytes.Length);
                PostFileData data = new PostFileData();
                data.FileName = file.FileName;
                data.Name = key;
                data.Value = filebytes;

                list.Add(data);
            }
            Log.Info("收到图片{0}张", list.Count);
            if (list.Count <= 0)
            {
                return Json(FuncResult.FailResult("请上传图片", (int)ApiStatusCode.BAD_REQUEST));
            }
            FileSystemClient client = new FileSystemClient(AppConfig.FileSystem_AppID, AppConfig.FileSystem_AppSecret);
            var res = client.UploadFile(list.ToArray());
            return Json(res);
        }
    }
}