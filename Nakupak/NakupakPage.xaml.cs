using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nakupak
{
	public partial class NakupakPage : ContentPage
	{
		public NakupakPage()
		{
			InitializeComponent();
			fill();
		}

		/// <summary>
		/// Třída která se provede při navratu na tuto stranku
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			fill();

		}

		/// <summary>
		/// Otevření stránky s detailem po kliknutí
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public async void SelectedItemMethod(object sender, ItemTappedEventArgs e)
		{
			////vytvoření Item s přijatímy daty
			Item item = e.Item as Item;
			//přičte k množstí 1
			item.Quantity = item.Quantity + 1;
			//vytvoření spojení s db
			var dbConnection = App.Database;
			//db uživatelu
			Database userDatabase = App.Database;
			//zapis(update) dat do db
			await App.Database.SaveItemAsync(item);
			//počkej pro stabilitu
			await Task.Delay(1);
			fill();
		}

		/// <summary>
		/// Odkaz na stránku přidání nové polozky
		/// </summary>
		/// <returns>-------</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void pridat(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new NewItem());
		}

		public void sdilet(object sender, EventArgs args)
		{
			string content = "Prosím koupit: ";
			int price = 0;
			var dbConnection = App.Database;
			Database personDatabase = App.Database;
			List<Item> derp = App.Database.GetItemsAsync().Result;
			foreach (var item in derp)
			{
				content += item.Quantity + "x " + item.Name + ", ";
				price = price + item.Price;
			}
			content += "Dobrou náladu. Bude to stát přibližně "+price+"Kč";
			Navigation.PushModalAsync(new Send(content));
		}
		/// <summary>
		/// Naplní ListView
		/// </summary>
		public void fill()
		{
			var dbConnection = App.Database;
			Database personDatabase = App.Database;
			ListViewFormatted.ItemsSource = App.Database.GetItemsAsync().Result;

		}

		/// <summary>
		/// Možnost editace jednotlivích položek
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void OnEdit(object sender, EventArgs e)
		{
			//var mi = ((MenuItem)sender);
			DisplayAlert("Ops :-)", "Tato možnost zatím není možná, smažte položku a vytvořte si jí znovu.", "OK");

		}

		/// <summary>
		/// Možnost smazání položky
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);

			int derp = (int)mi.CommandParameter;
			//vytvoření spojení s db
			var dbConnection = App.Database;
			//db věcí
			Database items = App.Database;
			//přikaz smaž
			App.Database.DeleteItemAsync(App.Database.GetItemAsync(derp).Result);
			//čekej pro stabilitu
			Task.Delay(1);
			//vrat se na domovskou obrazovku
			//Navigation.PopToRootAsync();
			fill();
			//hlaška
			DisplayAlert("Smazano", "Prvek s ID: " + derp + " byl smazán.", "OK");
		}
	}
}
