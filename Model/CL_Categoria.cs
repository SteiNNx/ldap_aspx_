using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Categoria
    {
        private CL_Empresa empresa;
        private int cod_categoria;
        private string nom_categoria;
        private string abrev_categoria;
        private string cod_categoria_sap;

        public CL_Categoria()
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

        public int Cod_categoria
        {
            get
            {
                return cod_categoria;
            }

            set
            {
                cod_categoria = value;
            }
        }

        public string Nom_categoria
        {
            get
            {
                return nom_categoria;
            }

            set
            {
                nom_categoria = value;
            }
        }

        public string Abrev_categoria
        {
            get
            {
                return abrev_categoria;
            }

            set
            {
                abrev_categoria = value;
            }
        }

        public string Cod_categoria_sap
        {
            get
            {
                return cod_categoria_sap;
            }

            set
            {
                cod_categoria_sap = value;
            }
        }
    }
    #endregion
}
