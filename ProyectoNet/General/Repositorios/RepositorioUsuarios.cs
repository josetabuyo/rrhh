using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;

namespace General.Repositorios
{
    public class RepositorioUsuarios
    {
        #region IRepositorioUsuarios Members

        public IConexionBD conexion_bd { get; set; }

        public RepositorioUsuarios(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Usuario> GetTodosLosUsuarios()
        {
            return new List<Usuario>();
        }

        public bool CambiarPassword(Usuario usuario, string pass_actual, string pass_nueva)
        {
            var pass_actual_encriptada = encriptarSHA1(pass_actual);
            var pass_nueva_encriptada = encriptarSHA1(pass_nueva);
            var parametros = new Dictionary<string, object>();
           // parametros.Add("@usuario", usuario.NombreDeUsuario);
            //parametros.Add("@password", pass_actual_encriptada);
            //Area area = new Area();

            //var tablaDatos = conexion_bd.Ejecutar("dbo.Web_Login", parametros);

           // if (tablaDatos.Rows.Count > 0)
           // {
                //parametros = new Dictionary<string, object>();

                parametros.Add("@idUsuario", usuario.Id);
                parametros.Add("@password_actual", pass_actual_encriptada);
                parametros.Add("@password_nuevo", pass_nueva_encriptada);
                var rto =   (int)conexion_bd.EjecutarEscalar("dbo.SACC_Upd_Password", parametros);

                if (rto > 0)
		            return true;
                return false;
                    
               
            //}

           // return false;
        }

        public bool LoginUsuario(Usuario unUsuario, string Password)
        {
            var pass = encriptarSHA1(Password);
            var parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", unUsuario.NombreDeUsuario);
            parametros.Add("@password", pass);
            Area area = new Area();

            var tablaDatos = conexion_bd.Ejecutar("dbo.Web_Login", parametros);
            //TODO: refactorizar el corte de control

            if (tablaDatos.Rows.Count > 0)
            {

                tablaDatos.Rows.ForEach(row =>
                { 
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 1) unUsuario.TienePermisosParaViaticos = true;
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 2) unUsuario.TienePermisosParaSiCoI = true;
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 3 || row.GetSmallintAsInt("Id_Funcionalidad") == 4) unUsuario.TienePermisosParaSACC = true;
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 5) unUsuario.TienePermisosParaModil = true;
                    unUsuario.FeaturesDescripcion.Add(row.GetString("Nombre_Funcionalidad"));

                    var Asistentes = new List<Asistente>();

                    if (unUsuario.Areas.FindAll(a => a.Id == row.GetSmallintAsInt("Id_Area")).Count == 0)
                    {
                        List<DatoDeContacto> DatosDeContacto = new List<DatoDeContacto>();

                        unUsuario.Id = row.GetSmallintAsInt("Id_Usuario");
                        unUsuario.EsFirmante = row.GetSmallintAsInt("es_firmante") != 0;

                        Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                            row.GetString("Apellido_Asistente"),
                                                            row.GetString("Cargo"),
                                                            row.GetSmallintAsInt("Prioridad_Asistente"),
                                                            row.GetString("Telefono_Asistente"),
                                                            row.GetString("Telefono_Asistente"), //Falta cambiar por Fax
                                                            row.GetString("Mail_Asistente"));
                        Asistentes.Add(asistente);

                        Responsable datos_responsable = new Responsable(row.GetString("Nombre_Responsable"),
                                                                        row.GetString("Apellido_Responsable"),
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente")); //Falta cambiar!!!

                        DatoDeContacto dato_de_contacto = new DatoDeContacto(row.GetSmallintAsInt("Id_Dato_Area"),
                                                                             row.GetString("Descripcion_Dato_Area"),
                                                                             row.GetString("Dato_Area"),
                                                                             row.GetSmallintAsInt("Orden"));
                        DatosDeContacto.Add(dato_de_contacto);

                        unUsuario.Areas.Add(new Area
                        {
                            Id = row.GetSmallintAsInt("Id_Area"),
                            Nombre = row.GetString("nombre_area"),
                            Direccion = row.GetString("direccion"),
                            datos_del_responsable = datos_responsable,
                            Asistentes = Asistentes,
                            DatosDeContacto = DatosDeContacto,
                        });
                    }
                    else
                    {
                        var area_existente = unUsuario.Areas.Find(a => a.Id == row.GetSmallintAsInt("Id_Area"));
                        if (!area_existente.Asistentes.Any(a => a.Apellido == row.GetString("Apellido_Asistente") && a.Descripcion_Cargo == row.GetString("Cargo")))
                        {
                            Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                               row.GetString("Apellido_Asistente"),
                                                               row.GetString("Cargo"),
                                                               row.GetSmallintAsInt("Prioridad_Asistente"),
                                                               row.GetString("Telefono_Asistente"),
                                                               row.GetString("Telefono_Asistente"),//Falta cambiar por Fax!!!
                                                               row.GetString("Mail_Asistente"));
                            area_existente.Asistentes.Add(asistente);
                        }
                        if (!area_existente.DatosDeContacto.Any(d => d.Id == row.GetSmallintAsInt("Id_Dato_Area") && d.Orden == row.GetSmallintAsInt("Orden")))
                        {
                            DatoDeContacto nuevo_dato = new DatoDeContacto(row.GetSmallintAsInt("Id_Dato_Area"),
                                                                           row.GetString("Descripcion_Dato_Area"),
                                                                           row.GetString("Dato_Area"),
                                                                           row.GetSmallintAsInt("Orden"));
                            area_existente.DatosDeContacto.Add(nuevo_dato);
                        }
                    }

                });

                foreach (Area area_interna in unUsuario.Areas)
                {
                    area_interna.DatosDeContacto.Sort((dato1, dato2) => dato1.esMayorQue(dato2));
                }

                return true;
            }
            else
            {
                return false;
            }
        }



        private static string encriptarSHA1(string CadenaOriginal)
        {
            System.Security.Cryptography.HashAlgorithm hashValue = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
            hashValue.Clear();
            return (Convert.ToBase64String(byteHash));
        }
        #endregion

        protected MenuDelSistema MenuFrom(string nombre, List<RowDeDatos> rows)
        {
            var items = new List<ItemDeMenu>();
            rows.ForEach(row =>
            {
                items.Add(new ItemDeMenu(
                    row.GetSmallintAsInt("id"),
                    row.GetString("menu"),
                    row.GetSmallintAsInt("orden"),
                    row.GetString("nombre"),
                    row.GetString("url"),
                    row.GetSmallintAsInt("padre")
                ));
            });
            return new MenuDelSistema(nombre, items);
        }

        public Autorizador AutorizadorPara(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Accesos_Sistema", parametros);
            var menues = new List<MenuDelSistema>();

            var nombres_menu = tablaDatos.Rows.Select(row => row.GetString("menu")).Distinct().ToList();
            nombres_menu.ForEach(nombre =>
                            {
                                var rows_menu = tablaDatos.Rows.FindAll(row => row.GetString("menu") == nombre).ToList();
                                menues.Add(this.MenuFrom(nombre, rows_menu));
                            }
                );
            return new Autorizador(menues);
        }
    }
}
