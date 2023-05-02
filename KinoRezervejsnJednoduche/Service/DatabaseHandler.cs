using KinoRezervejsnJednoduche.Model;
using SQLite;

namespace KinoRezervejsnJednoduche.Service;

public class DatabaseHandler
{
	SQLiteConnection _db;

	// Connect (Create) Database And Table
	public DatabaseHandler(string databasePath)
	{
		_db = new SQLiteConnection(databasePath);
		_db.CreateTable<SeatReservation>();
	}
	
	// Insert Model to Database
	// model - [object]
	public void InsertToDatabase(object model) {
		_db.Insert(model);
	}
}