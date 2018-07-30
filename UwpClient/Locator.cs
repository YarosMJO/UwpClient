using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UwpClient.ViewModels;
using UwpClient.ViewModels.UwpClient.ViewModels;
using UwpClient.Views;

namespace UwpClient
{
    public class Locator
    {
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(FlightsViewModel), typeof(FlightView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<TicketsViewModel>();
            SimpleIoc.Default.Register<FlightsViewModel>();
            SimpleIoc.Default.Register<DeparturesViewModel>();
            SimpleIoc.Default.Register<CrewsViewModel>();
            SimpleIoc.Default.Register<PilotsViewModel>();
            SimpleIoc.Default.Register<FlightAttendantsViewModel>();
            SimpleIoc.Default.Register<PlanesViewModel>();
            SimpleIoc.Default.Register<PlaneTypesViewModel>();

        }

        public TicketsViewModel TicketsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TicketsViewModel>();
            }
        }
        public FlightsViewModel FlightsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlightsViewModel>();
            }
        }
        public DeparturesViewModel DeparturesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DeparturesViewModel>();
            }
        }
        public CrewsViewModel CrewsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CrewsViewModel>();
            }
        }
        public PilotsViewModel PilotsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PilotsViewModel>();
            }
        }
        public FlightAttendantsViewModel FlightAttendantsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlightAttendantsViewModel>();
            }
        }

        public PlanesViewModel PlanesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlanesViewModel>();
            }
        }
        public PlaneTypesViewModel PlaneTypesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlaneTypesViewModel>();
            }
        }

        public static void Cleanup()
        {

        }
    }
}
