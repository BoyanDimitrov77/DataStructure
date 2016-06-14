using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using Product = System.Tuple<string, decimal>;

class Program
{
    static OrderedMultiDictionary<decimal, Product> byPrice =
        new OrderedMultiDictionary<decimal, Product>(true);

    static string FindProductsByPriceRange(decimal min, decimal max)
    {
        var result = byPrice.Range(min, true, max, true).Values.OrderBy(p => p.Item2);

        if (!result.Any())
            return "No products found";

        return string.Join(Environment.NewLine, result);
    }

    static string AddProduct(string name, decimal price)
    {
        var product = new Product(name, price);
        byPrice[price].Add(product);

        return "Product added";
    }

    static void Main()
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
                    result = AddProduct(name: parameters[0], price: decimal.Parse(parameters[1]));
                    break;

                case "FindProductsByPriceRange":
                    result = FindProductsByPriceRange(min: decimal.Parse(parameters[0]), max: decimal.Parse(parameters[1]));
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


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Wintellect.PowerCollections;

//namespace Problem2

//{
//    class largeCollectionOfProductRange
//    {
//        public class Product
//        {
//            public string Name { get; set; }
//            public decimal Price { get; set; }
//            public decimal Min { get; set; }
//            public decimal Max { get; set; }

//            public Product(string name,decimal price)
//            {
//                this.Name = name;
//                this.Price = price;
//            }




//        }

//        public static OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);

//        public static string FindProducyByPriceRange(decimal min,decimal max)
//        {

//            var resultByrange = byPrice.Range(min,true, max,true).Values.OrderBy(p => p.Price);

//            if (resultByrange.Any())
//            {
//               return "There is no product in thin price range";
//            }

//            return string.Join( Environment.NewLine,resultByrange);

//        }


//        public   static string  Add(string name,decimal price)
//        {

//            var product = new Product(name, price);

//            byPrice[price].Add(product);

//            return "Add product";
//        }




//        static void Main(string[] args)
//        {
//            using (var input = new StreamReader("input.text"))
//            {

//                for (string line = null; (line = input.ReadLine()) != null;)
//                {

//                    var match = line.Split(new[] { ' ' }, 2);
//                    var name = match[0];
//                    var option = match[1].Split(';');

//                    string ouput = null;

//                    switch (name)
//                    {
//                        case "Add":

//                            ouput = Add(name: option[0], price: decimal.Parse(option[1]));
//                            break;
//                        case "Find":
//                            ouput = FindProducyByPriceRange(min: decimal.Parse(option[0]), max: decimal.Parse(option[1]));
//                            break;

//                        default:
//                            throw new ArgumentException("Invalid command: " + name);
//                    }

//                    Console.WriteLine(ouput);

//                }

//            }
//            }
//        }
//}
