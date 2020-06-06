using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Base.Static.Extensions
{
    public static class ListObjectExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            var props =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                                                 prop.PropertyType) ?? prop.PropertyType);

                //table.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in data)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in props) row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }

            return table;
        }

        public static bool IsBlank<T>(this List<T> list)
        {
            if (list == null)
                return true;
            if (list.Count == 0)
                return true;
            return false;
        }

        public static bool Equals<T>(this List<T> list1, List<T> list2)
        {
            if (list1.IsBlank() && list2.IsBlank()) return true;

            if (!list1.IsBlank() && !list2.IsBlank())
            {
                var exclude1 = list1.Where(w => !list2.Contains(w));
                var exclude2 = list2.Where(w => !list1.Contains(w));
                if (exclude1.Count() > 0 || exclude2.Count() > 0)
                    return false;
                return true;
            }

            return false;
        }
    }
}