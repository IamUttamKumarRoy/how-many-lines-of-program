using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLineCounter
{
    class FileManagement
    {
        public string[] getFileList( string directoryname,string file_type )
        {
            List<string> list = new List<string>();
            try
            {
                if (Directory.Exists(@"" + directoryname))
                {
                    DirectoryInfo d = new DirectoryInfo(@"" + directoryname);
                    FileInfo[] Files = d.GetFiles( "*."+ file_type );

                    foreach (FileInfo file in Files)
                    {
                        list.Add(file.Name);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return list.ToArray();
        }
        public int getLineCountOfFile( string file_path )
        {
            int lineCount = 0;
            string temp ="";
            using ( var reader = File.OpenText( @"" + file_path ) )
            {
                while (reader.ReadLine() != null)
                {
                    temp = reader.ReadLine();
                    if ( !string.IsNullOrEmpty(temp) )
                    {
                        lineCount++;
                    }
                }
            }
            return lineCount;
        }
    }
}
