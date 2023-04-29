using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using KinoRezervejsnJednoduche.Model;
using kinoRezervejsnJednoduche.Pages;
using KinoRezervejsnJednoduche.Service;

namespace KinoRezervejsnJednoduche.Pages;

public partial class ListViewPage : Page
{
	private SaveManager _saveManager;
	
	public ListViewPage()
	{
		_saveManager = new SaveManager();
		InitializeComponent();
		
		RenderData();
	}

	void RenderData()
	{
		Movie[] movies = _saveManager.LoadData<Movie[]>("Resource/Data/movies.json");
		ListView.ItemsSource = movies;
	}
	
	void ListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		NavigationService!.Navigate(new HallPage((Movie)((sender as ListView)!).SelectedItem));
	}
}