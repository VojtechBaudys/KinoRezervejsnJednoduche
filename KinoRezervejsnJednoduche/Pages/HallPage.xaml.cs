using System.Windows;
using System.Windows.Controls;
using KinoRezervejsnJednoduche.Model;
using KinoRezervejsnJednoduche.Pages;
using KinoRezervejsnJednoduche.Service;

namespace kinoRezervejsnJednoduche.Pages;

public partial class HallPage : Page
{
	SaveManager _saveManager;
	Movie _movie;
	
	public HallPage(Movie movie)
	{
		InitializeComponent();
		_saveManager = new SaveManager();
		_movie = movie;
		
		PrintHall();
	}

	void PrintHall()
	{
		
	}

	void Back(object sender, RoutedEventArgs e)
	{
		NavigationService!.Navigate(new ListViewPage());
	}
}