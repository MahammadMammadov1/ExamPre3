using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Business.Helper
{
    public static class Helper
    {
        public static string SaveFile(string root , string folder,IFormFile file)
        {
            string fileNames = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;

            string newfileNames = Guid.NewGuid().ToString() + fileNames;

            string path = Path.Combine(root,folder, newfileNames);

            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newfileNames;
        }
    }
}
