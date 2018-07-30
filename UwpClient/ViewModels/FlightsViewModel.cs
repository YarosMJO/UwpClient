using AirportWebApi.DAL.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpClient.Services;

namespace UwpClient.ViewModels
{
    public class FlightsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Flight entity;
        Flight selected;
        FlightService flightservice;
        ObservableCollection<Flight> flights;

        INavigationService navService;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public FlightsViewModel(INavigationService navService)
        {
            NewEntity = new RelayCommand(New);
            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);
            flightservice = new FlightService();
            this.navService = navService;
            LoadEntity().ConfigureAwait(false);
            Flight = new Flight();
        }

        void New()
        {
            Flight = new Flight();
        }

        async void Delete()
        {
            await flightservice.Delete(FlightId);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await flightservice.Update(Flight);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Create()
        {
            await flightservice.Create(Flight);
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Flights = new ObservableCollection<Flight>(await flightservice.GetAll());
        }

        public ObservableCollection<Flight> Flights
        {
            get { return flights; }
            set
            {
                flights = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        public Flight Flight
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Flight != null) FlightId = Flight.Id;
                RaisePropertyChanged(() => Flight);
            }
        }

        int entityId = 0;
        public int FlightId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => FlightId);
            }
        }


        public Flight SelectedFlight
        {
            get { return selected; }
            set
            {
                selected = value;
                Flight = selected;
                RaisePropertyChanged(() => SelectedFlight);
            }
        }

    }
}
