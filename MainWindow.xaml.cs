using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        private string input = "";
        private double num1 = 0;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            if (double.TryParse(content, out _))
            {
                if (content == "0" && input == "0")
                    return;

                if (input == "0")
                    input = content;
                else
                    input += content;

                txtDisplay.Text = input;
            }
            else if (content == "C")
            {
                input = "";
                num1 = 0;
                operation = "";
                txtDisplay.Text = "";
            }
            else if (content == "=")
            {
                if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(operation))
                {
                    double num2 = double.Parse(input);
                    double result = 0;

                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "x":
                            result = num1 * num2;
                            break;
                        case "/":
                            if (num2 != 0)
                                result = num1 / num2;
                            else
                            {
                                MessageBox.Show("На ноль делить нельзя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            break;
                    }

                    txtDisplay.Text = result.ToString();
                    input = "";
                    operation = "";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(input))
                {
                    num1 = double.Parse(input);
                    operation = content;
                    input = "";
                }
            }
        }
    }
}
