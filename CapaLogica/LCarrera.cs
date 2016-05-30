using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos;


namespace CapaLogica
{
    public class LCarrera
    {
        public static string insertar(int idcarrera, string nombre_carrera)
        {
            DCarrera carrera = new DCarrera();

            carrera.Idcarrera = idcarrera;
            carrera.Nombre_carrera = nombre_carrera;

            return carrera.insertar(carrera);
        }

        public static string editar(int idcarrera, string nombre_carrera)
        {
            DCarrera carrera = new DCarrera();

            carrera.Idcarrera = idcarrera;
            carrera.Nombre_carrera = nombre_carrera;


            return carrera.editar(carrera);
        }

        public static string eliminar(int idcarrera)
        {
            DCarrera carrera = new DCarrera();

            carrera.Idcarrera = idcarrera;

            return carrera.eliminar(carrera);
        }

        public static DataTable mostrar()
        {
            DCarrera carrera = new DCarrera();

            return carrera.mostrar();
        }

        public static DataTable buscar_nombre(string texto_buscar)
        {
            DCarrera carrera = new DCarrera();
            carrera.Textobuscar = texto_buscar;

            return carrera.buscar_nombre(carrera);
        }
    }
}
