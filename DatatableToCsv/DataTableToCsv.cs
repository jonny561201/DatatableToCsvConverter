using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatatableToCsv
{
    public class DataTableToCsv
    {
        public string ToCsv(DataTable table)
        {
            var test = "";
            foreach (var column in table.Columns)
            {
                if (!string.IsNullOrEmpty(column.ToString()))
                    test += string.Concat(column.ToString(), ',');
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if(!string.IsNullOrEmpty(row.ToString()))
                        test += string.Concat(row[i],'\n');
                }
            }
            return test;
        }
    }
}
