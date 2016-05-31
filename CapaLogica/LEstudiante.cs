using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaLogica
{
    public class LEstudiante
    {
        public static string insertar(string matricula, string nombre, string idcarrera)
        {
            DEstudiante obj = new DEstudiante();

            obj.Matricula = matricula;
            obj.Nombre = nombre;
            obj.Idcarrera = idcarrera;
            obj.Tomo_examen = false;

            return obj.insertar(obj);
        }

        public static string editar(string matricula, string nombre, string idcarrera)
        {
            DEstudiante obj = new DEstudiante();

            obj.Matricula = matricula;
            obj.Nombre = nombre;
            obj.Idcarrera = idcarrera;
            

            return obj.editar(obj);
        }

        public static string eliminar(string matricula)
        {
            DEstudiante obj = new DEstudiante();

            obj.Matricula = matricula;

            return obj.eliminar(obj);
        }

        public static DataTable mostrar()
        {
            DEstudiante obj = new DEstudiante();

            return obj.mostrar();
        }

        public static DataTable buscar_nombre(string texto_buscar)
        {
            DEstudiante obj = new DEstudiante();
            obj.Textobuscar = texto_buscar;

            return obj.buscar_nombre(obj);
        }

        public static string tomar_examen(string matricula)
        {
            DEstudiante obj = new DEstudiante();
            obj.Matricula = matricula;

            return obj.tomar_examen(obj);
        }
    }
}
