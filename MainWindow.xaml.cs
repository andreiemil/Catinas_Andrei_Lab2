using System.Windows;
using System.Windows.Input;

namespace Catinas_Andrei_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new
            DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);
        }

        private void glazedMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = true;
            sugarMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void sugarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedMenuItem.IsChecked = false;
            sugarMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void lemonMenItem_Click(object sender, RoutedEventArgs e)
        {
            chocolateMenuItem.IsChecked = false;
            vanillaMenuItem.IsChecked = false;
            lemonMenItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Lemon);
        }

        private void chocolateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonMenItem.IsChecked = false;
            vanillaMenuItem.IsChecked = false;
            chocolateMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Chocolate);
        }

        private void vanillaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonMenItem.IsChecked = false;
            chocolateMenuItem.IsChecked = false;
            vanillaMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Vanilla);
        }
        private void stopMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }
        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;
                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled.Text = mFilledLemon.ToString();
                    break;
                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled.Text = mFilledChocolate.ToString();
                    break;
                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled.Text = mFilledVanilla.ToString();
                    break;
            }
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
