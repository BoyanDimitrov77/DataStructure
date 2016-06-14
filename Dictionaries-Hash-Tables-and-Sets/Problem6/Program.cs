using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
namespace Problem6
{
    class PhoneBook
    {
        public string Name { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }

        public const string Separator = "|";
        public PhoneBook(string name, string town, string phoneNum)
        {
            this.Name = name;
            this.Town = town;
            this.PhoneNumber = phoneNum;
        }

        public override string ToString()
        {
            return string.Join(PhoneBook.Separator, this.Name, this.Town, this.PhoneNumber);
        }
    }



    class Program
    {
        static MultiDictionary<string, PhoneBook> byName = new MultiDictionary<string, PhoneBook>(true);
        static MultiDictionary<Tuple<string,string>, PhoneBook> byNameAndTown = new MultiDictionary<Tuple<string,string>, PhoneBook>(true);


       public static void Add(string name,string town,string phone)
        {

            var obj = new PhoneBook(name, town, phone);

            var TownAndName = new Tuple<string, string>(obj.Name, obj.Town);
            byName.Add(name, obj);
            byNameAndTown.Add(TownAndName, obj);


        }

        static IEnumerable<PhoneBook> Find(string name)
        {
            return byName[name];
        }

        static IEnumerable<PhoneBook> Find(string name, string town)
        {
            var nameAndTown = new Tuple<string, string>(name, town);

            return byNameAndTown[nameAndTown];
        }

        static void Main()
        {
            using (var input = new StreamReader("../../input.txt"))
            {
                for (string line = null; (line = input.ReadLine()) != null;)
                {
                    var parts = line.Split(new[] { PhoneBook.Separator }, StringSplitOptions.None)
                        .Select(entry => entry.Trim())
                        .ToArray();

                    Add(parts[0], parts[1], parts[2]);
                }
            }

            using (var input=new StreamReader("../../comand.txt"))
            {

                for(string line= null; (line = input.ReadLine()) != null;)
                {
                    string[] part = line.Split(' ','(',')',',');
                    Console.WriteLine(string.Join(Environment.NewLine, Find(part[1])));

                    Console.WriteLine(string.Join(Environment.NewLine, Find(part[1],part[2])));
                }

            }

               // Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho")));

           // Console.WriteLine();

            //Console.WriteLine(string.Join(Environment.NewLine, Find("Bat Gancho", "Sofia")));
        }
    }
}
