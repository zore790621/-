using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA_Lab.InternalDataService;
using DotrA_Lab.InternalDataService.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DotrA.Service
{
    public class Upload
    {
        #region 塞interface
        private readonly IImageBaseService _imgdb;
        public Upload(IImageBaseService all) { this._imgdb = all; }
        #endregion
        public void UploadImage(string trail, int inputId, IEnumerable<HttpPostedFileBase> photo)
        {
            string folderPath = HttpContext.Current.Server.MapPath(trail);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (var item in photo)
            {
                if (item != null && item.ContentLength > 0)
                {
                    string ext = Path.GetExtension(item.FileName);
                    string filename = Path.GetFileNameWithoutExtension(item.FileName);
                    string guidname = Guid.NewGuid().ToString();
                    string picName = inputId + "_" + guidname + "_" + filename + ext;
                    string path = Path.Combine(folderPath, picName);
                    item.SaveAs(path);
                    var todatabase = new BESImageViewModel();
                    todatabase.ImageName = filename;
                    todatabase.ImageUrl = trail + "/" + picName;
                    if (trail == "~/Assets/Images/Category")
                        todatabase.CatgoryID = inputId;
                    else if (trail == "~/Assets/Images/Product")
                        todatabase.ProductID = inputId;

                    _imgdb.CreateViewModelToDatabase<BESImageViewModel>(todatabase);
                }
            }
        }
    }
}