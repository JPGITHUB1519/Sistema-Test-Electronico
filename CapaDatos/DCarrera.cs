using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCarrera
    {
        private string _idcarrera;
        private string _nombre_carrera;
        private string _textobuscar;

        public string Idcarrera
        {
            get { return _idcarrera; }
            set { _idcarrera = value; }
        }


        public string Nombre_carrera
        {
            get { return _nombre_carrera; }
            set { _nombre_carrera = value; }
        }

        public DCarrera(string idcarrera, string nombre_carrera)
        {
            this.Idcarrera = idcarrera;
            this.Nombre_carrera = nombre_carrera;
 
        }

        public string Textobuscar
        {
            get { return _textobuscar; }
            set { _textobuscar = value; }
        }


        public DCarrera()
        {
 
        }
        public string insertar(DCarrera Carrera)
        {
            string rpta = "";

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spinsertar_carrera";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter paridcarrera = new SqlParameter();
                paridcarrera.ParameterName = "@idcarrera";
                paridcarrera.SqlDbType = SqlDbType.VarChar;
                paridcarrera.Size = 3;
                paridcarrera.Value = Carrera._idcarrera;
                cmd.Parameters.Add(paridcarrera);

                SqlParameter parnombre_carrera = new SqlParameter();
                parnombre_carrera.ParameterName = "@nombre_carrera";
                parnombre_carrera.SqlDbType = SqlDbType.VarChar;
                parnombre_carrera.Size = 50;
                parnombre_carrera.Value = Carrera._nombre_carrera;
                cmd.Parameters.Add(parnombre_carrera);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro"; 



            }
            catch (Exception ex)
            {
                rpta = ex.Message;
 
            }

            finally
            {
                // si la conexion esta abierta, cierrala
                if (con.State == ConnectionState.Open) con.Close();

            }

            return rpta;
        }

        public string editar(DCarrera Carrera)
        {
            string rpta = "";

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "speditar_carrera";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter paridcarrera = new SqlParameter();
                paridcarrera.ParameterName = "@idcarrera";
                paridcarrera.SqlDbType = SqlDbType.VarChar;
                paridcarrera.Size = 3;
                paridcarrera.Value = Carrera._idcarrera;
                cmd.Parameters.Add(paridcarrera);

                SqlParameter parnombre_carrera = new SqlParameter();
                parnombre_carrera.ParameterName = "@nombre_carrera";
                parnombre_carrera.SqlDbType = SqlDbType.VarChar;
                parnombre_carrera.Size = 50;
                parnombre_carrera.Value = Carrera._nombre_carrera;
                cmd.Parameters.Add(parnombre_carrera);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            finally
            {
                // si la conexion esta abierta, cierrala
                if (con.State == ConnectionState.Open) con.Close();

            }

            return rpta;

        }

        public string eliminar(DCarrera Carrera)
        {
            string rpta = "";

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "speliminar_carrera";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter paridcarrera = new SqlParameter();
                paridcarrera.ParameterName = "@idcarrera";
                paridcarrera.SqlDbType = SqlDbType.VarChar;
                paridcarrera.Size = 3;
                paridcarrera.Value = Carrera._idcarrera;
                cmd.Parameters.Add(paridcarrera);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            finally
            {
                // si la conexion esta abierta, cierrala
                if (con.State == ConnectionState.Open) con.Close();

            }

            return rpta;

        }
      
        public DataTable mostrar()
        {
            DataTable dt = new DataTable("carrera");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spmostrar_carrera";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = null;

            }

            finally
            {
                // si la conexion esta abierta, cierrala
                if (con.State == ConnectionState.Open) con.Close();

            }

            return dt;

        }

        public DataTable buscar_nombre(DCarrera carrera)
        {
            DataTable dt = new DataTable("carrera");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spbuscar_carrera_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parnombre_carrera = new SqlParameter();
                parnombre_carrera.ParameterName = "@textobuscar";
                parnombre_carrera.SqlDbType = SqlDbType.VarChar;
                parnombre_carrera.Size = 50;
                parnombre_carrera.Value = carrera.Textobuscar;
                cmd.Parameters.Add(parnombre_carrera);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            catch (Exception ex)
            {
                dt = null;

            }

            finally
            {
                // si la conexion esta abierta, cierrala
                if (con.State == ConnectionState.Open) con.Close();

            }

            return dt;

        }



    }
}
