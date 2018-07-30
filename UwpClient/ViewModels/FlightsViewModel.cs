using AirportWebApi.DAL.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpClient.Services;

namespace UwpClient.ViewModels
{
    public class FlightsViewModel : ViewModelBase
    {
        FlightService flightservice;
        INavigationService navService;

        ObservableCollection<Flight> flights;
        public ObservableCollection<Flight> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        private Flight entity;
        public Flight Flight
        {
            get
            {
                return entity;
            }
            set
            {
                entity = value;
                if (Flight != null)
                {
                    FlightId = Flight.Id;
                }
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

        private Flight selected;
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

        async Task LoadEntity()
        {
            Flights = new ObservableCollection<Flight>();
            foreach (var flight in await flightservice.GetAll())
            {
                Flights.Add(flight);
            }
        }

        public FlightsViewModel(INavigationService navigationService)
        {
            navService = navigationService;
            flightservice = new FlightService();
            LoadEntity().ConfigureAwait(false);
            Flight = new Flight();
        }




    }
}
