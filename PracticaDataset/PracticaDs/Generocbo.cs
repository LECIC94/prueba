using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PracticaDs;

namespace PracticaDs
{
    public class Generocbo
    {
        public string genero;

        public DataSet Buscacombo(bool paracombo)

        {

            DataAcces oData = new DataAcces();



            DataSet Ds = new DataSet();

            oData.Sentencia = "sp_consultagenero @genero= '" + genero + "',@paracombo=";

            if (paracombo) oData.Sentencia += "1";

            else oData.Sentencia += "0";

            Ds = oData.GetData();

            return Ds;

        }

    }
}
