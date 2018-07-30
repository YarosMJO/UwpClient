namespace UwpClient.ViewModels
{
    using AirportWebApi.DAL.Models;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;
    using global::UwpClient.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    namespace UwpClient.ViewModels
    {

        public class FlightAttendantsViewModel : ViewModelBase
        {
            FlightAttendant entity;
            FlightAttendant selected;
            FlightAttendantService flightAttendantservice;
            ObservableCollection<FlightAttendant> flightAttendants;

            INavigationService navService;

            public ICommand AddEntity { get; private set; }
            public ICommand UpdateEntity { get; private set; }
            public ICommand DeleteEntity { get; private set; }

            public FlightAttendant SelectedFlightAttendant
            {
                get { return selected; }
                set
                {
                    selected = value;
                    FlightAttendant = selected;
                    RaisePropertyChanged(() => SelectedFlightAttendant);
                }
            }


            public FlightAttendantsViewModel(INavigationService navigationService)
            {
                flightAttendantservice = new FlightAttendantService();
                navService = navigationService;

                AddEntity = new RelayCommand(Create);
                UpdateEntity = new RelayCommand(Update);
                DeleteEntity = new RelayCommand(Delete);

                LoadEntity().ConfigureAwait(false);
                FlightAttendant = new FlightAttendant();
            }


            async void Create()
            {
                await flightAttendantservice.Create(FlightAttendant);
                await LoadEntity().ConfigureAwait(false);
            }

            async void Update()
            {
                await flightAttendantservice.Update(FlightAttendant);
                await LoadEntity().ConfigureAwait(false);
            }

            async void Delete()
            {
                await flightAttendantservice.Delete(FlightAttendant.Id);
                FlightAttendant = new FlightAttendant();
                await LoadEntity().ConfigureAwait(false);
            }

            async Task LoadEntity()
            {
                FlightAttendants = new ObservableCollection<FlightAttendant>(await flightAttendantservice.GetAll());
            }

            public ObservableCollection<FlightAttendant> FlightAttendants
            {
                get { return flightAttendants; }
                set
                {
                    flightAttendants = value;
                    RaisePropertyChanged(() => FlightAttendants);
                }
            }

            public FlightAttendant FlightAttendant
            {
                get { return entity; }
                set
                {
                    entity = value;
                    if (FlightAttendant != null) FlightAttendantId = FlightAttendant.Id;
                    RaisePropertyChanged(() => FlightAttendant);
                }
            }

            int entityId = 0;
            public int FlightAttendantId
            {
                get { return entityId; }
                set
                {
                    entityId = value;
                    RaisePropertyChanged(() => FlightAttendantId);
                }
            }
        }
    }

}
