using AirportWebApi.DAL.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpClient.Services;

namespace UwpClient.ViewModels
{

    public class PilotsViewModel : ViewModelBase
    {
        Pilot entity;
        Pilot selected;
        PilotService Pilotservice;
        ObservableCollection<Pilot> pilots;

        INavigationService navService;

        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public Pilot SelectedPilot
        {
            get { return selected; }
            set
            {
                selected = value;
                Pilot = selected;
                RaisePropertyChanged(() => SelectedPilot);
            }
        }


        public PilotsViewModel(INavigationService navigationService)
        {
            Pilotservice = new PilotService();
            navService = navigationService;

            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            Pilot = new Pilot();
        }


        async void Create()
        {
            await Pilotservice.Create(Pilot);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await Pilotservice.Update(Pilot);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await Pilotservice.Delete(Pilot.Id);
            Pilot = new Pilot();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Pilots = new ObservableCollection<Pilot>(await Pilotservice.GetAll());
        }

        public ObservableCollection<Pilot> Pilots
        {
            get { return pilots; }
            set
            {
                pilots = value;
                RaisePropertyChanged(() => Pilots);
            }
        }

        public Pilot Pilot
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Pilot != null) PilotId = Pilot.Id;
                RaisePropertyChanged(() => Pilot);
            }
        }

        int entityId = 0;
        public int PilotId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => PilotId);
            }
        }
    }
}
