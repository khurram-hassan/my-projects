using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatteryMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            GetBatteryInfo();
        }

        private void GetBatteryInfo()
        {
            prgBattery.Value = 100.0;

            PowerStatus pwr = SystemInformation.PowerStatus;

            String strBatteryChargingStatus;
            strBatteryChargingStatus = pwr.BatteryChargeStatus.ToString();
            MessageBox.Show("battery charge status : " + batterystatus);

            String strBatterylife;
            strBatterylife = pwr.BatteryLifePercent.ToString();
            MessageBox.Show("Battery life: " + batterylife);
        }
    }
}
