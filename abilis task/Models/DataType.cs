using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atask
{
    public enum DataType
    {
        [Display(Name = "Decimal")]
        Decimal = 1,
        [Display(Name = "Binary")]
        Binary = 2,
        [Display(Name = "Hex")]
        Hex = 3,
    }
}
