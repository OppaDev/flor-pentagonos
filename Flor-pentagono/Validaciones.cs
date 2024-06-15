using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flor_pentagono
{
    public class Validaciones
    {
        //validar que es numero float y es positivo
        public static bool ladoPositivo(string lado)
        {
            float num;
            if (float.TryParse(lado, out num))
            {
                if (num > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool mayorAlVisible(string lado)
        {
            float.TryParse(lado, out float num);
            if (num > 31)
            {
                return true;
            }
            return false;
        }
    }
}
