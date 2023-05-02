using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KinoRezervejsnJednoduche.Model;
using KinoRezervejsnJednoduche.Pages;
using KinoRezervejsnJednoduche.Windows;
using Newtonsoft.Json;

namespace kinoRezervejsnJednoduche.Pages;

public partial class HallPage : Page
{
	Movie _movie;
	
	public HallPage(Movie movie)
	{
		InitializeComponent();
		_movie = movie;
		
		PrintHall();
	}

	// Print Hall
	void PrintHall()
	{
		// Get All Styles
		Style rowStyle = (FindResource("Row") as Style)!;
		Style rowNumberStyle = (FindResource("RowNumber") as Style)!;
		Style seatStyle = (FindResource("Seat") as Style)!;
		
		// Every Row In Hall
		for (int row = 1; row <= _movie.Cinema.Rows; row++)
		{
			// Set SeatRow
			StackPanel seatRow = new StackPanel();
			seatRow.Style = rowStyle;

			// Seat Number of Left Row
			TextBlock rowNumberL = new TextBlock();
			rowNumberL.Style = rowNumberStyle;
			rowNumberL.Text = row.ToString();
			
			// Seat Number of Right Row
			TextBlock rowNumberR = new TextBlock();
			rowNumberR.Style = rowNumberStyle;
			rowNumberR.Text = row.ToString();

			// Every Column In Hall
			for (int seat = 1; seat <= _movie.Cinema.Columns; seat++)
			{
				// Set Seat Info
				Dictionary<string, string> seatData = new Dictionary<string, string>
				{
					{ "Row", row.ToString() },
					{ "Column", seat.ToString() },
					{ "Uuid", _movie.Uuid }
				};
				
				Button seatBtn = new Button();
				
				// Add Event, Seat Info, Style 
				seatBtn.Click += ReservationPopUp;
				seatBtn.Tag = JsonConvert.SerializeObject(seatData);
				seatBtn.Style = seatStyle;
				
				// Insert Seat In To Row
				seatBtn.Content = seat.ToString();
				seatRow.Children.Add(seatBtn);
			}
			
			// Print All Rows
			RowNumberL.Children.Add(rowNumberL);
			RowNumberR.Children.Add(rowNumberR);
			SeatStackPanel.Children.Add(seatRow);
		}
	}

	// Show Reservation PopUp Window
	void ReservationPopUp(object sender, RoutedEventArgs e)
	{
		Button element = (Button)sender;
		Dictionary<string, string> seatData = JsonConvert.DeserializeObject<Dictionary<string, string>>((string)element.Tag)!;
		
		SeatReservationWindow seatReservationWindow = new SeatReservationWindow(seatData);
		seatReservationWindow.Show();
	}

	// Back to ListView
	void Back(object sender, RoutedEventArgs e)
	{
		NavigationService!.Navigate(new ListViewPage());
	}
}