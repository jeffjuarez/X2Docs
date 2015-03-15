using DataLayer;
using DataLayer.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private DrakeContext _ctx = new DrakeContext();
        private IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(_ctx);
        }

        public ActionResult Index()
        {
            var uploadedFiles = _unitOfWork.Repository<FileUpload>()
                .Query()
                .Get()
                .Select(t => new FileUploadModel()
                {
                    ID = t.FileUploadID,
                    FileName = t.FileName,
                    FileType = t.FileType,
                })
                .ToList();

            ViewBag.UploadedFiles = uploadedFiles;
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile != null)
            {
                // convert to byte[], and it should be put on a helper
                Stream fileStream = uploadedFile.InputStream;
                var mStreamer = new MemoryStream();
                mStreamer.SetLength(fileStream.Length);
                fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
                mStreamer.Seek(0, SeekOrigin.Begin);
                byte[] fileBytes = mStreamer.GetBuffer();

                var fileUpload = new FileUpload()
                {
                    FileName = uploadedFile.FileName,
                    FileType = System.IO.Path.GetExtension(uploadedFile.FileName).Substring(1),
                    FileContent = fileBytes,
                    State = ObjectState.Added,
                };

                _unitOfWork.Repository<FileUpload>()
                    .InsertGraph(fileUpload);

                if (_unitOfWork.Save())
                {
                    // TODO: 
                }
            }
                
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var file = _unitOfWork.Repository<FileUpload>()
                .FindById(id);

            if (file != null)
            {
                file.State = ObjectState.Deleted;
                _unitOfWork.Repository<FileUpload>()
                    .Delete(file);

                if (_unitOfWork.Save())
                {
                    // TODO: 
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult PreviewFile(int id)
        {
            var file = _unitOfWork.Repository<FileUpload>()
                .FindById(id);

            Dictionary<string, string> contentTypes = new Dictionary<string, string>();
            contentTypes.Add("pdf", "application/pdf");
            contentTypes.Add("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            contentTypes.Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            contentTypes.Add("html", "text/html");
            contentTypes.Add("txt", "text/plain");
            contentTypes.Add("png", "image/png");
            contentTypes.Add("jpeg", "image/jpeg");
            contentTypes.Add("jpg", "image/jpeg");
            contentTypes.Add("gif", "image/gif");

            // Force the pdf document to be displayed in the browser
            Response.AppendHeader("Content-Disposition", "inline; filename=" + file.FileName + ";");
            return File(file.FileContent, contentTypes[file.FileType]);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}