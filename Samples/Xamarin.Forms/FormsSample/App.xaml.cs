using System.Threading.Tasks;
using AppServiceHelpers;
using AppServiceHelpers.Abstractions;
using AppServiceHelpers.Utils;
using FormsSample.DataStores;
using FormsSample.Models;
using Xamarin.Forms;

namespace FormsSample
{
    public partial class App : Application
    {
        IEasyMobileServiceClient client;
        public App()
        {
            InitializeComponent();

            client = new EasyMobileServiceClient();
            client.Initialize("http://todojayleth.azurewebsites.net/");
            client.RegisterTable<ShopListItem>();
            client.FinalizeSchema();

            MainPage = new NavigationPage(new Pages.MainMenuPage(client));
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

