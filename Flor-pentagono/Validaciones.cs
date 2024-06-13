using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flor_pentagono
{
    public class Validaciones
    {
        //es doble positivo 
        public static bool ladoPositivo(string lado)
        {
            double l;
            if (double.TryParse(lado, out l))
            {
                if (l > 0)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
