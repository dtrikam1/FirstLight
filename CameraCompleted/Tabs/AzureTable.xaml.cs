using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Tabs.DataModels;
using Xamarin.Forms;

namespace Tabs
{
    public partial class AzureTable : ContentPage
    {
		MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;

        public AzureTable()
        {
            InitializeComponent();
        }

		async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            List<FirstLightLandMarkInformation> notHotDogInformation = await AzureManager.AzureManagerInstance.GetFirstLightLandMarkInformation();

			FirstLightLandMarkInformationList.ItemsSource = notHotDogInformation;
        }
    }
}
