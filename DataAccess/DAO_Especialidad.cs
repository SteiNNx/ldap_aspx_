﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace DataAccess
{
    public class DAO_Especialidad
    {
        private SqlConnection cone;
        public DAO_Especialidad()
        {
            if (cone==null)
            {
                cone = new CL_Conexion().obtenerConexion();
            }
        }

        public string ejecutarStoredProcedure_SFSF_SP_INSERT_ESPECIALIDAD(string p_bd)
        {
            string estado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SP_INSERT_ESPECIALIDAD";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("bd", System.Data.SqlDbType.NVarChar).Value = p_bd;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                int resp = cmd.ExecuteNonQuery();
                if (resp > -1)
                {
                    estado = "Ejecutado Correctamente Procedimiento.. Filas Afectadas(SFSF_Especialidad): " + resp;
                }
                else
                {
                    estado = "Error!";
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error! DAO_Especialidad_Centralizacion.ejecutarStoredProcedure_SFSF_SP_INSERT_ESPECIALIDAD " + ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return estado;
        }
    }
}