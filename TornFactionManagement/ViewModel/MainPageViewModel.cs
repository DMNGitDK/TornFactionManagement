using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TornFactionManagement.Model.ApiModel;
using TornFactionManagement.Services;

namespace TornFactionManagement.ViewModel
{
    internal partial class MainPageViewModel : ObservableObject
    {
        private readonly TornAPIServices tornAPIServices;

        public MainPageViewModel()
        {
            tornAPIServices = new TornAPIServices();
            
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string position;

        [ObservableProperty]
        private string onlineStatus;

        [ObservableProperty]
        private ObservableCollection<TornApiResponseMembers> factionMembers;

        [RelayCommand]
        private async Task LoadFactionMembers()

        {
             
            var response = await tornAPIServices.GetData("faction", "basic");
            if (response != null)
            {
                Debug.WriteLine(response);
            }
        }
    }
}
