using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarioAdministrador
    {
        private string _nombre_usuario;
        private string _password;
        private string _texto_buscar;

       
        public string Nombre_usuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Texto_buscar
        {
            get { return _texto_buscar; }
            set { _texto_buscar = value; }
        }


        public string insertar(DUsuarioAdministrador Usuario)
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
                cmd.CommandText = "spinsertar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parnombre_usuario = new SqlParameter();
                parnombre_usuario.ParameterName = "@nombre_usuario";
                parnombre_usuario.SqlDbType = SqlDbType.VarChar;
                parnombre_usuario.Size = 50;
                parnombre_usuario.Value = Usuario.Nombre_usuario;
                cmd.Parameters.Add(parnombre_usuario);

                SqlParameter parpw_usuario = new SqlParameter();
                parpw_usuario.ParameterName = "@password";
                parpw_usuario.SqlDbType = SqlDbType.VarChar;
                parpw_usuario.Size = 20;
                parpw_usuario.Value = Usuario.Password;
                cmd.Parameters.Add(parpw_usuario);

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

        public string editar(DUsuarioAdministrador Usuario)
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
                cmd.CommandText = "speditar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parnombre_usuario = new SqlParameter();
                parnombre_usuario.ParameterName = "@nombre_usuario";
                parnombre_usuario.SqlDbType = SqlDbType.VarChar;
                parnombre_usuario.Size = 50;
                parnombre_usuario.Value = Usuario.Nombre_usuario;
                cmd.Parameters.Add(parnombre_usuario);

                SqlParameter parpw_usuario = new SqlParameter();
                parpw_usuario.ParameterName = "@password";
                parpw_usuario.SqlDbType = SqlDbType.VarChar;
                parpw_usuario.Size = 20;
                parpw_usuario.Value = Usuario.Password;
                cmd.Parameters.Add(parpw_usuario);

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

        public string eliminar(DUsuarioAdministrador Usuario)
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
                cmd.CommandText = "speliminar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parnombre_usuario = new SqlParameter();
                parnombre_usuario.ParameterName = "@nombre_usuario";
                parnombre_usuario.SqlDbType = SqlDbType.VarChar;
                parnombre_usuario.Size = 50;
                parnombre_usuario.Value = Usuario.Nombre_usuario;
                cmd.Parameters.Add(parnombre_usuario);

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
            DataTable dt = new DataTable("usuario_administrador");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spmostrar_usuario";
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

        public DataTable buscar_nombre(DUsuarioAdministrador Usuario)
        {
            DataTable dt = new DataTable("usuario_administrador");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spbuscar_usuario_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter partexto_buscar = new SqlParameter();
                partexto_buscar.ParameterName = "@textobuscar";
                partexto_buscar.SqlDbType = SqlDbType.VarChar;
                partexto_buscar.Size = 50;
                partexto_buscar.Value = Usuario.Texto_buscar;
                cmd.Parameters.Add(partexto_buscar);

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
