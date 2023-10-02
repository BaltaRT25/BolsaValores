using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Data
{
    public class HistorialDAL : IHistorialDAL
    {
        public HistorialDAL(IConfiguration configuracion) 
        {
            Configuracion = configuracion;
        }
        public IConfiguration Configuracion { get; }

        public async Task<int> CalcularTotalHistorialPorUsuario(string correoUsuario)
        {
            int total = 0;
            try
            {
                string sql = "SPCalcularTotalHistorialPorUsuario";
                var parametros = new { correoUsuario = correoUsuario };
                using (var conexion = new SqlConnection(Configuracion.GetConnectionString("BolsaValores")))
                {
                    total = await conexion.ExecuteScalarAsync<int>(sql, parametros, commandType: CommandType.StoredProcedure);
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return total;
        }

        public async Task<List<Historial>> ObtenerHistorialPorUsuario(string correoUsuario, int omitir, int tomar)
        {
            var historial = new List<Historial>();
            try
            {
                string sql = "SPObtenerHistorial";
                var parametros = new { correoUsuario = correoUsuario , saltar = omitir, tomar = tomar};
                using (var conexion = new SqlConnection(Configuracion.GetConnectionString("BolsaValores")))
                {
                    historial = (await conexion.QueryAsync<Historial>(sql, parametros, commandType: CommandType.StoredProcedure)).ToList();
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return historial;
        }
    }
}
