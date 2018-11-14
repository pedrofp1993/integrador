using ProyectoIntegrador.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoIntegrador.Datos
{
    public class UsuarioDatos
    {
        
        string CadenaConexion = "server=.;database=BD_PROYECTO_ACTUALIZADA5;Integrated Security=true";
        SqlConnection conexion;

        public UsuarioDatos()
        {
            conexion = new SqlConnection(CadenaConexion);
        }

        //LOGIN
        public bool Login(string ID_USUARIO_JUG, string CONTRASEÑA)
        {
            //Usuario usu = null;
            try
            {
                conexion.Open();
            string query = "select count(*) as 'match' from TB_USUARIO_JUGADOR where ID_USUARIO_JUG = @ID_USU and CONTRASEÑA = @PASS_USU";
            SqlCommand comandos = new SqlCommand(query, conexion);
            comandos.Parameters.AddWithValue("@ID_USUARIO", ID_USUARIO_JUG);
            comandos.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
            SqlDataReader lectora = comandos.ExecuteReader();
            if (lectora.HasRows)
            {
            //    usu = new Usuario();
                while (lectora.Read())
                {
                        string match = lectora["match"].ToString();
                        if (match.Equals("1"))
                        {
                            return true;
                        }
                    //usu.codigo_usu = int.Parse(lectora["codigo_usu"].ToString());
                    //usu.nombre_usu = lectora["nombre_usu"].ToString();
                    //usu.apellido_usu = lectora["apellido_usu"].ToString();
                    //usu.dni_usu = lectora["dni_usu"].ToString();
                    //usu.correo_usu = lectora["correo_usu"].ToString();
                    //usu.fecha_usu = lectora["fecha_usu"].ToString();
                    //usu.id_usu = lectora["id_usu"].ToString();
                    //usu.password_usu = lectora["password_usu"].ToString();

                }
            }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
            
        }

        //CRUDS DE USUARIO JUGADOR
        //REGISTRO
        public void RegistroUsuarioJugador(UsuarioJugador usu_jug)
        {
            conexion.Open();
            string sqlStatement = "USP_REGISTRO_USUARIO_JUGADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@NOMBRE_USU_JUGADOR", usu_jug.NOM_JUGADOR);
            comandos.Parameters.AddWithValue("@APELLIDO_USU_JUGADOR", usu_jug.APELLIDO_JUGADOR);
            comandos.Parameters.AddWithValue("@CORREO_USU_JUGADOR", usu_jug.CORREO_ELECTRONICO);
            comandos.Parameters.AddWithValue("@ID_USUARIO_JUGADOR", usu_jug.ID_USUARIO_JUG);
            comandos.Parameters.AddWithValue("@CONTRASEÑA_USU_JUGADOR", usu_jug.CONTRASEÑA);
            comandos.Parameters.AddWithValue("@DIRECCION", usu_jug.DIRECCION);
            comandos.Parameters.AddWithValue("@CIUDAD", usu_jug.CIUDAD);
            comandos.Parameters.AddWithValue("@DNI", usu_jug.DNI);
            comandos.Parameters.AddWithValue("@FECHA_NACI_USU_JUGADOR", usu_jug.FECHA_NACIMIENTO);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //ACTUALIZAR
        public void actualizarUsuarioJugador(UsuarioJugador usu_jug)
        {
            conexion.Open();
            string sqlStatement = "USP_ACTUALIZAR_USUARIO_JUGADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_JUG", usu_jug.COD_JUGADOR);
            comandos.Parameters.AddWithValue("@CORREO_USU_JUG", usu_jug.CORREO_ELECTRONICO);
            comandos.Parameters.AddWithValue("@DIRECCION", usu_jug.DIRECCION);
            comandos.Parameters.AddWithValue("@CIUDAD", usu_jug.CIUDAD);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //LISTAR
        public List<UsuarioJugador> ListarUsuariosJugadores()
        {
            List<UsuarioJugador> usuariosjugadores = null;
            string listita = "USP_LISTAR_USUARIO_JUGADOR";
            SqlCommand comando = new SqlCommand(listita, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                usuariosjugadores = new List<UsuarioJugador>();
                while (reader.Read())
                {
                    UsuarioJugador usuariojugador = new UsuarioJugador();
                    usuariojugador.COD_JUGADOR = int.Parse(reader["COD_JUGADOR"].ToString());
                    usuariojugador.NOM_JUGADOR = reader["NOM_JUGADOR"].ToString();
                    usuariojugador.APELLIDO_JUGADOR = reader["APELLIDO_JUGADOR"].ToString();
                    usuariojugador.CORREO_ELECTRONICO = reader["CORREO_ELECTRONICO"].ToString();
                    usuariojugador.ID_USUARIO_JUG = reader["ID_USUARIO_JUG"].ToString();
                    usuariojugador.CONTRASEÑA = reader["CONTRASEÑA"].ToString();
                    usuariojugador.DIRECCION = reader["DIRECCION"].ToString();
                    usuariojugador.CIUDAD = reader["CIUDAD"].ToString();
                    usuariojugador.DNI = reader["DNI"].ToString();
                    usuariojugador.FECHA_NACIMIENTO = reader["FECHA_NACIMIENTO"].ToString();
                    usuariosjugadores.Add(usuariojugador);
                }
            }
            conexion.Close();
            return usuariosjugadores;
        }

        //ELIMINAR
        public void EliminarUsuariosJugadores(int idUsuarioJugador)
        {
            conexion.Open();
            string sqlStatement = "USP_ELIMINAR_USUARIO_JUGADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_JUG", idUsuarioJugador);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }


        //CRUDS DE USUARIO REGULADOR
        //REGISTRO
        public void RegistroUsuarioRegulador(UsuarioRegulador usu_reg)
        {
            conexion.Open();
            string sqlStatement = "USP_REGISTRO_USUARIO_REGULADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@NOMBRE_USU_REG", usu_reg.NOM_REG);
            comandos.Parameters.AddWithValue("@APELLIDOS_USU_REG", usu_reg.APE_REG);
            comandos.Parameters.AddWithValue("@CORREO_REG", usu_reg.COD_REG);
            comandos.Parameters.AddWithValue("@CATEGORIA_REG", usu_reg.CATEGORIA);
            comandos.Parameters.AddWithValue("@NIVEL_REG", usu_reg.NIVEL);
            comandos.Parameters.AddWithValue("@COD_ID_REG", usu_reg.COD_ID);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //ACTUALIZAR
        public void actualizarUsuarioRegulador(UsuarioRegulador usu_reg)
        {
            conexion.Open();
            string sqlStatement = "USP_ACTUALIZAR_USUARIO_REGULADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_REG", usu_reg.COD_REG);
            comandos.Parameters.AddWithValue("@CATEGORIA", usu_reg.CATEGORIA);
            comandos.Parameters.AddWithValue("@NIVEL", usu_reg.NIVEL);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //LISTAR
        public List<UsuarioRegulador> ListarUsuariosReguladores()
        {
            List<UsuarioRegulador> usuariosreguladores = null;
            string listita = "USP_LISTAR_USUARIO_REGULADOR";
            SqlCommand comando = new SqlCommand(listita, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                usuariosreguladores = new List<UsuarioRegulador>();
                while (reader.Read())
                {
                    UsuarioRegulador usuarioregulador = new UsuarioRegulador();
                    usuarioregulador.COD_REG = int.Parse(reader["COD_REG"].ToString());
                    usuarioregulador.NOM_REG = reader["NOM_REG"].ToString();
                    usuarioregulador.APE_REG = reader["APE_REG"].ToString();
                    usuarioregulador.CORREO = reader["CORREO"].ToString();
                    usuarioregulador.CATEGORIA = int.Parse(reader["CATEGORIA"].ToString());
                    usuarioregulador.NIVEL = int.Parse(reader["NIVEL"].ToString());
                    usuarioregulador.COD_ID = reader["COD_ID"].ToString();
                    usuariosreguladores.Add(usuarioregulador);
                }
            }
            conexion.Close();
            return usuariosreguladores;
        }

        //ELIMINAR
        public void EliminarUsuariosReguladores(int idUsuarioRegulador)
        {
            conexion.Open();
            string sqlStatement = "USP_ELIMINAR_USUARIO_REGULADOR";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_REG", idUsuarioRegulador);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }


        //CRUDS DEL USUARIO TIENDA
        //REGISTRO
        public void RegistroUsuarioTienda(UsuarioTienda usu_tienda)
        {
            conexion.Open();
            string sqlStatement = "USP_REGISTRO_USUARIO_TIENDA";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@RAZON_SOCIAL", usu_tienda.RAZON_SOCIAL);
            comandos.Parameters.AddWithValue("@REPRESENTANTE", usu_tienda.REP_LEGAL);
            comandos.Parameters.AddWithValue("@CORREO_ELECTRONICO", usu_tienda.CORREO_UST);
            comandos.Parameters.AddWithValue("@DIRECCION", usu_tienda.DIRECCION);
            comandos.Parameters.AddWithValue("@TELEFONO", usu_tienda.TELEFONO);
            comandos.Parameters.AddWithValue("@FECHA_CONSTI", usu_tienda.FECHA_CONSTITU);
            comandos.Parameters.AddWithValue("@RUC", usu_tienda.RUC);
            comandos.Parameters.AddWithValue("@ID_USU_TIENDA", usu_tienda.ID_USU_TIENDA);
            comandos.Parameters.AddWithValue("@CONTRASEÑA_TIENDA", usu_tienda.CONTRA_USU_TIENDA);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //ACTUALIZAR
        public void actualizarUsuarioTienda(UsuarioTienda usu_tienda)
        {
            conexion.Open();
            string sqlStatement = "USP_ACTUALIZAR_USUARIO_TIENDA";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_TIENDA", usu_tienda.COD_USU_TIENDA);
            comandos.Parameters.AddWithValue("@REPRESENTANTE", usu_tienda.REP_LEGAL);
            comandos.Parameters.AddWithValue("@CORREO_ELECTRONICO", usu_tienda.CORREO_UST);
            comandos.Parameters.AddWithValue("@DIRECCION", usu_tienda.DIRECCION);
            comandos.Parameters.AddWithValue("@TELEFONO", usu_tienda.TELEFONO);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }

        //LISTAR
        public List<UsuarioTienda> ListarUsuariosTienda()
        {
            List<UsuarioTienda> usuariostienda = null;
            string listita = "USP_LISTAR_USUARIO_TIENDA";
            SqlCommand comando = new SqlCommand(listita, conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                usuariostienda = new List<UsuarioTienda>();
                while (reader.Read())
                {
                    UsuarioTienda usuariotienda = new UsuarioTienda();
                    usuariotienda.COD_USU_TIENDA = int.Parse(reader["COD_USU_TIENDA"].ToString());
                    usuariotienda.RAZON_SOCIAL = reader["RAZON_SOCIAL"].ToString();
                    usuariotienda.REP_LEGAL = reader["REP_LEGAL"].ToString();
                    usuariotienda.CORREO_UST = reader["CORREO_UST"].ToString();
                    usuariotienda.DIRECCION = reader["DIRECCION"].ToString();
                    usuariotienda.TELEFONO = reader["TELEFONO"].ToString();
                    usuariotienda.FECHA_CONSTITU = reader["FECHA_CONSTITU"].ToString();
                    usuariotienda.RUC = reader["RUC"].ToString();
                    usuariotienda.ID_USU_TIENDA = reader["ID_USU_TIENDA"].ToString();
                    usuariotienda.CONTRA_USU_TIENDA = reader["CONTRA_USU_TIENDA"].ToString();
                    usuariostienda.Add(usuariotienda);
                }
            }
            conexion.Close();
            return usuariostienda;
        }

        //ELIMINAR
        public void EliminarUsuariosTienda(int idUsuarioTienda)
        {
            conexion.Open();
            string sqlStatement = "USP_ELIMINAR_USUARIO_TIENDA";
            SqlCommand comandos = new SqlCommand(sqlStatement, conexion);
            comandos.CommandType = System.Data.CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@COD_USU_TIENDA", idUsuarioTienda);
            comandos.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
