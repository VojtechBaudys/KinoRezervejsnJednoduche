using KinoRezervejsnJednoduche.Pages;
using MahApps.Metro.Controls;

namespace kinoRezervejsnJednoduche
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			// CinemaGenerator();
			Frame.NavigationService.Navigate(new ListViewPage());
		}
	}
}