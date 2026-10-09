using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Common.Extentions
{
    public static class ListExtensions
    {
        public static DataTable ToDataTable<T>(this List<T> list) where T : class
        {
            var type = typeof(T);
            var props = type.GetProperties();
            DataTable dt = new DataTable();

            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name);
            }

            foreach (T item in list)
            {
                object[] values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    try
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    catch
                    {
                        continue;
                    }
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
