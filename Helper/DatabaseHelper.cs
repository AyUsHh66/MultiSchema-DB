using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace MultiSchemaDB_Project.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = "Server=Ayush;Database=MultiSchemaDB;Integrated Security=true;TrustServerCertificate=True;";

        public static Dictionary<string, string> GetDefaultFields(string schema)
        {
            // Define default fields based on the schema
            return schema switch
            {
                "Schema1" => new() { { "FirstName", "" }, { "LastName", "" }, { "Email", "" } },
                "Schema2" => new() { { "FullName", "" }, { "Email", "" }, { "Phone", "" } },
                "Schema3" => new() { { "CompanyName", "" }, { "ContactPerson", "" }, { "Email", "" }, { "Address", "" } },
                _ => null
            };
        }

        public static void InsertRecord(string schema, Dictionary<string, string> fields)
        {
            if (fields == null || fields.Count == 0)
                throw new ArgumentException("Fields cannot be null or empty.");

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            // Construct query
            var columns = string.Join(",", fields.Keys);
            var values = string.Join(",", fields.Values.Select(value => $"'{value.Replace("'", "''")}'")); // Escape single quotes in values
            var query = $"INSERT INTO {schema}.Customer ({columns}) VALUES ({values});";

            // Execute the query
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public static Dictionary<string, string> GetRecordById(string schema, int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var query = $"SELECT * FROM {schema}.Customer WHERE CustomerID = {id};";
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var record = new Dictionary<string, string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    record[reader.GetName(i)] = reader[i]?.ToString() ?? "";
                }
                return record;
            }
            return null;
        }

        public static void CreateRecord(string schema, Dictionary<string, string> fields)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var columns = string.Join(",", fields.Keys);
            var values = string.Join(",", fields.Values.Select(value => $"'{value}'"));
            var query = $"INSERT INTO {schema}.Customer ({columns}) VALUES ({values});";
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public static void UpdateRecord(string schema, int id, Dictionary<string, string> fields)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var updates = string.Join(",", fields.Select(kvp => $"{kvp.Key} = '{kvp.Value.Replace("'", "''")}'")); // Escape single quotes
            var query = $"UPDATE {schema}.Customer SET {updates} WHERE CustomerID = {id};";
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public static void DeleteRecord(string schema, int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var query = $"DELETE FROM {schema}.Customer WHERE CustomerID = {id};";
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
