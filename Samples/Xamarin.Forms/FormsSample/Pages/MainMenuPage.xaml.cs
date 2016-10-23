using System;
using System.Collections.Generic;
using AppServiceHelpers;
using AppServiceHelpers.Abstractions;
using FormsSample.ViewModels;
using Xamarin.Forms;

namespace FormsSample.Pages
{
	public partial class MainMenuPage : ContentPage
	{
		IEasyMobileServiceClient client;

		public MainMenuPage(IEasyMobileServiceClient client)
		{
			InitializeComponent();
			this.client = client;
		}


		async void OnAllListsButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AllListPage(client));

		}


		async void AboutButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());

		}
	}
}

