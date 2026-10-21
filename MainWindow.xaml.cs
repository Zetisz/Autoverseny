using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Autoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Random r = new Random();
        private double celvonal = 650;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Mozog(Auto);
        }

        private void Mozog(Button auto)
        {
            double aktualispozicio = Canvas.GetLeft(auto);
            double sebesseg = r.Next(1, 6);
            double ujpozicio = aktualispozicio + sebesseg;
            Canvas.SetLeft(auto, ujpozicio);
            if (ujpozicio >= celvonal)
            {
                timer.Stop();
                MessageBox.Show($"Az autó célba ért.");
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(Auto, 20);
            timer.Start();
        }
    }
}