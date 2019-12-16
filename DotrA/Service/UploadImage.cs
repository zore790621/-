using DotrA.Areas.BackEndSystem.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DotrA.Service
{
    public class Upload
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
        /// <summary>
        /// 處理ViewModel裡面形態是HttpPostedFileBase的Property。
        /// 會把此property的檔案儲存到某個路徑下，並且把儲存的路勁寫在對應的Property裡面
        /// </summary>
        /// <param name="viewModel">要處理的ViewModel</param>
        /// <param name="basePath">檔案要儲存位置的base</param>
        public static void ProcessHttpPostFile(string basePath, int inputId, object viewModel)
        {
            var properties = viewModel.GetType()
                  .GetProperties(BindingFlags.Instance |
                 BindingFlags.Public | BindingFlags.FlattenHierarchy);

            foreach (var item in properties
                .Where(x => x.PropertyType == typeof(HttpPostedFileBase)))
            {
                if (item.GetValue(viewModel) is HttpPostedFileBase httpost
                    && string.IsNullOrEmpty(httpost.FileName) == false)
                {
                    // 如果postFile的property名稱後面一定會加File。例如：
                    //CoverImgFile對應的string property名稱就是CoverImg。
                    // 因此看看是否有property的名稱是postFile的名稱減去4（File是4個字）
                    var fileNameProperty = properties
                        .Where(x => x.Name == item.Name.Remove(item.Name.Count() - 4))
                       .FirstOrDefault();

                    if (fileNameProperty != null)
                    {
                        var savePath = Path.Combine(basePath, inputId + httpost.FileName);

                        if (Directory.Exists(Path.GetDirectoryName(savePath)) == false)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        }

                        httpost.SaveAs(savePath);

                        fileNameProperty.SetValue(viewModel, httpost.FileName);
                    }
                }
            }
        }
    }
}