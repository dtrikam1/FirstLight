using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Tabs.DataModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Tabs
{
    public partial class AzureTable : ContentPage
    {
		MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;
		Geocoder geoCoder;

        public AzureTable()
        {
            InitializeComponent();
			geoCoder = new Geocoder();
        }

		async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            loading.IsRunning = true;
			List<FirstLightLandMarkInformation> firstLightLandMarkInformation = await AzureManager.AzureManagerInstance.GetFirstLightLandMarkInformation();

			foreach (FirstLightLandMarkInformation model in firstLightLandMarkInformation)
            {
                var position = new Position(model.Latitude, model.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                foreach (var address in possibleAddresses)
                    model.City = address;
            }

			FirstLightLandMarkInformationList.ItemsSource = firstLightLandMarkInformation;

            loading.IsRunning = false;
        }
    }
}



