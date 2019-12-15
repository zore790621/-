using DotrA.Areas.BackEndSystem.ViewModels;
using System;
using System.IO;
using System.Web;

namespace DotrA.Service
{
    public static class Upload
    {
        public static string UploadImage(string trail, int inputId, HttpPostedFileBase photo)
        {
            string folderPath = HttpContext.Current.Server.MapPath(trail);
            string picName = string.Empty;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (photo != null && photo.ContentLength > 0)
            {
                string ext = Path.GetExtension(photo.FileName);
                picName = "acotor_" + inputId + ext;
                string path = Path.Combine(folderPath, picName);
                photo.SaveAs(path);
            }
            return picName;
        }
    }
}