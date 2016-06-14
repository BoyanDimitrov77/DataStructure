using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Items
    {
        public string Name{get;set; }
        public int Weight { get; set; }
        public int Cost { get; set; }


        public Items(string name,int weight,int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return string.Format("{0}: weight={1}, cost={2}", this.Name, this.Weight, this.Cost);
        }

    }
}
