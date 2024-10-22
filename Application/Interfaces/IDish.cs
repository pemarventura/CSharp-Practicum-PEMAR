using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDish
    {
        public string ValidateAndTrimDishesStringFormat(string unparsedOrder);

        public string GenerateDishAndConvertToString(string dishName, int dishCount);

    }
}
