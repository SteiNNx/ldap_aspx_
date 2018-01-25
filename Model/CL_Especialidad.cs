using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Especialidad
    {
        private CL_Empresa empresa;
        private int cod_especialidad;
        private string nom_especialidad;
        private string cod_especialidad_sap;
        public CL_Especialidad()
        {

        }
        #region accesadores y mutadores

        public CL_Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }

        public int Cod_especialidad
        {
            get
            {
                return cod_especialidad;
            }

            set
            {
                cod_especialidad = value;
            }
        }

        public string Nom_especialidad
        {
            get
            {
                return nom_especialidad;
            }

            set
            {
                nom_especialidad = value;
            }
        }

        public string Cod_especialidad_sap
        {
            get
            {
                return cod_especialidad_sap;
            }

            set
            {
                cod_especialidad_sap = value;
            }
        }
    }
    #endregion
}
