using System;

namespace KinoRezervejsnJednoduche.Model;

public class Movie
{
	public string Uuid { get; set; }
	public string Name { get; set; }
	public string Date { get; set; }
	public string Time { get; set; }
	public DateTime DateTime { get; set; }
	public Cinema Cinema { get; set; }
	

	public Movie(string uuid, string name, Cinema cinema, DateTime date)
	{
		Cinema = cinema;
		Name = name;
		Uuid = uuid;
		DateTime = date;
		Date = date.ToString("M");
		Time = date.ToString("HH:mm");
	}
}