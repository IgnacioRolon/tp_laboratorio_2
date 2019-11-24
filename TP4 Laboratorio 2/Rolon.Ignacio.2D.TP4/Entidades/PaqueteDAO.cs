using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static bool Insertar(Paquete p)
        {
            StringBuilder command = new StringBuilder();
            command.AppendFormat("INSERT INTO Paquetes VALUES('{0}', '{1}', 'Ignacio Rolon')", p.DireccionEntrega, p.TrackingID);
            comando.CommandText = command.ToString();
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true; //No se hace un try/catch para despues capturar si hay una excepcion dentro del formulario.
        }
    }
}
