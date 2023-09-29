using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Interfaces
{
    public interface IBotBL
    {
        void RecibirMensaje();
        string ResponderMensaje();
    }
}
