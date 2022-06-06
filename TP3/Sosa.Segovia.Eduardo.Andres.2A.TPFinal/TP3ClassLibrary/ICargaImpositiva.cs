using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    interface ICargaImpositiva<T>
    {
        float CalcularBonificaciones(T comprador);
        float CalcularImpuesto(T comprador);
    }
}
