using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreeDirectory
{
    class File
    {
        private string name;
        private  int size;

        public File(string name,int size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("File name cannot be null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be negative!");
                }
                else
                {
                    this.size = value;
                }
            }
        }
    }

    class Folder
    {
        private string name;
        private List<File> files;
        private List<Folder> childFolder;

        public Folder(string name)
        {
            this.name = name;
            this.files = new List<File>();
            this.childFolder = new List<Folder>();
        }

        public File[] Files
        {
            get
            {
                return this.files.ToArray();
            }
            
        }

        public Folder[] ChildFolder
        {
            get
            {
                return this.childFolder.ToArray();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("File name cannot be null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }

            
        }
        public void AddFile(File file)
        {
            files.Add(file);
        }
        public void AddFolder(Folder folder)
        {
            childFolder.Add(folder);
        }

        public int CalculateSize()
        {
            int size = 0;

            foreach (var file in files)
            {
                size += file.Size;

            }

            foreach (var folder in this.childFolder)
            {
                size += folder.CalculateSize();
            }
            return size;
        }

        public override string ToString()
        {
            return string.Format("Folder name: {0} -> subfolders count: {1}", this.Name, this.childFolder.Count);
        }

    }
    
    class StartUP
    {

        private const string PATH = @"C:\Windows";

        public static void TraversAllDirectory(string path,Folder folder)
        {
            try { 
      
                foreach (var filename in Directory.GetFiles(path))
                {
                int fileSize = (int)(new FileInfo(filename).Length);
                File file = new File(filename, fileSize);
                folder.AddFile(file);

                }

                foreach (var directoryName in Directory.GetDirectories(path)) 
                {
                    folder.AddFolder(new Folder(directoryName));
                    TraversAllDirectory(directoryName, folder.ChildFolder[folder.ChildFolder.Length - 1]);

                }


            }catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void Main(string[] args)
        {
            Folder root = new Folder(PATH);
            TraversAllDirectory(PATH, root);
            int size = root.CalculateSize();
            Console.WriteLine(size);

        }
    }

}
