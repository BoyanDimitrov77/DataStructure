using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraverseDirectory
{
    class TraverseDirectory
    {
        private const string PATH = @"C:\Windows";
        private const string MASK = ".exe";

        public static void TraverseDirectoryL(string path)
        {
            try
            {
                foreach (var item in Directory.GetFiles(path).Where(file=>file.EndsWith(MASK))) 
                {
                    Console.WriteLine(item);
                }

                foreach (var directory in Directory.GetDirectories(path))
                {
                    TraverseDirectoryL(directory);
                }


            }catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void Main(string[] args)
        {

            TraverseDirectoryL(PATH);
        }
    }
}
