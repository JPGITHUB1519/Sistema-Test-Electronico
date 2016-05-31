using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaLogica
{
    public class LUsuarioAdministrador
    {
        public static string insertar(string nombre_usuario, string password)
        {
            DUsuarioAdministrador obj = new DUsuarioAdministrador();

            obj.Nombre_usuario = nombre_usuario;
            obj.Password = password;

            return obj.insertar(obj);
        }

        public static string editar(string nombre_usuario, string password)
        {
            DUsuarioAdministrador obj = new DUsuarioAdministrador();

            obj.Nombre_usuario = nombre_usuario;
            obj.Password = password;

            return obj.editar(obj);
        }

        public static string eliminar(string nombre_usuario)
        {
            DUsuarioAdministrador obj = new DUsuarioAdministrador();

            obj.Nombre_usuario = nombre_usuario;

            return obj.editar(obj);
        }

        public static DataTable mostrar()
        {
            DUsuarioAdministrador obj = new DUsuarioAdministrador();

            return obj.mostrar();
        }

        public static DataTable buscar_nombre(string texto_buscar)
        {
            DUsuarioAdministrador obj = new DUsuarioAdministrador();
            obj.Texto_buscar = texto_buscar;

            return obj.buscar_nombre(obj);
        }
    }
}
