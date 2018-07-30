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
    public class CrewsViewModel : ViewModelBase
    {
        Crew entity;
        Crew selected;
        CrewService Crewservice;
        ObservableCollection<Crew> crews;

        INavigationService navService;

        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public Crew SelectedCrew
        {
            get { return selected; }
            set
            {
                selected = value;
                Crew = selected;
                RaisePropertyChanged(() => SelectedCrew);
            }
        }


        public CrewsViewModel(INavigationService navigationService)
        {
            Crewservice = new CrewService();
            navService = navigationService;

            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            Crew = new Crew();
        }

        async void Create()
        {
            await Crewservice.Create(Crew);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await Crewservice.Update(Crew);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await Crewservice.Delete(Crew.Id);
            Crew = new Crew();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Crews = new ObservableCollection<Crew>(await Crewservice.GetAll());
        }

        public ObservableCollection<Crew> Crews
        {
            get { return crews; }
            set
            {
                crews = value;
                RaisePropertyChanged(() => Crews);
            }
        }

        public Crew Crew
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Crew != null) CrewId = Crew.Id;
                RaisePropertyChanged(() => Crew);
            }
        }

        int entityId = 0;
        public int CrewId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => CrewId);
            }
        }
    }
}
