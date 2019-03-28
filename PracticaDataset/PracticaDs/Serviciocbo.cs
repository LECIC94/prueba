using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PracticaDs;

namespace PracticaDs
{
    public class Serviciocbo
    {
        public string servicio;
        public DataSet Buscaservicio(bool paracombo)
        {
            DataAcces oData = new DataAcces();

            DataSet Ds = new DataSet();
            oData.Sentencia = "sp_consultaservicio @servicio= '" + servicio + "',@paracombo=";
            if (paracombo) oData.Sentencia += "1";
            else oData.Sentencia += "0";
            Ds = oData.GetData();
            return Ds;
        }
    }
}
