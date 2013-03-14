using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Linq;

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

        public bool LoginUsuario(Usuario unUsuario, string Password)
        {
            var pass = encriptarSHA1(Password);
            var parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", unUsuario.NombreDeUsuario);
            //Usuario unUsuario_aux = new Usuario();
            parametros.Add("@password", pass);
            Area area = new Area();

            var tablaDatos = conexion_bd.Ejecutar("dbo.Web_Login", parametros);
            //TODO: refactorizar el corte de control, si, vos, hacelo no seas vago

            if (tablaDatos.Rows.Count > 0)
            {

                tablaDatos.Rows.ForEach(row =>
                {
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 1) unUsuario.TienePermisosParaViaticos = true;
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 2) unUsuario.TienePermisosParaSiCoI = true;
                    if (row.GetSmallintAsInt("Id_Funcionalidad") == 3) unUsuario.TienePermisosParaSACC = true;

                    var Asistentes = new List<Asistente>();
                    if (unUsuario.Areas.FindAll(a => a.Id == row.GetSmallintAsInt("Id_Area")).Count == 0) //refactorizar, poner un contains
                    {

                        Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                            row.GetString("Apellido_Asistente"),
                                                            row.GetString("Cargo"),
                                                            row.GetSmallintAsInt("Prioridad_Asistente"),
                                                            row.GetString("Telefono_Asistente"),
                                                            row.GetString("Telefono_Asistente"),//Falta cambiar por Fax!!!
                                                            row.GetString("Mail_Asistente"));

                        Asistentes.Add(asistente);

                        Responsable datos_responsable = new Responsable(row.GetString("Nombre_Responsable"),
                                                                        row.GetString("Apellido_Responsable"),
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente")); //Falta cambiar!!!

                        unUsuario.Id = row.GetSmallintAsInt("Id_Usuario");
                        unUsuario.EsFirmante = row.GetSmallintAsInt("es_firmante") != 0;
                        unUsuario.Areas.Add(new Area
                        {
                            Id = row.GetSmallintAsInt("Id_Area"),
                            Nombre = row.GetString("nombre_area"),
                            Direccion = row.GetString("direccion"),
                            Telefono = row.GetString("Telefono_Area"),
                            Mail = row.GetString("Mail_Area"),
                            datos_del_responsable = datos_responsable,
                            Asistentes = Asistentes,
                            
                        });
                    }
                    else { 

                        var area_existente = unUsuario.Areas.Find(a => a.Id == row.GetSmallintAsInt("Id_Area"));
                        if (!area_existente.Asistentes.Any(a => a.Apellido == row.GetString("Apellido_Asistente") && a.Descripcion_Cargo == row.GetString("Cargo"))) {

                         Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                            row.GetString("Apellido_Asistente"),
                                                            row.GetString("Cargo"),
                                                            row.GetSmallintAsInt("Prioridad_Asistente"),
                                                            row.GetString("Telefono_Asistente"),
                                                            row.GetString("Telefono_Asistente"),//Falta cambiar por Fax!!!
                                                            row.GetString("Mail_Asistente"));


                            area_existente.Asistentes.Add(asistente);
                        }
 
                    
                    }

                });              

                return true;
            }


            else
            {
                return false;
            }
        }

        //public List<ContactoArea> GetContactoArea()
        //{

        //    List<ContactoArea> contactos_de_area = new List<ContactoArea>();
        //    contactos_de_area.Add(

        //    return contactos_de_area;
        //}

        private static string encriptarSHA1(string CadenaOriginal)
        {
            System.Security.Cryptography.HashAlgorithm hashValue = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
            hashValue.Clear();
            return (Convert.ToBase64String(byteHash));
        }
        #endregion


    }
}



//using System;
//using System.Collections.Generic;

//using System.Text;
//using System.Data.SqlClient;

//namespace General.Repositorios
//{
//    public class RepositorioUsuarios
//    {
//        #region IRepositorioUsuarios Members

//        public List<Usuario> GetTodosLosUsuarios()
//        {
//            return new List<Usuario>();
//        }

//        public bool LoginUsuario(Usuario unUsuario, string Password)
//        {
//            SqlDataReader dr;
//            ConexionDB cn = new ConexionDB("dbo.Web_Login");
//            var pass = encriptarSHA1(Password);

//            cn.AsignarParametro("@usuario", unUsuario.NombreDeUsuario);
//            cn.AsignarParametro("@password", pass);

//            dr = cn.EjecutarConsulta();

//            if (dr.Read())
//            {
//                unUsuario.Id = dr.GetInt16(dr.GetOrdinal("Id_Usuario"));
//                unUsuario.EsFirmante = dr.GetInt32(dr.GetOrdinal("es_firmante")) != 0;
//                unUsuario.Areas.Add(new Area { Id = dr.GetInt32(dr.GetOrdinal("Id_Area")), Nombre = dr.GetString(dr.GetOrdinal("nombre_area")) });

//                while (dr.Read())
//                {
//                    var contactos = new List<ContactoArea>();
//                    var contacto = new ContactoArea();
//                    // contacto.Id =  

//                    unUsuario.Areas.Add(new Area { Id = dr.GetInt32(dr.GetOrdinal("Id_Area")), Nombre = dr.GetString(dr.GetOrdinal("nombre_area")) });



//                }
//                cn.Desconestar();
//                return true;
//            }
//            else
//            {
//                cn.Desconestar();
//                return false;
//            }
//        }

//        private static string encriptarSHA1(string CadenaOriginal)
//        {
//            System.Security.Cryptography.HashAlgorithm hashValue = new System.Security.Cryptography.SHA1CryptoServiceProvider();
//            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
//            hashValue.Clear();
//            return (Convert.ToBase64String(byteHash));
//        }
//        #endregion
//    }
//}
