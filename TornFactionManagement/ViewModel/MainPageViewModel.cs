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
            FactionMembers = new ObservableCollection<TornApiResponseMembers>();
            LoadFactionMembersCommand = new Command(async () => await LoadFactionMembersAsync());

        }

        [ObservableProperty]
        private ObservableCollection<TornApiResponseMembers> factionMembers;

        public Command LoadFactionMembersCommand { get; }

        private async Task LoadFactionMembersAsync()
        {
            var response = await tornAPIServices.GetData("faction", "basic");
            if (response != null && response.Members != null)
            {
                FactionMembers.Clear();
                foreach (var member in response.Members)
                {
                    factionMembers.Add(member); 
                    Debug.WriteLine(member.Name);
                }
            }
        }


        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string position;

        [ObservableProperty]
        private string onlineStatus;

    }
}
