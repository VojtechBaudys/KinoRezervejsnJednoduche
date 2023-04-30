using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KinoRezervejsnJednoduche.Model;
using KinoRezervejsnJednoduche.Pages;
using KinoRezervejsnJednoduche.Service;

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

	void PrintHall()
	{
		Style rowStyle = (FindResource("Row") as Style)!;
		Style rowNumberStyle = (FindResource("RowNumber") as Style)!;
		Style seatStyle = (FindResource("Seat") as Style)!;


		for (int row = 1; row <= _movie.Cinema.Rows; row++)
		{
			StackPanel seatRow = new StackPanel();
			seatRow.Style = rowStyle;

			TextBlock rowNumberL = new TextBlock();
			rowNumberL.Style = rowNumberStyle;
			rowNumberL.Text = row.ToString();

			TextBlock rowNumberR = new TextBlock();
			rowNumberR.Style = rowNumberStyle;
			rowNumberR.Text = row.ToString();

			for (int seat = 1; seat <= _movie.Cinema.Columns; seat++)
			{
				Button seatBtn = new Button();

				seatBtn.Style = seatStyle;
				seatBtn.Content = seat.ToString();
				seatRow.Children.Add(seatBtn);
			}
			
			RowNumberL.Children.Add(rowNumberL);
			RowNumberR.Children.Add(rowNumberR);
			SeatStackPanel.Children.Add(seatRow);
		}
	}

	void Back(object sender, RoutedEventArgs e)
	{
		NavigationService!.Navigate(new ListViewPage());
	}
}