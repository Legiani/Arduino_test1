using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nakupak
{
	public partial class NewItem : ContentPage
	{
		public NewItem()
		{
			InitializeComponent();
		}

		public void ulozit(object sender, EventArgs args)
		{
			//vytvoření spojení s db
			var dbConnection = App.Database;
			//db uživatelu
			Database userDatabase = App.Database;

			//list pro dočasne uložení
			Item item = new Item();
			item.Name = nazev.Text;
			item.Price = Convert.ToInt16(cena.Text);
			item.Quantity = Convert.ToInt16(mnozstvi.Text);


			//zapis dat do db
			App.Database.SaveItemAsync(item);
			//počkej pro stabilitu
			Task.Delay(1);
			//vrat se na domovskou obrazovku
			Navigation.PopModalAsync();


		}
	}
}
