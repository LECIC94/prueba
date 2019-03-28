using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticaDs;

namespace PracticaDataset
{
    public partial class ABC : Form
    {
        public ABC()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ABC_Load(object sender, EventArgs e)
        {
            txt_fecha.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            Cargaservicio();
            Cargaseguro();
            Cargaocupacion();
            Carganacimiento();
            Cargadomicilio();

            Cargamunicipio();

            Cargaingreso();
            Cargagenero();
            Cargaestudio();
            Cargaestadocivil();
            Cargaderechohabiencia();
            Cargaescolaridad();
            
        }

        private void Cargaservicio()
        {
            Serviciocbo oServicio = new Serviciocbo();
            cbo_servicio.DisplayMember = "servicio";
            cbo_servicio.DataSource = oServicio.Buscaservicio(true).Tables[0];
            oServicio = null;
        }

        private void Cargaderechohabiencia()
        {
            Derechohabienciacbo oCarga = new Derechohabienciacbo();
            cbo_derechohabiencia.DisplayMember = "derechohabiencia";
            cbo_derechohabiencia.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargadomicilio()
        {
            Domiciliocbo oCarga = new Domiciliocbo();
            cbo_domicilio.DisplayMember = "domicilio";
            cbo_domicilio.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargaescolaridad()
        {
            Escolaridadcbo oCarga = new Escolaridadcbo();
            cbo_escolaridad.DisplayMember = "escolaridad";
            cbo_escolaridad.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }
 
        private void Cargaestadocivil()
         {
            Estadocivilcbo oCarga = new Estadocivilcbo();
            cbo_estado_civil.DisplayMember = "estadocivil";
            cbo_estado_civil.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
         }

        private void Cargaestudio()
        {
            Estudiocbo oCarga = new Estudiocbo();
            cbo_estudio.DisplayMember = "estudio";
            cbo_estudio.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargagenero()
        {
            Generocbo oCarga = new Generocbo();
            cbo_genero.DisplayMember = "ganero";
            cbo_genero.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargaingreso()
        {
            Ingresocbo oCarga = new Ingresocbo();
            cbo_ingreso.DisplayMember = "ingreso";
            cbo_ingreso.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargamunicipio()
        {
            Municipiocbo oMunicipio = new Municipiocbo();
            oMunicipio.domicilio = cbo_domicilio.Text;
            cbo_municipio.DisplayMember = "municipio";
            cbo_municipio.DataSource = oMunicipio.Buscacombo(true).Tables[0];
            oMunicipio = null;
        }

        private void Carganacimiento()
        {
            Nacimientocbo oNacimiento = new Nacimientocbo();
            cbo_nacimiento.DisplayMember = "nacimiento";
            cbo_nacimiento.DataSource = oNacimiento.Buscanacimiento(true).Tables[0];
            oNacimiento = null;
        }

        private void Cargaocupacion()
        {
            Ocupacioncbo oCarga = new Ocupacioncbo();
            cbo_ocupacion.DisplayMember = "ocupacion";
            cbo_ocupacion.DataSource = oCarga.Buscacombo(true).Tables[0];
            oCarga = null;
        }

        private void Cargaseguro()
        {
            Segurosocialcbo oSeguro = new Segurosocialcbo();
            cbo_seguro.DisplayMember = "seguro";
            cbo_seguro.DataSource = oSeguro.Buscaseguro(true).Tables[0];
            oSeguro = null;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Persona oPersona = new Persona();
            oPersona.ID = txt_id.Text;
            oPersona.FECHA_DE_LA_CITA= DateTime.Parse(txt_fecha.Text);
            oPersona.SERVICIO = cbo_servicio.Text;
            oPersona.ESTUDIO = cbo_estudio.Text;
            oPersona.ENTIDAD_DE_NACIMIENTO = cbo_nacimiento.Text;
            oPersona.ENTIDAD_DEL_DOMICILIO = cbo_domicilio.Text;
            oPersona.MUNICIPIO_DEL_DOMICILIO = cbo_municipio.Text;
            oPersona.ESTADO_CIVIL = cbo_estado_civil.Text;
            oPersona.OCUPACION = cbo_ocupacion.Text;
            oPersona.ESCOLARIDAD = cbo_escolaridad.Text;
            oPersona.DERECHOHABIENCIA = cbo_derechohabiencia.Text;
            oPersona.SEGURIDAD_SOCIAL = cbo_seguro.Text;
            oPersona.GANERO = cbo_genero.Text;
            oPersona.FORMA_DE_INGRESO = cbo_ingreso.Text;
            oPersona.EDAD = txt_edad.Text;
            oPersona.CLINICA = txt_clinica.Text;

            if (oPersona.Guardar())
            {
                txt_id.Text = oPersona.ID;
                MessageBox.Show("Datos Guardados");
                //Buscapersona(false);
            }
            else
            {
                MessageBox.Show("No se Guardaron los Datos por: " + oPersona.Errorregistro);
            }
        }

        /*private void Buscapersona(bool Editar)
        {

            Persona oPersona = new Persona();
            if (!Editar)
            {
                oPersona.nom_emp = txtBusqueda.Text;
                oPersona.id_emp = txtBusqueda.Text;
                grdEmpleados.DataSource = oEmpleado.Buscaempleado().Tables[0];
                grdEmpleados.Refresh();
            }
            else
            {
                oEmpleado.id_emp = grdEmpleados.SelectedRows[0].Cells[0].Value.ToString();
                oEmpleado.nom_emp = grdEmpleados.SelectedRows[0].Cells[0].Value.ToString();
                DataSet Ds = new DataSet();
                Ds = oEmpleado.Buscaempleado();
                txt_idemp.Text = oEmpleado.id_emp;
                txt_nombre.Text = Ds.Tables[0].Rows[0]["Nombre"].ToString();
                txt_edad.Text = Ds.Tables[0].Rows[0]["Edad"].ToString();
                txt_direccion.Text = Ds.Tables[0].Rows[0]["Direccion"].ToString();
                txt_telefono.Text = Ds.Tables[0].Rows[0]["Telefono"].ToString();
                txt_sueldo.Text = Ds.Tables[0].Rows[0]["Sueldo"].ToString();
                txt_horas.Text = Ds.Tables[0].Rows[0]["Horas"].ToString();
                cbo_puesto.Text = Ds.Tables[0].Rows[0]["Puesto"].ToString();
                cbo_tienda.Text = Ds.Tables[0].Rows[0]["Tienda"].ToString();
            }
            oEmpleado = null;
        }*/
    }
}
