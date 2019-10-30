using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PVCController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {

            string str = GetFileInfo();

            return str;
        }

        public string GetFileInfo()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            DirectoryInfo dir = new DirectoryInfo("/mnt/azurediskdata");            

            if (dir.Exists)
            {
                var file = new FileInfo(Path.Combine(dir.FullName, "ReadMe.txt"));

                if (!file.Exists)
                {
                    using (Stream stream = file.OpenWrite())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.WriteLine("This is a sample text message from a file named ReadMe.txt created at a mounted path");
                            writer.WriteLine("Path of the mounted volume is /mnt/azurediskdata");

                            writer.WriteLine("");
                            writer.WriteLine("");
                            
                            writer.WriteLine("To view the file's contents using Cloud Shell, execute the following commands:");
                            writer.WriteLine("$kubectl exec -it <pod name> --/bin/bash");
                            writer.WriteLine("$cd /mnt/azurediskdata");
                            writer.WriteLine("$cat ReadMe.yaml");
                        }
                    }                    
                }

                foreach (System.IO.FileInfo fi in dir.GetFiles())
                {
                    if (fi.Name.Equals("ReadMe.txt"))
                    {
                        using (System.IO.StreamReader reader = fi.OpenText())
                        {
                            sb.AppendLine(reader.ReadToEnd());
                        }
                    }
                }
            }

            return sb.ToString();
        }


        public string SaveToFile(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            DirectoryInfo dir = new DirectoryInfo("/mnt/azurediskdata");

            if (dir.Exists)
            {
                var file = new FileInfo(Path.Combine(dir.FullName, "file1.txt"));

                using (Stream stream = file.Open(FileMode.Truncate))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(message);

                    }
                }

                foreach (System.IO.FileInfo fi in dir.GetFiles())
                {
                    if (fi.Name.Equals("file1.txt"))
                    {
                        using (System.IO.StreamReader reader = fi.OpenText())
                        {
                            sb.AppendLine(reader.ReadToEnd());
                        }
                    }

                }
            }

            return sb.ToString();
        }
    }
}
