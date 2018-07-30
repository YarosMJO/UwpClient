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
    public class PlanesViewModel : ViewModelBase
    {
        Plane entity;
        Plane selected;
        PlaneService Planeservice;
        ObservableCollection<Plane> planes;

        INavigationService navService;

        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public Plane SelectedPlane
        {
            get { return selected; }
            set
            {
                selected = value;
                Plane = selected;
                RaisePropertyChanged(() => SelectedPlane);
            }
        }


        public PlanesViewModel(INavigationService navigationService)
        {
            Planeservice = new PlaneService();
            navService = navigationService;

            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            Plane = new Plane();
        }

        async void Create()
        {
            await Planeservice.Create(Plane);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await Planeservice.Update(Plane);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await Planeservice.Delete(Plane.Id);
            Plane = new Plane();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Planes = new ObservableCollection<Plane>(await Planeservice.GetAll());
        }

        public ObservableCollection<Plane> Planes
        {
            get { return planes; }
            set
            {
                planes = value;
                RaisePropertyChanged(() => Planes);
            }
        }

        public Plane Plane
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Plane != null) PlaneId = Plane.Id;
                RaisePropertyChanged(() => Plane);
            }
        }

        int entityId = 0;
        public int PlaneId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => PlaneId);
            }
        }
    }
}
