using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Grafico
    {
        public List<Resumen> tabla_resumen;
        public List<Dotacion> tabla_detalle;

        public Grafico()
        {
        }




        internal void CrearDatos(List<RowDeDatos> list)
        {

            List<Dotacion> tabla = new List<Dotacion>();

            list.ForEach(row =>
            {
                Dotacion persona =
                       new Dotacion(
                           row.GetInt("id_persona", 0),
                           row.GetInt("legajo", 0),
                          row.GetInt("nrodocumento", 0),
                           row.GetString("apellido", "Sin Dato"),
                           row.GetString("nombre", "Sin Dato"),
                           row.GetSmallintAsInt("id_sexo", 0),
                          row.GetString("descrip_sexo", "Sin Dato"),
                           row.GetString("nivel", "Sin Dato"),
                           row.GetString("grado", "Sin Dato"),
                           row.GetInt("id_area", 0),
                           row.GetString("area", "Sin Dato"),
                           row.GetSmallintAsInt("id_planta", -1),
                           row.GetString("planta", "Sin Dato"),
                           row.GetInt("IdEstudio", -1),
                           row.GetString("Nivel_Estudios", "Sin Dato"),
                           row.GetString("Titulo_Obtenido", "Sin Dato"),
                           row.GetDateTime("FechaNacimiento", DateTime.Today)
                );
                tabla.Add(persona);
            });
            this.tabla_detalle = tabla;
        }

        internal void GraficoPorNivel()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int nivel_a = 0;
            int nivel_b = 0;
            int nivel_c = 0;
            int nivel_d = 0;
            int nivel_e = 0;
            int nivel_f = 0;
            int nivel_w = 0;
            tabla_personas.ForEach(p =>
            {
                switch (p.Nivel)
                {
                    case "A":
                        nivel_a++;
                        break;
                    case "B":
                        nivel_b++;
                        break;
                    case "C":
                        nivel_c++;
                        break;
                    case "D":
                        nivel_d++;
                        break;
                    case "E":
                        nivel_e++;
                        break;
                    case "F":
                        nivel_f++;
                        break;
                    case "W":
                        nivel_w++;
                        break;
                }

            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Nivel A", nivel_a, total));
            tabla.Add(GenerarRegistroResumen("Nivel B", nivel_b, total));
            tabla.Add(GenerarRegistroResumen("Nivel C", nivel_c, total));
            tabla.Add(GenerarRegistroResumen("Nivel D", nivel_d, total));
            tabla.Add(GenerarRegistroResumen("Nivel E", nivel_e, total));
            tabla.Add(GenerarRegistroResumen("Nivel F", nivel_f, total));
            tabla.Add(GenerarRegistroResumen("Nivel W", nivel_w, total)); 
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        private Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, float.Parse(String.Format("{0:0.##}", cantidad * 100 / total)));
            return registro_resumen;
        }

        internal void GraficoPorGenero()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int femenino = 0;
            int masculino = 0;
            tabla_personas.ForEach(p =>
            {
                switch (p.IdSexo)
                {
                    case 1:
                        masculino++;
                        break;
                    case 2:
                        femenino++;
                        break;
                }
            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Femenino", femenino, total));
            tabla.Add(GenerarRegistroResumen("Masculino", masculino, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoPorEstudio()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int NoEspecifica = 0;
            int Primario = 0;
            int Secundario = 0;
            int Terciario = 0;
            int Universitario = 0;
            int PostGrado = 0;
            int CicloBasico = 0;
            int Nopresentocertificado = 0;
            int Pregrado = 0;

            tabla_personas.ForEach(p =>
            {
                switch (p.NivelEstudio)
                {
                    case "NoEspecifica":
                        NoEspecifica++;
                        break;
                    case "Primario":
                        Primario++;
                        break;
                    case "Secundario":
                        Secundario++;
                        break;
                    case "Terciario":
                        Terciario++;
                        break;
                    case "Universitario":
                        Universitario++;
                        break;
                    case "PostGrado":
                        PostGrado++;
                        break;
                    case "CicloBasico":
                        CicloBasico++;
                        break;
                    case "Nopresentocertificado":
                        Nopresentocertificado++;
                        break;
                    case "Pregrado":
                        Pregrado++;
                        break;
                }
            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            if (NoEspecifica > 0) tabla.Add(GenerarRegistroResumen("No Especifica", NoEspecifica, total));
            if (Primario > 0) tabla.Add(GenerarRegistroResumen("Primario", Primario, total));
            if (Secundario > 0) tabla.Add(GenerarRegistroResumen("Secundario", Secundario, total));
            if (Terciario > 0) tabla.Add(GenerarRegistroResumen("Terciario", Terciario, total));
            if (Universitario > 0) tabla.Add(GenerarRegistroResumen("Universitario", Universitario, total));
            if (PostGrado > 0) tabla.Add(GenerarRegistroResumen("Post-Grado", PostGrado, total));
            if (CicloBasico > 0) tabla.Add(GenerarRegistroResumen("Ciclo Básico", CicloBasico, total));
            if (Nopresentocertificado > 0) tabla.Add(GenerarRegistroResumen("No presento certificado", Nopresentocertificado, total));
            if (Pregrado > 0) tabla.Add(GenerarRegistroResumen("Pregrado", Pregrado, total)); 
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoPorPlanta()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int tipo_0 = 0;
            int tipo_1 = 0;
            int tipo_2 = 0;
            int tipo_3 = 0;
            int tipo_4 = 0;
            int tipo_5 = 0;
            int tipo_6 = 0;
            int tipo_7 = 0;
            int tipo_8 = 0;
            int tipo_9 = 0;
            int tipo_10 = 0;
            int tipo_11 = 0;
            int tipo_12 = 0;
            int tipo_13 = 0;
            int tipo_14 = 0;
            int tipo_15 = 0;
            int tipo_16 = 0;
            int tipo_17 = 0;
            int tipo_18 = 0;
            int tipo_19 = 0;
            int tipo_20 = 0;
            int tipo_21 = 0;
            int tipo_22 = 0;
            int tipo_23 = 0;
            int tipo_24 = 0;
            int tipo_25 = 0;
            int tipo_26 = 0;
            int tipo_27 = 0;
            int tipo_28 = 0;
            int tipo_29 = 0;
            int tipo_30 = 0;
            
            tabla_personas.ForEach(p =>
            {
                switch (p.IdPlanta)
                {
                    case 0:
                        tipo_0++;
                        break;
                    case 1:
                        tipo_1++;
                        break;
                    case 2:
                        tipo_2++;
                        break;
                    case 3:
                        tipo_3++;
                        break;
                    case 4:
                        tipo_4++;
                        break;
                    case 5:
                        tipo_5++;
                        break;
                    case 6:
                        tipo_6++;
                        break;
                    case 7:
                        tipo_7++;
                        break;
                    case 8:
                        tipo_8++;
                        break;
                    case 9:
                        tipo_9++;
                        break;
                    case 10:
                        tipo_10++;
                        break;
                    case 11:
                        tipo_11++;
                        break;
                    case 12:
                        tipo_12++;
                        break;
                    case 13:
                        tipo_13++;
                        break;
                    case 14:
                        tipo_14++;
                        break;
                    case 15:
                        tipo_15++;
                        break;
                    case 16:
                        tipo_16++;
                        break;
                    case 17:
                        tipo_17++;
                        break;
                    case 18:
                        tipo_18++;
                        break;
                    case 19:
                        tipo_19++;
                        break;
                    case 20:
                        tipo_20++;
                        break;
                    case 21:
                        tipo_21++;
                        break;
                    case 22:
                        tipo_22++;
                        break;
                    case 23:
                        tipo_23++;
                        break;
                    case 24:
                        tipo_24++;
                        break;
                    case 25:
                        tipo_25++;
                        break;
                    case 26:
                        tipo_26++;
                        break;
                    case 27:
                        tipo_27++;
                        break;
                    case 28:
                        tipo_28++;
                        break;
                    case 29:
                        tipo_29++;
                        break;
                    case 30:
                        tipo_30++;
                        break;
                }
            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            if (tipo_0 > 0) tabla.Add(GenerarRegistroResumen("No Especifica", tipo_0, total));
            if (tipo_1 > 0) tabla.Add(GenerarRegistroResumen("Contratado XXXX", tipo_1, total));
            if (tipo_2 > 0) tabla.Add(GenerarRegistroResumen("Gab Ases A8", tipo_2, total));
            if (tipo_3 > 0) tabla.Add(GenerarRegistroResumen("Gab Nivel Político", tipo_3, total));
            if (tipo_4 > 0) tabla.Add(GenerarRegistroResumen("Gab Auditoría", tipo_4, total));
            if (tipo_5 > 0) tabla.Add(GenerarRegistroResumen("Gab Ases UR", tipo_5, total));
            if (tipo_6 > 0) tabla.Add(GenerarRegistroResumen("Gabinete - Vocales", tipo_6, total));
            if (tipo_7 > 0) tabla.Add(GenerarRegistroResumen("Permanente", tipo_7, total));
            if (tipo_8 > 0) tabla.Add(GenerarRegistroResumen("Transitoria 1421", tipo_8, total));
            if (tipo_9 > 0) tabla.Add(GenerarRegistroResumen("Contratado Res. 1184", tipo_9, total));
            if (tipo_10 > 0) tabla.Add(GenerarRegistroResumen("Transitoria PROSOL", tipo_10, total));
            if (tipo_11 > 0) tabla.Add(GenerarRegistroResumen("Transitoria", tipo_11, total));
            if (tipo_12 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1423", tipo_12, total));
            if (tipo_13 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1424", tipo_13, total));
            if (tipo_14 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1425", tipo_14, total));
            if (tipo_15 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1426", tipo_15, total));
            if (tipo_16 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1427", tipo_16, total));
            if (tipo_17 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1428", tipo_17, total));
            if (tipo_18 > 0) tabla.Add(GenerarRegistroResumen("Contratado Dto. 1429", tipo_18, total));
            if (tipo_19 > 0) tabla.Add(GenerarRegistroResumen("Contrato Internacional", tipo_19, total));
            if (tipo_20 > 0) tabla.Add(GenerarRegistroResumen("Gabinete", tipo_20, total));
            if (tipo_21 > 0) tabla.Add(GenerarRegistroResumen("Gabinete Transitorio", tipo_21, total));
            if (tipo_22 > 0) tabla.Add(GenerarRegistroResumen("Contratada", tipo_22, total));
            if (tipo_23 > 0) tabla.Add(GenerarRegistroResumen("Externa", tipo_23, total));
            if (tipo_24 > 0) tabla.Add(GenerarRegistroResumen("Transitoria POSOCO", tipo_24, total));
            if (tipo_25 > 0) tabla.Add(GenerarRegistroResumen("Pasante", tipo_25, total));
            if (tipo_26 > 0) tabla.Add(GenerarRegistroResumen("Asistente Tecnico", tipo_26, total));
            if (tipo_27 > 0) tabla.Add(GenerarRegistroResumen("Contrato PNUD", tipo_27, total));
            if (tipo_28 > 0) tabla.Add(GenerarRegistroResumen("Perm FE (Concurs)", tipo_28, total));
            if (tipo_29 > 0) tabla.Add(GenerarRegistroResumen("Perm FE (Transit)", tipo_29, total));
            if (tipo_30 > 0) tabla.Add(GenerarRegistroResumen("Gab Ases AdH", tipo_30, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoPorAfiliacionGremial()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            int sin_datos = tabla_personas.Count;
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Sin Datos", sin_datos, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoRangoEtareo(DateTime fecha)
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int de_18_a_25 = 0;
            int de_26_a_35 = 0;
            int de_36_a_45 = 0;
            int de_46_a_55 = 0;
            int de_56_a_60 = 0;
            int de_61_a_65 = 0;
            int mas_de_65 = 0;
            tabla_personas.ForEach(p =>
            {
                if (p.Edad(fecha) >= 18 && p.Edad(fecha) <= 25)
                {
                    de_18_a_25++;
                }
                else if (p.Edad(fecha) >= 26 && p.Edad(fecha) <= 35) {
                    de_26_a_35++;
                }
                else if (p.Edad(fecha) >= 36 && p.Edad(fecha) <= 45)
                {
                    de_36_a_45++;
                }
                else if (p.Edad(fecha) >= 46 && p.Edad(fecha) <= 55)
                {
                    de_46_a_55++;
                }
                else if (p.Edad(fecha) >= 56 && p.Edad(fecha) <= 60)
                {
                    de_56_a_60++;
                }
                else if (p.Edad(fecha) >= 61 && p.Edad(fecha) <= 65)
                {
                    de_61_a_65++;
                }
                else if (p.Edad(fecha) > 65)
                {
                    mas_de_65++;
                }
            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("18-25", de_18_a_25, total));
            tabla.Add(GenerarRegistroResumen("26-35", de_26_a_35, total));
            tabla.Add(GenerarRegistroResumen("36-45", de_36_a_45, total));
            tabla.Add(GenerarRegistroResumen("46-55", de_46_a_55, total));
            tabla.Add(GenerarRegistroResumen("56-60", de_56_a_60, total));
            tabla.Add(GenerarRegistroResumen("61-65", de_61_a_65, total));
            tabla.Add(GenerarRegistroResumen(">65", mas_de_65, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }
    }
}
