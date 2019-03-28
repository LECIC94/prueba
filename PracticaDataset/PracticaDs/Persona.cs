using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PracticaDs;

namespace PracticaDs
{
    public class Persona
    {

        public string ID = "";
        public DateTime FECHA_DE_LA_CITA;
        public string SERVICIO = "";
        public string ESTUDIO = "";
        public string ENTIDAD_DE_NACIMIENTO = "";
        public string ENTIDAD_DEL_DOMICILIO = "";
        public string MUNICIPIO_DEL_DOMICILIO = "";
        public string ESTADO_CIVIL = "";
        public string OCUPACION = "";
        public string ESCOLARIDAD = "";
        public string DERECHOHABIENCIA = "";
        public string SEGURIDAD_SOCIAL = "";
        public string GANERO = "";
        public string FORMA_DE_INGRESO = "";
        public string EDAD = "";
        public string CLINICA = "";
        public string Errorregistro = "";


        DataAcces oData = new DataAcces();
        DataSet Ds = new DataSet();

        public DataSet Buscaregistro()
        {
            oData.Sentencia = "sp_buscaregistro @id='" + ID.Trim() + "'";
            Ds = oData.GetData();
            return Ds;
        }
        public bool Guardar()
        {
            bool bret = false;
            oData.Sentencia = " sp_guardaregistro @ID='" + ID + "',@FECHA_DE_LA_CITA='" + string.Format("{0:yyyyMMdd}", FECHA_DE_LA_CITA) + "',@SERVICIO='" + SERVICIO + "',@ESTUDIO='" + ESTUDIO +
                "',@ENTIDAD_DE_NACIMIENTO='" + ENTIDAD_DE_NACIMIENTO + "',@ENTIDAD_DEL_DOMICILIO='" + ENTIDAD_DEL_DOMICILIO + "',@MUNICIPIO_DEL_DOMICILIO='" + MUNICIPIO_DEL_DOMICILIO +
                "',@ESTADO_CIVIL='" + ESTADO_CIVIL + "',@OCUPACION='" + OCUPACION + "',@ESCOLARIDAD='" + ESCOLARIDAD + "',@DERECHOHABIENCIA='" + DERECHOHABIENCIA +
                "',@SEGURIDAD_SOCIAL='" + SEGURIDAD_SOCIAL + "',@GANERO='" + GANERO + "',@FORMA_DE_INGRESO='" + FORMA_DE_INGRESO + "',@EDAD='" + EDAD +
                "',@CLINICA='" + CLINICA + "' ";
            Ds = oData.GetData();
            if (int.Parse(Ds.Tables[Ds.Tables.Count - 1].Rows[0]["Error"].ToString()) > 0)
            {
                Errorregistro = Ds.Tables[Ds.Tables.Count - 1].Rows[0]["Descripcion"].ToString();
                bret = false;
            }
            else
            {
                ID = Ds.Tables[Ds.Tables.Count - 1].Rows[0]["ID"].ToString();
                bret = true;
            }
            return bret;
        }

        /*public bool Eliminarregistro()
        {
            bool bret = false;
            oData.Sentencia = "sp_eliminarregistroo  @id='" + ID + "', @Nombre='" + nomb + "'";
            Ds = oData.GetData();
            if (int.Parse(Ds.Tables[Ds.Tables.Count - 1].Rows[0]["Error"].ToString()) > 0)
            {
                Errorregistro = Ds.Tables[Ds.Tables.Count - 1].Rows[0]["Descripcion"].ToString();
                bret = false;
            }
            else
            {
                bret = true;
            }
            return bret;
        }*/
    }
}
