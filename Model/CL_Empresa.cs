using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Empresa
    {
        private string rut_empresa;
        private string nom_empresa;
        private string cod_sociedad_sap;

        public CL_Empresa(){}

        #region accesadores y mutadores
        public string Rut_empresa
        {
            get
            {
                return rut_empresa;
            }

            set
            {
                rut_empresa = value;
            }
        }

        public string Nom_empresa
        {
            get
            {
                return nom_empresa;
            }

            set
            {
                nom_empresa = value;
            }
        }

        public string Cod_sociedad_sap
        {
            get
            {
                return cod_sociedad_sap;
            }

            set
            {
                cod_sociedad_sap = value;
            }
        }
    }
    #endregion
}
