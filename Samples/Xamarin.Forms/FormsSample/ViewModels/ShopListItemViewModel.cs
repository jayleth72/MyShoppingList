using System;
using System.Windows.Input;
using Acr.UserDialogs;
using AppServiceHelpers.Abstractions;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;


namespace FormsSample.ViewModels
{
	public class ShopListItemViewModel : AppServiceHelpers.Forms.BaseAzureViewModel<Models.ShopListItem>
	{
		IEasyMobileServiceClient client;
		Models.ShopListItem shoplistitem;

		public ShopListItemViewModel(IEasyMobileServiceClient client, Models.ShopListItem shoplistitem) : base(client)
		{
			this.client = client;
			this.shoplistitem = shoplistitem;

			Title = shoplistitem.Id == null ? "Add Shopping list item" : "Edit Shopping list item";
		}

		public string ListItemName
		{
			get
			{
				return shoplistitem.ListItemName;
			}
			set
			{
				shoplistitem.ListItemName = value;
			}
		}

		public bool HaveItem
		{
			get
			{
				return shoplistitem.HaveItem;
			}
			set
			{
				shoplistitem.HaveItem = value;
			}
		}

		public double ItemCost
		{
			get
			{
				return shoplistitem.ItemCost;
			}
			set
			{
				shoplistitem.ItemCost = value;
			}
		}

		public string ItemBrand
		{
			get
			{
				return shoplistitem.ItemBrand;
			}
			set
			{
				shoplistitem.ItemBrand = value;
			}
		}

		public string LocalPhotoURI
		{
			get
			{
				return shoplistitem.LocalPhotoURI;
			}
			set
			{
				shoplistitem.LocalPhotoURI = value;
			}
		}

	

		private ICommand _saveItemCommand;
		public ICommand SaveItemCommand
		{
			get
			{
				_saveItemCommand = _saveItemCommand ?? new Command(async () =>
				{
					if (shoplistitem.Id == null)
					{
						await AddItemAsync(shoplistitem);
					}
					else
					{
						await UpdateItemAsync(shoplistitem);
					}
					var navigation = Application.Current.MainPage as NavigationPage;
					navigation.PopAsync();
				});
				return _saveItemCommand; ;
			}
		}

		private ICommand _deleteItemCommand;
		public ICommand DeleteItemCommand
		{
			get
			{
				_deleteItemCommand = _deleteItemCommand ?? new Command(async () =>
				{
					var result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to delete this Shopping List Item?",
						"Delete Shopping List Item");


					if (!result)
					{
						return;
					}
					await DeleteItemAsync(shoplistitem);

					var navigation = Application.Current.MainPage as NavigationPage;
					navigation.PopAsync();


				});
				return _deleteItemCommand; ;
			}
		}


	}
}
