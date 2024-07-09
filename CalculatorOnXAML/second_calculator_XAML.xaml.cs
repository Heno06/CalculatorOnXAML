using System;
using System.Windows;
using System.Windows.Controls;

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

        private bool equalsClicked = false;

        private bool isNewNumber = true;
        public second_calculator_XAML()
        {
            InitializeComponent();
        }

        private void Second_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (equalsClicked == true)
            {
                txtTotal1.Text = second_result.ToString(); // Use the previous result as the first number
                equalsClicked = false;
            }
            if (button.Content.ToString() == "+" || button.Content.ToString() == "-" || button.Content.ToString() == "*" || button.Content.ToString() == "/" || button.Content.ToString() == "^" || button.Content.ToString() == "%")
            {
                if (txtTotal1.Text.Contains("+") || txtTotal1.Text.Contains("-") || txtTotal1.Text.Contains("*") || txtTotal1.Text.Contains("/") || txtTotal1.Text.Contains("^") || txtTotal1.Text.Contains("%"))
                {
                    // Do nothing
                }
                else
                {
                    txtTotal1.Text += button.Content.ToString();
                    second_expression += button.Content.ToString();
                }
            }
            else
            {
                if (txtTotal1.Text == "0")
                {
                    txtTotal1.Text = button.Content.ToString();
                }
                else
                {
                    txtTotal1.Text += button.Content.ToString();
                }
                second_expression += button.Content.ToString();
            }
        }

        private void Second_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (equalsClicked)
            {
                txtTotal1.Text = second_result.ToString();
                second_expression = second_result.ToString();
                equalsClicked = false;
            }
            if (!string.IsNullOrEmpty(txtTotal1.Text) && !txtTotal1.Text.Contains("+") && !txtTotal1.Text.Contains("-") && !txtTotal1.Text.Contains("*") && !txtTotal1.Text.Contains("/") && !txtTotal1.Text.Contains("^") && !txtTotal1.Text.Contains("%"))
            {
                second_num1 = double.Parse(txtTotal1.Text);
                second_expression = txtTotal1.Text;
            }
            second_option = button.Content.ToString();
            if (txtTotal1.Text.Contains("+") || txtTotal1.Text.Contains("-") || txtTotal1.Text.Contains("*") || txtTotal1.Text.Contains("/") || txtTotal1.Text.Contains("^") || txtTotal1.Text.Contains("%"))
            {
                string oldSymbol = "";
                if (txtTotal1.Text.Contains("+"))
                {
                    oldSymbol = "+";
                }
                else if (txtTotal1.Text.Contains("-"))
                {
                    oldSymbol = "-";
                }
                else if (txtTotal1.Text.Contains("*"))
                {
                    oldSymbol = "*";
                }
                else if (txtTotal1.Text.Contains("/"))
                {
                    oldSymbol = "/";
                }
                else if (txtTotal1.Text.Contains("^"))
                {
                    oldSymbol = "^";
                }
                else if (txtTotal1.Text.Contains("%"))
                {
                    oldSymbol = "%";
                }

                // Check if the textbox contains 'E' for scientific notation
                if (txtTotal1.Text.Contains("E"))
                {
                    txtTotal1.Text += " " + second_option + " ";
                    second_expression += " " + second_option + " ";
                }
                else
                {
                    txtTotal1.Text = txtTotal1.Text.Replace(oldSymbol, second_option);
                }
            }
            else
            {
                txtTotal1.Text += " " + second_option + " ";
                second_expression += " " + second_option + " ";
            }

        }

        private void Second_ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal1.Text) || second_expression == "")
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            if (!txtTotal1.Text.Contains("+") && !txtTotal1.Text.Contains("-") && !txtTotal1.Text.Contains("*") && !txtTotal1.Text.Contains("/") && !txtTotal1.Text.Contains("^") && !txtTotal1.Text.Contains("%"))
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            if (txtTotal1.Text.EndsWith("+") || txtTotal1.Text.EndsWith("-") || txtTotal1.Text.EndsWith("*") || txtTotal1.Text.EndsWith("/") || txtTotal1.Text.EndsWith("^") || txtTotal1.Text.EndsWith("%"))
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            string[] parts = txtTotal1.Text.Split(new char[] { '+', '-', '*', '/', '^', '%' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[1], out double num2))
            {
                txtTotal1.Text = "Invalid Format";
                DisableAllButtons();
                return;
            }

            switch (second_option)
            {
                case "+":
                    second_result = num1 + num2;
                    break;
                case "-":
                    second_result = num1 - num2;
                    break;
                case "*":
                    second_result = num1 * num2;
                    break;
                case "^":
                    second_result = Math.Pow(num1, num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        txtTotal1.Text = "Cannot Divide By 0";
                        DisableAllButtons();
                        return;
                    }
                    second_result = num1 / num2;
                    break;
                case "%":
                    if (num2 == 0)
                    {
                        txtTotal1.Text = "Cannot Modulo By 0";
                        DisableAllButtons();
                        return;
                    }
                    second_result = num1 % num2;
                    break;
                default:
                    txtTotal1.Text = "Invalid Operation";
                    DisableAllButtons();
                    return;
            }

            txtTotal1.Text = second_result.ToString();
            second_expression += " = " + second_result.ToString();
            equalsClicked = true;
            isNewNumber = true;
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
            if (string.IsNullOrEmpty(txtTotal1.Text) || !double.TryParse(txtTotal1.Text, out _))
            {
                txtTotal1.Text = "Invalid format";
                DisableAllButtons();
                return;
            }
            EnableAllButtons();
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
            if (string.IsNullOrEmpty(txtTotal1.Text) || !double.TryParse(txtTotal1.Text, out _))
            {
                txtTotal1.Text = "Invalid format";
                DisableAllButtons();
                return;
            }
            EnableAllButtons();
            second_num1 = double.Parse(txtTotal1.Text);
            second_result = second_num1 / 100;
            txtTotal1.Text = second_result.ToString();
            second_expression = $"{second_num1} % = {second_result}";
        }

        private void Second_ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotal1.Text) && !txtTotal1.Text.EndsWith("."))
            {
                if (!txtTotal1.Text.Contains("."))
                {
                    txtTotal1.Text += ".";
                    second_expression += ".";
                }
                else
                {
                    char[] operators = { '+', '-', '*', '/' };
                    foreach (char op in operators)
                    {
                        int opIndex = txtTotal1.Text.LastIndexOf(op);
                        if (opIndex != -1 && !txtTotal1.Text.Substring(opIndex + 1).Contains("."))
                        {
                            txtTotal1.Text += ".";
                            second_expression += ".";
                            break;
                        }
                    }
                }
            }
        }

        private void FirstCalc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow secondCalculatorWindow = new MainWindow();
            secondCalculatorWindow.Show();
            this.Close();

        }

    }
}
