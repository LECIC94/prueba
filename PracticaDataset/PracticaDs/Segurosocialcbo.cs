using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PracticaDs;

namespace PracticaDs
{
    public class Segurosocialcbo
    {
        public string segurosocial;

        public DataSet Buscaseguro(bool paracombo)

        {

            DataAcces oData = new DataAcces();



            DataSet Ds = new DataSet();

            oData.Sentencia = "sp_consultasegurosocial @segurosocial = '" + segurosocial + "',@paracombo=";

            if (paracombo) oData.Sentencia += "1";

            else oData.Sentencia += "0";

            Ds = oData.GetData();

            return Ds;

        }

    }
}
