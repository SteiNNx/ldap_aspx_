using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Obra
    {
        private CL_Empresa empresa;
        private int cod_obra;
        private string nom_obra;

        public CL_Obra(){}
        
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

        public int Cod_obra
        {
            get
            {
                return cod_obra;
            }

            set
            {
                cod_obra = value;
            }
        }

        public string Nom_obra
        {
            get
            {
                return nom_obra;
            }

            set
            {
                nom_obra = value;
            }
        }
    }
    #endregion
}
