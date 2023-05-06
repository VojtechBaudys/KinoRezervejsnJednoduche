using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using KinoRezervejsnJednoduche.Model;
using KinoRezervejsnJednoduche.Service;

namespace KinoRezervejsnJednoduche.Windows;

public partial class seatInfoWindow : Window
{
	Dictionary<string, string> _seatData;
	DatabaseHandler _db;
	
	public seatInfoWindow(Dictionary<string, string> seatData)
	{
		InitializeComponent();
		
		// DB
		_db = new DatabaseHandler(ConfigurationManager.AppSettings["DatabasePath"]!);
		_db.CreateTable<SeatReservation>();

		_seatData = seatData;

		LoadInfo();
	}

	void LoadInfo()
	{
		List<SeatReservation> seatReservations = _db.GetTable<SeatReservation>("SELECT * FROM SeatReservation WHERE uuid = '" + _seatData["Uuid"] + "' and row = '" +
		                              _seatData["Row"] + "' and column = '" + _seatData["Column"] + "';");
		
		Label.Content = "Seat number " + _seatData["Column"] + " in row " + _seatData["Row"];
		ForenameInput.Text = seatReservations[0].Forename;
		SurnameInput.Text = seatReservations[0].Surname;
		EmailInput.Text = seatReservations[0].Email;
	}
}