using System.Collections.Generic;
using KinoRezervejsnJednoduche.Model;
using SQLite;

namespace KinoRezervejsnJednoduche.Service;

public class DatabaseHandler
{
	SQLiteConnection _db;

	// Connect (Create) Database
	public DatabaseHandler(string databasePath)
	{
		_db = new SQLiteConnection(databasePath);
	}

	// Create Table of T Model
	public void CreateTable<T>()
	{
		_db.CreateTable<T>();
	}
	
	// Insert Model to Database
	// model - [object]
	public void InsertToDatabase(object model) {
		_db.Insert(model);
	}

	// Get Model from Database
	// query - [string]
	public List<T> GetTable<T>(string query) where T : new()
	{
		return _db.Query<T>(query);
	}
}