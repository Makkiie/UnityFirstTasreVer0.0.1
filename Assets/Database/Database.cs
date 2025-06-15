using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour
{
    //The name of the DB, in this case it is called"Inventory"
    //It is put here so all of the methods can access 
    private string dbName = "URI=file:FirstTaste.db";

    private void Start()
    {
        CreateDB();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT ";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}