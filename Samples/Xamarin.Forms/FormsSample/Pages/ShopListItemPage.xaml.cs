using System;
using System.Collections.Generic;
using AppServiceHelpers.Abstractions;
using Xamarin.Forms;
using Plugin.Media;
using Acr.UserDialogs;

namespace FormsSample.Pages
{
	public partial class ShopListItemPage : ContentPage
	{
		Models.ShopListItem shoplistitem;

		public ShopListItemPage(IEasyMobileServiceClient client, Models.ShopListItem shoplistitem)
		{
			InitializeComponent();

			var viewModel = new ViewModels.ShopListItemViewModel(client, shoplistitem);
			BindingContext = viewModel;
			this.shoplistitem = shoplistitem;
		}

		async void TakePhotoButtonClicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				UserDialogs.Instance.Alert("No Camera", "No camera available.");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				//Save to photo gallery on phone and retrieved using LocalPhotoURI stored in backend
				SaveToAlbum = true,
				Name = "image1.jpg"
			});

			if (file == null)
				return;


			shoplistitem.LocalPhotoURI = file.Path;

			ItemImage.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});

		}

	}
}
