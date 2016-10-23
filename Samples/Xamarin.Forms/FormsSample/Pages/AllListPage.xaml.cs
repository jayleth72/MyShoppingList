using System;
using System.Collections.Generic;
using AppServiceHelpers;
using AppServiceHelpers.Abstractions;
using FormsSample.ViewModels;
using Xamarin.Forms;

namespace FormsSample.Pages
{
	public partial class AllListPage : ContentPage
	{
		public AllListPage()
		{
		}

		public AllListPage(IEasyMobileServiceClient client)
		{
			InitializeComponent();
			BindingContext = new ViewModels.AllListViewModel(client);

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var vm = (AllListViewModel)BindingContext;
			vm.RefreshCommand.Execute(null);
		}
	}
}