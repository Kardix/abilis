using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atask.Models
{
    public class Matrix
    {
        public int Size { get; set; }

        public List<List<CustomModel>> Values { get; set; }

        public Matrix(int size)
        {
            
            Values = new List<List<CustomModel>>(size + 1);
            foreach (var item in Values)
            {
                item.Capacity = size + 1;
            }
        }

        public string Print()
        {
            string result = "";
            foreach (var list in Values)
            {
                foreach (var item in list)
                {
                    result += $"{item.Value} ";
                }
                result += "\n";
            }

            return result;
        }
    }
}
