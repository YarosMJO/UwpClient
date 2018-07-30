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
    public class TicketsViewModel : ViewModelBase
    {
        Ticket entity;
        Ticket selected;
        TicketService Ticketservice;
        ObservableCollection<Ticket> tickets;

        INavigationService navService;

        public ICommand RefreshEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public Ticket SelectedTicket
        {
            get { return selected; }
            set
            {
                selected = value;
                Ticket = selected;
                RaisePropertyChanged(() => SelectedTicket);
            }
        }


        public TicketsViewModel(INavigationService navigationService)
        {
            Ticketservice = new TicketService();
            navService = navigationService;

            RefreshEntity = new RelayCommand(Refresh);
            AddEntity = new RelayCommand(Create);
            UpdateEntity = new RelayCommand(Update);
            DeleteEntity = new RelayCommand(Delete);

            LoadEntity().ConfigureAwait(false);
            Ticket = new Ticket();
        }


        void Refresh()
        {
            Ticket = new Ticket();
        }

        async void Create()
        {
            await Ticketservice.Create(Ticket);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Update()
        {
            await Ticketservice.Update(Ticket);
            await LoadEntity().ConfigureAwait(false);
        }

        async void Delete()
        {
            await Ticketservice.Delete(Ticket.Id);
            Ticket = new Ticket();
            await LoadEntity().ConfigureAwait(false);
        }

        async Task LoadEntity()
        {
            Tickets = new ObservableCollection<Ticket>(await Ticketservice.GetAll());
        }

        public ObservableCollection<Ticket> Tickets
        {
            get { return tickets; }
            set
            {
                tickets = value;
                RaisePropertyChanged(() => Tickets);
            }
        }

        public Ticket Ticket
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Ticket != null) TicketId = Ticket.Id;
                RaisePropertyChanged(() => Ticket);
            }
        }

        int entityId = 0;
        public int TicketId
        {
            get { return entityId; }
            set
            {
                entityId = value;
                RaisePropertyChanged(() => TicketId);
            }
        }
    }
}
