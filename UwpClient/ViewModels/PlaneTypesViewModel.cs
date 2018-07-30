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
    public class PlaneTypesViewModel : ViewModelBase
    {
        PlaneType entity;
        PlaneType selected;
        PlaneTypeService PlaneTypeservice;
        ObservableCollection<PlaneType> planeTypes;

        INavigationService navService;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public PlaneType SelectedPlaneType
        {
            get { return selected; }
            set
            {
                selected = value;
                PlaneType = selected;
                RaisePropertyChanged(() => SelectedPlaneType);
            }
        }


        public PlaneTypesViewModel(INavigationService navigationService)
        {
            PlaneTypeservice = new PlaneTypeService();
            navService = navigationService;

            NewEntity = new RelayCommand(New);
            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            PlaneType = new PlaneType();
        }


        void New()
        {
            PlaneType = new PlaneType();
        }

        async void Create()
        {
            await PlaneTypeservice.Create(PlaneType);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await PlaneTypeservice.Update(PlaneType);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await PlaneTypeservice.Delete(PlaneType.Id);
            PlaneType = new PlaneType();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            PlaneTypes = new ObservableCollection<PlaneType>(await PlaneTypeservice.GetAll());
        }

        public ObservableCollection<PlaneType> PlaneTypes
        {
            get { return planeTypes; }
            set
            {
                planeTypes = value;
                RaisePropertyChanged(() => PlaneTypes);
            }
        }

        public PlaneType PlaneType
        {
            get { return entity; }
            set
            {
                entity = value;
                if (PlaneType != null) PlaneTypeId = PlaneType.Id;
                RaisePropertyChanged(() => PlaneType);
            }
        }

        int entityId = 0;
        public int PlaneTypeId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => PlaneTypeId);
            }
        }
    }
}