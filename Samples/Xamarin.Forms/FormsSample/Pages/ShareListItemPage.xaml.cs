using System;
using System.Collections.Generic;
using AppServiceHelpers.Abstractions;
using Xamarin.Forms;
using Plugin.Media;
using Acr.UserDialogs;
using Plugin.Messaging;
using AppServiceHelpers;
using FormsSample.Models;
using FormsSample.DataStores;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppServiceHelpers.Forms;
using System.Text.RegularExpressions;
namespace FormsSample.Pages
{
	public partial class ShareListItemPage : ContentPage
	{
		Models.ShopListItem shoplistitem;
		ObservableCollection<Models.ShopListItem> theShopList;

		public ShareListItemPage(IEasyMobileServiceClient client, ObservableCollection<Models.ShopListItem> theItems)
		{
			InitializeComponent();
			theShopList = theItems;
		}

		async void OnSendEmailButtonClicked(object sender, EventArgs e)
		{
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				string emailAddress = emailRecipient.Text;
				string emailList = BuildShopList();

				if (emailAddress.Length > 0 && EmailValid(emailAddress))
				{
					// Use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc. 
					var email = new EmailMessageBuilder()
					  .To(emailAddress)
					  .Subject("Shopping List")
					  .Body("These are your Shopping list Items" + Environment.NewLine + Environment.NewLine + emailList)
					  .Build();

					emailMessenger.SendEmail(email);
					UserDialogs.Instance.Alert("Email Sent", "Your Shopping List has been to " + emailAddress);
				}
				else
				{
					UserDialogs.Instance.Alert("Email Format Error", "The email address is not in the correct format");
					return;
				}
			}
			else
			{
				UserDialogs.Instance.Alert("Email Unavailabe", "Unable to send Email");
				return;
			}
		}

		// Extract the ShopListItem Names from the shopping list and format into a relevant format for sendin in emai
		private string BuildShopList()
		{
			string emailList = "";
			int itemNumber = 1;


			foreach (var item in theShopList)
			{
				emailList += itemNumber + ". " + item.ListItemName + " - " + item.ItemBrand + Environment.NewLine;
				itemNumber++;
			}

			if (emailList.Length > 0)
				return emailList;
			else
				return "You have no items in your Shopping List";
		}

		private bool EmailValid(string emailAddress)
		{ 
			if (Regex.Match(emailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
				return true; //Valid email
			else
                return false; //Not valid email 
		}
	}
}
