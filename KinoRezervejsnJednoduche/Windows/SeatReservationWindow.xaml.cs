using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using KinoRezervejsnJednoduche.Model;
using kinoRezervejsnJednoduche.Pages;
using KinoRezervejsnJednoduche.Service;

namespace KinoRezervejsnJednoduche.Windows;

public partial class SeatReservationWindow : Window
{
	Dictionary<string, string> _seatData;
	ValidationManager _validationManager;
	DatabaseHandler _db;
	HallPage _hallPage;
	
	public SeatReservationWindow(Dictionary<string, string> seatData, HallPage hallPage)
	{
		// DB
		_db = new DatabaseHandler(ConfigurationManager.AppSettings["DatabasePath"]!);
		_db.CreateTable<SeatReservation>();
		
		_seatData = seatData;
		_hallPage = hallPage;
		_validationManager = new ValidationManager();
		
		InitializeComponent();

		LoadForm();
	}

	// Set Form Title
	void LoadForm()
	{
		Label.Content = "Seat number " + _seatData["Column"] + " in row " + _seatData["Row"];
	}

	// Handle Form Submit
	async void SubmitForm(object sender, RoutedEventArgs e)
	{
		string errorMsg = "Enter valid information";
		bool valid = true;

		// Validate inputs
		valid = _validationManager.ValidateName(ForenameInput.Text) && valid;
		valid = _validationManager.ValidateName(SurnameInput.Text) && valid;
		valid = _validationManager.ValidateEmail(EmailInput.Text) && valid;
	
		if (valid)
		{
			// Set Model
			SeatReservation seatReservation = new SeatReservation();

			seatReservation.Uuid = _seatData["Uuid"];
			seatReservation.Row = _seatData["Row"];
			seatReservation.Column = _seatData["Column"];
			seatReservation.Forename = ForenameInput.Text;
			seatReservation.Surname = SurnameInput.Text;
			seatReservation.Email = EmailInput.Text;

			// Save to DB
			_db.InsertToDatabase(seatReservation);
			
			// Hide PopUp Window
			Hide();
			_hallPage.PrintHall();
		}
		else
		{
			// Error msg
			ErrorBox.Text = errorMsg;
			await Task.Delay(2000);
			ErrorBox.Text = "";
		}
	}
}