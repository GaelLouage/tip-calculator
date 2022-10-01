using System;
using System.Windows;
using System.Windows.Controls;

namespace TipCalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bill _bill = new Bill();
        public MainWindow()
        {
            InitializeComponent();
            txtCustomPercentage.Visibility = Visibility.Hidden;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lblTipAmount.Content = "0.00";
            lblTotal.Content = "0.00";
            txtBill.Text = string.Empty;
            txtNumberOfPeople.Text = string.Empty;
            Custom.Visibility = Visibility.Visible;
            txtCustomPercentage.Visibility = Visibility.Hidden;
            txtCustomPercentage.Text = string.Empty;
        }

        private void btn5Percent_Click(object sender, RoutedEventArgs e)
        {
            _bill.TipPercentage = 5;
            UpdateUI();
        }

        private void btn10Percent_Click(object sender, RoutedEventArgs e)
        {
            _bill.TipPercentage = 10;
            UpdateUI();
        }

        private void btn15Percent_Click(object sender, RoutedEventArgs e)
        {
            _bill.TipPercentage = 15;
            UpdateUI();
        }

        private void btn25Percent_Click(object sender, RoutedEventArgs e)
        {
            _bill.TipPercentage = 25;
            UpdateUI();
        }

        private void btn50Percent_Click(object sender, RoutedEventArgs e)
        {
            _bill.TipPercentage = 50;
            UpdateUI();
        }
   
        private void UpdateUI()
        {
            if (!string.IsNullOrEmpty(txtBill.Text) && !string.IsNullOrEmpty(txtNumberOfPeople.Text))
            {
                txtBill.Text = txtBill.Text.Replace(".", ",");
                if (int.TryParse(txtNumberOfPeople.Text, out int numberOfPeople) && double.TryParse(txtBill.Text, out double bill))
                {
                    if (!string.IsNullOrEmpty(txtCustomPercentage.Text))
                    {
                        txtCustomPercentage.Text = txtCustomPercentage.Text.Replace(".", ",");
                        if(double.TryParse(txtCustomPercentage.Text, out double customPercentage))
                        {
                            _bill.TipPercentage = customPercentage;
                        }
                    }
                    _bill.BillAmount = bill;
                    _bill.NumberOfPeople = numberOfPeople;
                    _bill.TipAmount = _bill.CalculateTipAmount();
                    lblTipAmount.Content = "€" + _bill.TipAmount.ToString("F2");
                    lblTotal.Content = "€" + _bill.CalculateTotalPerPerson().ToString("F2");
                }
                else
                {
                    MessageBox.Show("Fields has to be numeric. And number of people has to be non decimal.");
                }
            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            txtCustomPercentage.Visibility = Visibility.Visible;
            Custom.Visibility = Visibility.Hidden;
        }

        private void txtCustomPercentage_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUI();
        }
    }
}
