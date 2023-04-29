namespace KinoRezervejsnJednoduche.Model;

public class Cinema
{
	public string Name { set; get; }
	public int Rows { set; get; }
	public int Columns { set; get; }
		
	public Cinema(string name, int rows, int columns)
	{
		Name = name;
		Rows = rows;
		Columns = columns;
	}
}