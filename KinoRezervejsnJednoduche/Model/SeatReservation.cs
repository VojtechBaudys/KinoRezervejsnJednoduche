using SQLite;

namespace KinoRezervejsnJednoduche.Model;

public class SeatReservation
{
	[PrimaryKey, AutoIncrement]
	[Column("id")]
	public int Id { set; get; }
	
	[Column("uuid")]
	public string Uuid { set; get; } = null!;

	[Column("row")]
	public string Row { set; get; } = null!;

	[Column("column")]
	public string Column { set; get; } = null!;
	
	[Column("forename")]
	public string Forename { set; get; } = null!;
	
	[Column("surname")]
	public string Surname { set; get; } = null!;
	
	[Column("email")]
	public string Email { set; get; } = null!;
}