using System;
using AppServiceHelpers;
using Acr.UserDialogs;
using FormsSample.Models;
using FormsSample.DataStores;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppServiceHelpers.Abstractions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppServiceHelpers.Forms;

namespace FormsSample.ViewModels
{
	public class AllListViewModel : BaseAzureViewModel<ShopListItem>
	{
		
		IEasyMobileServiceClient client;
		public AllListViewModel(IEasyMobileServiceClient client) : base(client)
		{
			this.client = client;

			Title = "My Shopping List";

		}

		//When list item is selected
		Models.ShopListItem selectedListItem;
		public Models.ShopListItem SelectedListItem
		{
			get { return selectedListItem; }
			set
			{
				selectedListItem = value;
				OnPropertyChanged("SelectedItem");

				if (selectedListItem != null)
				{
					var navigation = Application.Current.MainPage as NavigationPage;
					navigation.PushAsync(new Pages.UpdateListItemPage(client, selectedListItem));
					SelectedListItem = null;
				}
			}
		}

		private ICommand _addNewItemCommand;
		public ICommand AddNewItemCommand
		{
			get
			{
				_addNewItemCommand = _addNewItemCommand ?? new Command(() =>
				{
					var navigation = Application.Current.MainPage as NavigationPage;
					navigation.PushAsync(new Pages.ShopListItemPage(client, new ShopListItem()));
				});
				return _addNewItemCommand;
			}
		}

		private ICommand _shareListCommand;
		public ICommand ShareListCommand
		{
			get
			{
				_shareListCommand = _shareListCommand ?? new Command(() =>
				{
					var navigation = Application.Current.MainPage as NavigationPage;
					navigation.PushAsync(new Pages.ShareListItemPage(client, Items));
				});
				return _shareListCommand;
			}
		}

	}
}


