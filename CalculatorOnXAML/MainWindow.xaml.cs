using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorOnXAML
{
    public partial class MainWindow : Window
    {
        private void EnableAllButtons()
        {
            Button0.IsEnabled = true;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button9.IsEnabled = true;
            ButtonAdd.IsEnabled = true;
            ButtonMinus.IsEnabled = true;
            ButtonSqrt.IsEnabled = true;
            ButtonPower.IsEnabled = true;
            ButtonPercent.IsEnabled = true;
            ButtonMult.IsEnabled = true;
            ButtonDiv.IsEnabled = true;
            ButtonEquals.IsEnabled = true;
            ButtonDot.IsEnabled = true;
        }
        private void DisableAllButtons()
        {
            Button0.IsEnabled = false;
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
            Button9.IsEnabled = false;
            ButtonAdd.IsEnabled = false;
            ButtonMinus.IsEnabled = false;
            ButtonSqrt.IsEnabled = false;
            ButtonPower.IsEnabled = false;
            ButtonPercent.IsEnabled = false;
            ButtonMult.IsEnabled = false;
            ButtonDiv.IsEnabled = false;
            ButtonEquals.IsEnabled = false;
            ButtonDot.IsEnabled = false;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private string option { get; set; }
        private double num1 { get; set; }
        private double num2 { get; set; }
        private double result { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (txtTotal.Text == "0")
            {
                txtTotal.Clear();
            }
            txtTotal.Text += button.Content.ToString();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!string.IsNullOrEmpty(txtTotal.Text))
            {
                num1 = double.Parse(txtTotal.Text);
                txtTotal.Clear();
            }
            option = button.Content.ToString();
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                txtTotal.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            num2 = double.Parse(txtTotal.Text);

            switch (option)
            {
                case "+":
                    if (double.IsNaN(num2))
                    {
                        txtTotal.Text = "Invalid Format";
                        DisableAllButtons();
                        return;
                    }
                    result = num1 + num2;
                    break;
                case "-":
                    if (double.IsNaN(num2))
                    {
                        txtTotal.Text = "Invalid Format";
                        DisableAllButtons();
                        return;
                    }
                    result = num1 - num2;
                    break;
                case "*":
                    if (double.IsNaN(num2))
                    {
                        txtTotal.Text = "Invalid Format";
                        DisableAllButtons();
                        return;
                    }
                    result = num1 * num2;
                    break;
                case "^":
                    if (double.IsNaN(num2))
                    {
                        txtTotal.Text = "Invalid Format";
                        DisableAllButtons();
                        return;
                    }
                    result = Math.Pow(num1, num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        txtTotal.Text = "Cannot Divide By 0";
                        DisableAllButtons();
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            txtTotal.Text = result.ToString();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            EnableAllButtons();
            txtTotal.Clear();
            result = 0;
            num1 = 0;
            num2 = 0;
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtTotal.Text);
            if (num1 < 0)
            {
                txtTotal.Text = "Cannot square root a negative number";
                return;
            }
            result = Math.Sqrt(num1);
            txtTotal.Text = result.ToString();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtTotal.Text);
            result = num1 / 100;
            txtTotal.Text = result.ToString();
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!txtTotal.Text.Contains("."))
            {
                txtTotal.Text += ".";
            }
        }
        private void SecCalc_Click(object sender, RoutedEventArgs e)
        {
            second_calculator_XAML secondCalculatorWindow = new second_calculator_XAML();
            secondCalculatorWindow.Show();
            this.Close();
        }


    }
}
