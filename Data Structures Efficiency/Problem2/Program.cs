using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem2
{
    class Article:IComparable<Article>

    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }


        public Article(string title,decimal price,string vendor,string barcode="0")
        {
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
            this.Barcode = barcode;

        }

        public int CompareTo(Article other)
        {
            return string.Compare(this.Title, other.Title);
        }

        public override string ToString()
        {
            return string.Join("; ", "Title:" + this.Title, "Price:" + this.Price, "Vendor:" + this.Vendor, "Barcode:" + this.Barcode);
        }


    }



    class Program
    {

        public static OrderedMultiDictionary<decimal, Article> byRange = new OrderedMultiDictionary<decimal, Article>(true);


        public static void AddElement(string title,decimal price,string vendor)
        {
            var article = new Article(title, price, vendor);
            byRange[price].Add(article);

        }

        public static string findByPriceArticle(decimal min,decimal max)
        {
            var result = byRange.Range(min, true, max, true).Values.OrderBy(p => p.Price);

            return string.Join(Environment.NewLine, result);


        }


        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("input.txt"));
#endif

            var output = new StringBuilder();

            for (string line = null; (line = Console.ReadLine()) != null;)
            {
                var match = line.Split(new[] { ' ' }, 2);
                var name = match[0];
                var parameters = match[1].Split(';');

                string result = null;

                switch (name)
                {
                    case "AddProduct":
                        AddElement(title: parameters[0], price: decimal.Parse(parameters[1]),vendor:parameters[2]);
                        break;

                    case "FindProductsByPriceRange":
                        result = findByPriceArticle(min: decimal.Parse(parameters[0]), max: decimal.Parse(parameters[1]));
                        break;

                    default:
                        throw new ArgumentException("Invalid command: " + name);
                }

                output.AppendLine(line);
                output.AppendLine(result);
                output.AppendLine();
            }

            Console.Write(output);
        


    }
    }
}
