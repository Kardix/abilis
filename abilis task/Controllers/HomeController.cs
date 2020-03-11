using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atask.Models;

namespace atask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public IActionResult Index(int matrix_size = 10, string matrix_base = "decimal")
        {
            if (matrix_size > 15)
            {
                matrix_size = 15;
            }
            else if (matrix_size < 3)
            {
                matrix_size = 3;
            }
            var matrix = new Matrix(matrix_size);

            var list = new List<CustomModel>
            {
                new CustomModel { Value = "X", XAxis = null, YAxis = null }
            };
            for (int i = 1; i < matrix_size + 1; i++)
            {
                list.Add(new CustomModel { Value = i.ToString(), XAxis = null, YAxis = null, IsPrime = PrimeHelper.IsPrime(i)});
            }
            matrix.Values.Add(list);
            for (int i = 1; i < matrix_size + 1; i++)
            {
                list = new List<CustomModel>
                {
                    new CustomModel { Value = i.ToString(), XAxis = null, YAxis = null, IsPrime = PrimeHelper.IsPrime(i) }
                };
                for (int j = 1; j < matrix_size + 1; j++)
                {
                    switch (matrix_base)
                    {
                        case "hex":
                            list.Add(new CustomModel { Value = (i * j).ToString("X"), XAxis = i, YAxis = j, IsPrime = PrimeHelper.IsPrime(i * j) });
                            break;
                        case "binary":
                            list.Add(new CustomModel { Value = Convert.ToString((i * j), 2), XAxis = i, YAxis = j, IsPrime = PrimeHelper.IsPrime(i * j) });
                            break;
                        default:
                            list.Add(new CustomModel { Value = (i * j).ToString(), XAxis = i, YAxis = j, IsPrime = PrimeHelper.IsPrime(i * j) });
                            break;
                    }
                }
                
matrix.Values.Add(list);
            }
            
                return View(matrix);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
