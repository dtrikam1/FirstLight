using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Tabs.DataModels;

namespace Tabs
{
    public class AzureManager
    {
		private static AzureManager instance;
        private MobileServiceClient client;
		private IMobileServiceTable<FirstLightLandMarkInformation> firstLightLandMarkInformation;

        private AzureManager()
        {
			this.client = new MobileServiceClient("https://firstlightamanti.azurewebsites.net/");
			this.firstLightLandMarkInformation = this.client.GetTable<FirstLightLandMarkInformation>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

		public async Task<List<FirstLightLandMarkInformation>> GetFirstLightLandMarkInformation()
        {
			return await this.firstLightLandMarkInformation.ToListAsync();
        }
    }
}
