using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CL_Historico_Trabajador
    {
        private CL_Empresa empresa;
        private CL_Trabajador trabajador;
        private CL_Obra obra;
        private int rol;
        private string fecha_contrato;
        private CL_Especialidad especialidad;
        private CL_Categoria categoria;
        private string fecha_finiquito;

        public CL_Historico_Trabajador()
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

        public CL_Trabajador Trabajador
        {
            get
            {
                return trabajador;
            }

            set
            {
                trabajador = value;
            }
        }

        public CL_Obra Obra
        {
            get
            {
                return obra;
            }

            set
            {
                obra = value;
            }
        }

        public int Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public string Fecha_contrato
        {
            get
            {
                return fecha_contrato;
            }

            set
            {
                fecha_contrato = value;
            }
        }

        public CL_Especialidad Especialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
            }
        }

        public CL_Categoria Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public string Fecha_finiquito
        {
            get
            {
                return fecha_finiquito;
            }

            set
            {
                fecha_finiquito = value;
            }
        }
    }
    #endregion
}
