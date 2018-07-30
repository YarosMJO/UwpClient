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
    public class DeparturesViewModel : ViewModelBase
    {
        Departure entity;
        Departure selected;
        DepartureService Departureservice;
        ObservableCollection<Departure> departures;

        INavigationService navService;

        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public Departure SelectedDeparture
        {
            get { return selected; }
            set
            {
                selected = value;
                Departure = selected;
                RaisePropertyChanged(() => SelectedDeparture);
            }
        }


        public DeparturesViewModel(INavigationService navigationService)
        {
            Departureservice = new DepartureService();
            navService = navigationService;

            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            Departure = new Departure();
        }

        async void Create()
        {
            await Departureservice.Create(Departure);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await Departureservice.Update(Departure);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await Departureservice.Delete(Departure.Id);
            Departure = new Departure();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Departures = new ObservableCollection<Departure>(await Departureservice.GetAll());
        }

        public ObservableCollection<Departure> Departures
        {
            get { return departures; }
            set
            {
                departures = value;
                RaisePropertyChanged(() => Departures);
            }
        }

        public Departure Departure
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Departure != null) DepartureId = Departure.Id;
                RaisePropertyChanged(() => Departure);
            }
        }

        int entityId = 0;
        public int DepartureId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => DepartureId);
            }
        }
    }
}
