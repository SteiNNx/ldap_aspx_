using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Trabajador
    {
        private string rut;
        private string paterno;
        private string materno;
        private string nombres;

        public CL_Trabajador()
        {

        }
        #region accesadores y mutadores
        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string Paterno
        {
            get
            {
                return paterno;
            }

            set
            {
                paterno = value;
            }
        }

        public string Materno
        {
            get
            {
                return materno;
            }

            set
            {
                materno = value;
            }
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }
    }
    #endregion
}
