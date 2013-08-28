using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General.Modi;
using General.Repositorios;

namespace AsistenteDeEscaneoDeLegajos
{
    public partial class Principal : Form
    {
        private ConexionBDSQL conexion_db;
        private FileSystem file_system;
        private ServicioDeCompresionYPersistenciaDeImagenes servicio_de_subida;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.conexion_db = new ConexionBDSQL("Data Source=SQLTRETA;Initial Catalog=DB_RRHH;Integrated Security=True");
            this.file_system = new FileSystem();
            this.servicio_de_subida = new ServicioDeCompresionYPersistenciaDeImagenes(conexion_db, 
                file_system, 
                "\\\\ZEUS\\RRHHyORG\\Organización\\DigitalizacionLegajos");
        }

        private void btnSubirImagenes_Click(object sender, EventArgs e)
        {
            servicio_de_subida.AgregarImagenesSinAsignarDeUnLegajoALaBase(Int32.Parse(this.txtIdInterna.Text));
        }
    }
}
