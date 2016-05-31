using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEstudiante
    {
        private string _matricula;
        private string _nombre;
        private string _idcarrera;
        private bool _tomo_examen;
        private string _textobuscar;

        

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Idcarrera
        {
            get { return _idcarrera; }
            set { _idcarrera = value; }
        }

        public bool Tomo_examen
        {
            get { return _tomo_examen; }
            set { _tomo_examen = value; }
        }

        public string Textobuscar
        {
            get { return _textobuscar; }
            set { _textobuscar = value; }
        }


        public DEstudiante()
        {
            
        }

        public string insertar(DEstudiante Estudiante)
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
                cmd.CommandText = "spinsertar_estudiante";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parmatricula_estudiante = new SqlParameter();
                parmatricula_estudiante.ParameterName = "@matricula";
                parmatricula_estudiante.SqlDbType = SqlDbType.VarChar;
                parmatricula_estudiante.Size = 7;
                parmatricula_estudiante.Value = Estudiante.Matricula;
                cmd.Parameters.Add(parmatricula_estudiante);

                SqlParameter parnombre_estudiante = new SqlParameter();
                parnombre_estudiante.ParameterName = "@nombre";
                parnombre_estudiante.SqlDbType = SqlDbType.VarChar;
                parnombre_estudiante.Size = 50;
                parnombre_estudiante.Value = Estudiante.Nombre; ;
                cmd.Parameters.Add(parnombre_estudiante);

                SqlParameter paridcarrera = new SqlParameter();
                paridcarrera.ParameterName = "@idcarrera";
                paridcarrera.SqlDbType = SqlDbType.VarChar;
                paridcarrera.Size = 3;
                paridcarrera.Value = Estudiante._idcarrera;
                cmd.Parameters.Add(paridcarrera);

                SqlParameter partomoexamen = new SqlParameter();
                partomoexamen.ParameterName = "@tomo_examen";
                partomoexamen.SqlDbType = SqlDbType.Bit;
                partomoexamen.Value = Estudiante.Tomo_examen;
                cmd.Parameters.Add(partomoexamen);


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

        public string editar(DEstudiante Estudiante)
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
                cmd.CommandText = "speditar_estudiante";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parmatricula_estudiante = new SqlParameter();
                parmatricula_estudiante.ParameterName = "@matricula";
                parmatricula_estudiante.SqlDbType = SqlDbType.VarChar;
                parmatricula_estudiante.Size = 7;
                parmatricula_estudiante.Value = Estudiante.Matricula;
                cmd.Parameters.Add(parmatricula_estudiante);

                SqlParameter parnombre_estudiante = new SqlParameter();
                parnombre_estudiante.ParameterName = "@nombre";
                parnombre_estudiante.SqlDbType = SqlDbType.VarChar;
                parnombre_estudiante.Size = 50;
                parnombre_estudiante.Value = Estudiante.Nombre; ;
                cmd.Parameters.Add(parnombre_estudiante);

                SqlParameter paridcarrera = new SqlParameter();
                paridcarrera.ParameterName = "@idcarrera";
                paridcarrera.SqlDbType = SqlDbType.VarChar;
                paridcarrera.Size = 3;
                paridcarrera.Value = Estudiante.Idcarrera;
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

        public string eliminar(DEstudiante Estudiante)
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
                cmd.CommandText = "speliminar_estudiante";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parmatricula_estudiante = new SqlParameter();
                parmatricula_estudiante.ParameterName = "@matricula";
                parmatricula_estudiante.SqlDbType = SqlDbType.VarChar;
                parmatricula_estudiante.Size = 7;
                parmatricula_estudiante.Value = Estudiante.Matricula;
                cmd.Parameters.Add(parmatricula_estudiante);

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
            DataTable dt = new DataTable("estudiante");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spmostrar_estudiante";
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

        public DataTable buscar_nombre(DEstudiante Estudiante)
        {
            DataTable dt = new DataTable("estudiante");

            SqlConnection con = new SqlConnection();

            try
            {
                // abriendo conexion
                con.ConnectionString = conexion.cn;
                con.Open();

                // creando comando

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spbuscar_estudiante_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter partexto_buscar = new SqlParameter();
                partexto_buscar.ParameterName = "@textobuscar";
                partexto_buscar.SqlDbType = SqlDbType.VarChar;
                partexto_buscar.Size = 50;
                partexto_buscar.Value = Estudiante.Textobuscar;
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

        public string tomar_examen(DEstudiante Estudiante)
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
                cmd.CommandText = "sptomar_estudiante";
                cmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter parmatricula_estudiante = new SqlParameter();
                parmatricula_estudiante.ParameterName = "@matricula";
                parmatricula_estudiante.SqlDbType = SqlDbType.VarChar;
                parmatricula_estudiante.Size = 7;
                parmatricula_estudiante.Value = Estudiante.Matricula;
                cmd.Parameters.Add(parmatricula_estudiante);

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


    }

}
