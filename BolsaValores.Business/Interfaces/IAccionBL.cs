﻿using BolsaValores.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Interfaces
{
    public interface IAccionBL
    {
        Task<AccionDTO> Consultar(string idAccion);
        Task<bool> Registrar(AccionDTO accionDTO);
    }
}
