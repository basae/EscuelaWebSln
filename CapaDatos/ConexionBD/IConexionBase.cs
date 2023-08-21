using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CapaDatos.ConexionBD
{
    public interface IConexionBase
    {
        DataTable ExeStoreProcedure(string Name, Dictionary<string, object> Parameters);
        DataTable ExeStoreProcedure(string Name);
        DataSet ExeStoreProcedureDataSet(string Name, Dictionary<string, object> Parameters);
        void CrearTransaccion();
        void CommitTransaccion();
        void RollBack();
    }
    public static class IConexionBaseExtension
    {
        public static DataTable ParseListToTable<T>(this IConexionBase conn, List<T> items,Dictionary<string,string> ColumnName=null)
        {
            DataTable dt = new DataTable();
            var ObjectInfo = items.FirstOrDefault().GetType();

            if (ObjectInfo.IsValueType)
            {
                dt.Columns.Add(ColumnName==null?"column1":ColumnName.First().Value, ObjectInfo.GetTypeInfo());   
                foreach(var i in items)
                {
                    dt.Rows.Add(i);
                }
                
            }
            else
            {

                PropertyInfo[] pros = ObjectInfo.GetProperties();
                foreach (var i in pros)
                {
                    if (ColumnName == null)
                        dt.Columns.Add(i.Name, i.PropertyType);
                    else
                    {                        
                        dt.Columns.Add(ColumnName[i.Name], i.PropertyType);
                    }
                }

                foreach (var item in items)
                {
                    var propertyInfo = item.GetType().GetProperties().Select(x => x.GetValue(item) ?? "");
                    dt.Rows.Add(propertyInfo.ToArray());
                }

            }

            return dt;
        }
    }
}