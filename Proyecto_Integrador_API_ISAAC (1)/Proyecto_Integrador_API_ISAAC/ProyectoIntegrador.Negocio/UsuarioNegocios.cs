using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegrador.Modelos;
using ProyectoIntegrador.Datos;

namespace ProyectoIntegrador.Negocio
{
    public class UsuarioNegocios
    {
        UsuarioDatos datitos = new UsuarioDatos();

        //LOGIN
        public bool Login(string ID_USUARIO_JUG, string CONTRASEÑA)
        {
            return datitos.Login(ID_USUARIO_JUG, CONTRASEÑA);
        }

        //CRUDS DE USUARIO JUGADOR
        //REGISTRO
        public string registroUsuarioJugador(UsuarioJugador usu_jug)
        {
            string mensaje = "";
            try
            {
                //La validacion de los campos
                usu_jug.Validar();
                datitos.RegistroUsuarioJugador(usu_jug);
                mensaje = "Usuario Jugador Registrado Correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "No llego a registrar el usuario jugador : " + ex.Message;
            }
            return mensaje;
        }

        //ACTUALIZAR
        public string actualizarUsuariosJugadores(UsuarioJugador usu_jug)
        {
            string mensaje = "";
            try
            {
                if (usu_jug.COD_JUGADOR == 0)
                {
                    mensaje = "El codigo del usuario Jugador no es valido";
                }
                //CODIGO DEL USUARIO JUGADOR VALIDO
                else
                {
                    //listar los usuarios jugadores y filtrar el codigo del usuario jugador
                    var existeUsuarioJugador = datitos.ListarUsuariosJugadores().
                        Any(x => x.COD_JUGADOR == usu_jug.COD_JUGADOR);
                    if (existeUsuarioJugador)
                    {
                        //La validacion de los campos
                        usu_jug.Validar();
                        datitos.actualizarUsuarioJugador(usu_jug);
                        mensaje = "Usuario Jugador Actualizado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Jugador no existe";
                }

            }
            catch (Exception ex)
            {
                mensaje = "No llego a actualizar el usuario jugador : " + ex.Message;
            }
            return mensaje;
        }

        //LISTADO
        public List<UsuarioJugador> ListarUsuariosJugadores()
        {
            return datitos.ListarUsuariosJugadores();
        }

        //ELIMINAR
        public string eliminarUsuariosJugadores(int idUsuarioJugador)
        {
            string mensaje = "";

            try
            {
                if (idUsuarioJugador == 0)
                {
                    mensaje = "El codigo del usuario Jugador no es valido";
                }
                //CODIGO DEL USUARIO JUGADOR VALIDO
                else
                {
                    //listar los usuarios jugadores y filtrar el codigo del usuario jugador
                    var existeUsuarioJugador = datitos.ListarUsuariosJugadores().
                        Any(x => x.COD_JUGADOR == idUsuarioJugador);
                    if (existeUsuarioJugador)
                    {
                        datitos.EliminarUsuariosJugadores(idUsuarioJugador);
                        mensaje = "Usuario Jugador Eliminado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Jugador no existe";
                }

            }
            catch (Exception ex)
            {
                mensaje = "No llego a eliminar el usuario jugador : " + ex.Message;
            }
            return mensaje;
        }

        //CRUDS DE USUARIO Regulador
        //REGISTRO
        public string registroUsuarioRegulador(UsuarioRegulador usu_reg)
        {
            string mensaje = "";
            try
            {
                //La validacion de los campos
                usu_reg.Validar();
                datitos.RegistroUsuarioRegulador(usu_reg);
                mensaje = "Usuario Regulador Registrado Correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "No llego a registrar el usuario regulador : " + ex.Message;
            }
            return mensaje;
        }

        //ACTUALIZAR
        public string actualizarUsuariosReguladores(UsuarioRegulador usu_reg)
        {
            string mensaje = "";
            try
            {
                if (usu_reg.COD_REG == 0)
                {
                    mensaje = "El codigo del usuario Regulador no es valido";
                }
                //CODIGO DEL USUARIO REGULADOR VALIDO
                else
                {
                    //listar los usuarios reguladores y filtrar el codigo del usuario regulador
                    var existeUsuarioRegulador = datitos.ListarUsuariosReguladores().
                        Any(x => x.COD_REG == usu_reg.COD_REG);
                    if (existeUsuarioRegulador)
                    {
                        //La validacion de los campos
                        usu_reg.Validar();
                        datitos.actualizarUsuarioRegulador(usu_reg);
                        mensaje = "Usuario Regulador Actualizado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Regulador no existe";
                }
            }
            catch (Exception ex)
            {
                mensaje = "No llego a actualizar el usuario regulador : " + ex.Message;
            }
            return mensaje;
        }

        //LISTADO
        public List<UsuarioRegulador> ListarUsuariosReguladores()
        {
            return datitos.ListarUsuariosReguladores();
        }

        //ELIMINAR
        public string eliminarUsuariosReguladores(int idUsuarioRegulador)
        {
            string mensaje = "";
            try
            {
                if (idUsuarioRegulador == 0)
                {
                    mensaje = "El codigo del usuario Regulador no es valido";
                }
                //CODIGO DEL USUARIO REGULADOR VALIDO
                else
                {
                    //listar los usuarios reguladores y filtrar el codigo del usuario regulador
                    var existeUsuarioRegulador = datitos.ListarUsuariosReguladores().
                        Any(x => x.COD_REG == idUsuarioRegulador);
                    if (existeUsuarioRegulador)
                    {
                        datitos.EliminarUsuariosReguladores(idUsuarioRegulador);
                        mensaje = "Usuario Regulador Eliminado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Regulador no existe";
                }

            }
            catch (Exception ex)
            {
                mensaje = "No llego a eliminar el usuario regulador : " + ex.Message;
            }
            return mensaje;
            
        }


        //CRUDS DEL USUARIO Tienda
        //REGISTRO
        public string registroUsuarioTienda(UsuarioTienda usu_tienda)
        {
            string mensaje = "";
            try
            {
                //La validacion de los campos
                usu_tienda.Validar();
                datitos.RegistroUsuarioTienda(usu_tienda);
                mensaje = "Usuario Tienda Registrado Correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "No llego a registrar el usuario tienda : " + ex.Message;
            }
            return mensaje;
        }

        //ACTUALIZAR
        public string actualizarUsuariosTienda(UsuarioTienda usu_tienda)
        {
            string mensaje = "";
            try
            {
                if (usu_tienda.COD_USU_TIENDA == 0)
                {
                    mensaje = "El codigo del usuario Tienda no es valido";
                }
                //CODIGO DEL USUARIO TIENDA VALIDO
                else
                {
                    //listar los usuarios tienda y filtrar el codigo del usuario tienda
                    var existeUsuarioTienda = datitos.ListarUsuariosTienda().
                        Any(x => x.COD_USU_TIENDA == usu_tienda.COD_USU_TIENDA);
                    if (existeUsuarioTienda)
                    {
                        //La validacion de los campos
                        usu_tienda.Validar();
                        datitos.actualizarUsuarioTienda(usu_tienda);
                        mensaje = "Usuario Tienda Actualizado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Tienda no existe";
                }
            }
            catch (Exception ex)
            {
                mensaje = "No llego a actualizar el usuario tienda : " + ex.Message;
            }
            return mensaje;
        }

        //LISTADO
        public List<UsuarioTienda> ListarUsuariosTienda()
        {
            return datitos.ListarUsuariosTienda();
        }

        //ELIMINAR
        public string eliminarUsuariosTienda(int idUsuarioTienda)
        {
            string mensaje = "";
            try
            {
                if (idUsuarioTienda == 0)
                {
                    mensaje = "El codigo del usuario Tienda no es valido";
                }
                //CODIGO DEL USUARIO TIENDA VALIDO
                else
                {
                    //listar los usuarios tienda y filtrar el codigo del usuario tienda
                    var existeUsuarioTienda = datitos.ListarUsuariosTienda().
                        Any(x => x.COD_USU_TIENDA == idUsuarioTienda);
                    if (existeUsuarioTienda)
                    {
                        datitos.EliminarUsuariosTienda(idUsuarioTienda);
                        mensaje = "Usuario Tienda Eliminado Correctamente";
                    }
                    else
                        mensaje = "El Usuario Tienda no existe";
                }

            }
            catch (Exception ex)
            {
                mensaje = "No llego a eliminar el usuario tienda : " + ex.Message;
            }
            return mensaje;

        }
    }
}
