using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab
{
    public static class Parameters
    {
        private static readonly string _connectionString =
            "data source=localhost;" +
            "initial catalog=DotrA;" +
            "integrated security=True;" +
            "MultipleActiveResultSets=True;" +
            "App=EntityFramework"
            //+
            //"Server=tcp:dotra.database.windows.net,1433;" +
            //"Initial Catalog=DotrA;" +
            //"Persist Security Info=False;" +
            //"User ID=bstpe2019;" +
            //"Password=tp6a4c06XP79;" +
            //"MultipleActiveResultSets=False;" +
            //"Encrypt=True;" +
            //"TrustServerCertificate=False;" +
            //"Connection Timeout=30;"
            ;
        public static string ConnectionString { get { return _connectionString; } }
    }
}
