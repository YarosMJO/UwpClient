using UwpClient.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            myFrame.Navigate(typeof(HomeView));
            TitleTextBlock.Text = "Main";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                myFrame.Navigate(typeof(HomeView));
                TitleTextBlock.Text = "Home";
            }
            else if (Flights.IsSelected)
            {
                myFrame.Navigate(typeof(FlightView));
                TitleTextBlock.Text = "Flights";
            }
            else if (Departures.IsSelected)
            {
                myFrame.Navigate(typeof(DepartureView));
                TitleTextBlock.Text = "Departures";
            }
            else if (Crews.IsSelected)
            {
                myFrame.Navigate(typeof(CrewView));
                TitleTextBlock.Text = "Crews";
            }
            else if (Pilots.IsSelected)
            {
                myFrame.Navigate(typeof(PilotView));
                TitleTextBlock.Text = "Pilots";
            }
            else if (FlightAttendant.IsSelected)
            {
                myFrame.Navigate(typeof(FlightAttendantView));
                TitleTextBlock.Text = "FlightAttendant";
            }
            else if (Plane.IsSelected)
            {
                myFrame.Navigate(typeof(PlaneView));
                TitleTextBlock.Text = "Plane";
            }
            else if (PlaneType.IsSelected)
            {
                myFrame.Navigate(typeof(PlaneTypeView));
                TitleTextBlock.Text = "PlaneType";
            }
            else if (Tickets.IsSelected)
            {
                myFrame.Navigate(typeof(TicketView));
                TitleTextBlock.Text = "Tickets";
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}