using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

    public static class Logger
    {
        public static void EscribirLog(string logText)
        {
            //Lo comento porque rompe las bolas
            //try
            //{
            //    //var path = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            //    //using (StreamWriter w = File.AppendText(path + "\\Log.txt"))
            //    using (StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath("") + "\\Log.txt"))
               
            //    {
            //        w.WriteLine(DateTime.Now.ToString() + " - " + logText);
            //    }
            //}
            //catch { }
        }

        public static void EscribirLog(Exception ex)
        {
            //var path = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            //using (StreamWriter w = File.AppendText(path + "\\Log.txt"))
            //Lo comento porque rompe las bolas
            //try
            //{
            //    using (StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath("") + "\\Log.txt"))
               
            //    {
            //        //w.WriteLine("--------------------------------------------------------------------------------");
            //        w.WriteLine(DateTime.Now.ToString() + " - EXCEPCION");
            //        w.WriteLine("Message: " + ex.Message);
            //        w.WriteLine("Source: " + ex.Source);
            //        w.WriteLine("TargetSite: " + ex.TargetSite);
            //        w.WriteLine("StackTrace: " + ex.StackTrace);
            //        w.WriteLine("InnerException: " + ex.InnerException);
            //        //w.WriteLine("--------------------------------------------------------------------------------");
            //    }
            //}
            //catch { }
        }
    }
