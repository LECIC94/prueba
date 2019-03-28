using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace PracticaDs
{
    public class DataAcces
    {

        public DataSet Buscainfo()
        {
            DataSet dsRet = new DataSet();

            return dsRet;
        }
        public DataSet GetData()
        {
            DataSet dsDatos = new DataSet();
            string connectionstring = ConfigurationManager.ConnectionStrings["Laboratorio"].ConnectionString;

            //Adn es la cadena de conexion en el web.config
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(Sentencia, connection))
                {
                    //OleDbCommand cmdConsultar = new OleDbCommand(strCommand, objConn);
                    SqlDataAdapter objAdapter = new SqlDataAdapter();
                    command.CommandTimeout = 36000;
                    command.CommandType = CommandType.Text;
                    command.CommandText = Sentencia;
                    //DataSet dtsDatos=new DataSet();
                    objAdapter.SelectCommand = command;
                    //sqlConn.Open();

                    objAdapter.Fill(dsDatos);
                }
            }
            return dsDatos;
        }
        public String Sentencia
        {
            get;
            set;
        }
    }
}

