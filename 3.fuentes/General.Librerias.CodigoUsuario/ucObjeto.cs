using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace General.Librerias.CodigoUsuario
{
    public class ucObjeto
    {
        public static void Grabar<T>(T obj, string archivo)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                foreach (PropertyInfo propiedad in propiedades)
                {
                    sw.WriteLine("{0} = {1}", propiedad.Name, propiedad.GetValue(obj, null));
                    //SAPO

                    //Saspito
                    //ricardo
                }
                sw.WriteLine(new String('_', 100));
            }
        }
    }
}
