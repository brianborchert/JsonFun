using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\jsonFile.json";

            string json0 = File.ReadAllText(path);
            PrintJSON(json0);

            // Deserialization 1
            DataSet dataSet1 = JsonConvert.DeserializeObject<DataSet>(json0);
            DataTable dataTable1 = dataSet1.Tables["people"];
            PrintPeopleDataTable(dataTable1);

            // Serialization 1
            string json1 = JsonConvert.SerializeObject(dataSet1);
            PrintJSON(json1);

            // Deserialization 2
            DataSet dataSet2 = JsonConvert.DeserializeObject<DataSet>(json1);
            DataTable dataTable2 = dataSet2.Tables["people"];
            PrintPeopleDataTable(dataTable2);

            // Serialization 2
            string json2 = JsonConvert.SerializeObject(dataSet1);
            PrintJSON(json2);

            // Checks
            Console.WriteLine(json0.Equals(json1));             // false
            Console.WriteLine(json1.Equals(json2));             // true
            Console.WriteLine(dataSet1.Equals(dataSet2));       // false
            Console.WriteLine(dataTable1.Equals(dataTable2));   // false

            Console.ReadLine();
        }

        public static void PrintPeopleDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["firstName"] + " "
                    + row["lastName"] + " is a "
                    + row["age"] + " years old "
                    + row["gender"] + ".");
            }
            Console.WriteLine();
        }

        public static void PrintJSON(string json)
        {
            Console.WriteLine(json);
            Console.WriteLine();
        }
    }
}
