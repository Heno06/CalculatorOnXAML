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
using System.Windows.Shapes;

namespace CalculatorOnXAML
{
    /// <summary>
    /// Interaction logic for second_calculator_XAML.xaml
    /// </summary>
    public partial class second_calculator_XAML : Window
    {
        private void EnableAllButtons()
        {
            button0.IsEnabled = true;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            buttonAdd.IsEnabled = true;
            buttonMinus.IsEnabled = true;
            buttonSqrt.IsEnabled = true;
            buttonPower.IsEnabled = true;
            buttonPercent.IsEnabled = true;
            buttonMult.IsEnabled = true;
            buttonDiv.IsEnabled = true;
            buttonEquals.IsEnabled = true;
            buttonDot.IsEnabled = true;
        }
        private void DisableAllButtons()
        {
            button0.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
            buttonAdd.IsEnabled = false;
            buttonMinus.IsEnabled = false;
            buttonSqrt.IsEnabled = false;
            buttonPower.IsEnabled = false;
            buttonPercent.IsEnabled = false;
            buttonMult.IsEnabled = false;
            buttonDiv.IsEnabled = false;
            buttonEquals.IsEnabled = false;
            buttonDot.IsEnabled = false;
        }
        private string second_option { get; set; }
        private string second_expression { get; set; } 
        private double second_num1 { get; set; }
        private double second_num2 { get; set; }
        private double second_result { get; set; }

        public second_calculator_XAML()
        {
            InitializeComponent();
        }

        private void Second_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            second_expression += button.Content.ToString(); 
            txtTotal1.Text += button.Content.ToString();
        }

        private void Second_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!string.IsNullOrEmpty(txtTotal1.Text))
            {
                second_num1 = double.Parse(txtTotal1.Text);
                second_expression += txtTotal1.Text; 
                txtTotal1.Clear();
            }
            second_option = button.Content.ToString();
            second_expression += second_option; 
            txtTotal1.Text += second_option;
        }

        private void Second_ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal1.Text))
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            second_num2 = double.Parse(txtTotal1.Text);
            second_expression += txtTotal1.Text;

            switch (second_option)
            {
                case "+":
                    second_result = second_num1 + second_num2;
                    break;
                case "-":
                    second_result = second_num1 - second_num2;
                    break;
                case "*":
                    second_result = second_num1 * second_num2;
                    break;
                case "^":
                    second_result = Math.Pow(second_num1, second_num2);
                    break;
                case "/":
                    if (second_num2 == 0)
                    {
                        txtTotal1.Text = "Cannot Divide By 0";
                        DisableAllButtons();
                        return;
                    }
                    second_result = second_num1 / second_num2;
                    break;
                case "%":
                    second_result = second_num1 % second_num2;
                    break;
                default:
                    txtTotal1.Text = "Invalid Operation";
                    DisableAllButtons();
                    return;
            }

            txtTotal1.Text = second_result.ToString();
            second_expression += " = " + second_result.ToString(); 
        }

        private void Second_ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            EnableAllButtons();
            txtTotal1.Clear();
            second_expression = ""; 
            second_result = 0;
            second_num1 = 0;
            second_num2 = 0;
        }

        private void Second_ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            second_num1 = double.Parse(txtTotal1.Text);
            if (second_num1 < 0)
            {
                txtTotal1.Text = "Cannot square root a negative number";
                return;
            }
            second_result = Math.Sqrt(second_num1);
            txtTotal1.Text = second_result.ToString();
            second_expression = $"sqrt({second_num1}) = {second_result}"; 
        }

        private void Second_ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            second_num1 = double.Parse(txtTotal1.Text);
            second_result = second_num1 / 100;
            txtTotal1.Text = second_result.ToString();
            second_expression = $"{second_num1} % = {second_result}"; 
        }

        private void Second_ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!txtTotal1.Text.Contains("."))
            {
                txtTotal1.Text += ".";
                second_expression += ".";
            }
        }

        private void FirstCalc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
