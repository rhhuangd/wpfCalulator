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

namespace wpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private NumericalOperators? selectedOperation;

        public MainWindow()
        {
            InitializeComponent();

            AcButton.Click += AcButton_OnClick;
            NegativeButton.Click += NegativeButton_OnClick;
            PercentageButton.Click += PercentageButton_OnClick;
            EqualButton.Click += EqualButton_OnClick;
            //PointButton.Click += PointButton_OnClick;

            //PlusButton.Click += OperationButton_OnClick;
            //MinusButton.Click += OperationButton_OnClick;
            //MultiplicationButton.Click += OperationButton_OnClick;
            //DivisionButton.Click += OperationButton_OnClick;

            //ZeroButton.Click += NumberButton_OnClick;
            //OneButton.Click += NumberButton_OnClick;
            //TwoButton.Click += NumberButton_OnClick;
            //ThreeButton.Click += NumberButton_OnClick;
            //FourButton.Click += NumberButton_OnClick;
            //FiveButton.Click += NumberButton_OnClick;
            //SixButton.Click += NumberButton_OnClick;
            //SevenButton.Click += NumberButton_OnClick;
            //EightButton.Click += NumberButton_OnClick;
            //NineButton.Click += NumberButton_OnClick;
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
                lastNumber *= -1;

            ResultLabel.Content = lastNumber.ToString();
        }

        private void PercentageButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
                lastNumber /= 100;

            ResultLabel.Content = lastNumber.ToString();
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            string selectedValue = (sender as Button).Content.ToString();
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? selectedValue : $"{ResultLabel.Content}{selectedValue}";
        }

        private void EqualButton_OnClick(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperation)
                {
                    case NumericalOperators.Addition:
                        lastNumber = NumericalOperation.Add(lastNumber, newNumber);
                        break;
                    case NumericalOperators.Subtraction:
                        lastNumber = NumericalOperation.Subtraction(lastNumber, newNumber);
                        break;
                    case NumericalOperators.Multiplication:
                        lastNumber = NumericalOperation.Multiply(lastNumber, newNumber);;
                        break;
                    case NumericalOperators.Division:
                        lastNumber = NumericalOperation.Divide(lastNumber, newNumber);
                        break;
                }
            }

            ResultLabel.Content = lastNumber.ToString();
        }

        private void OperationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
                ResultLabel.Content = "0";

            if (sender == PlusButton)
                selectedOperation = NumericalOperators.Addition;
            if (sender == MinusButton)
                selectedOperation = NumericalOperators.Subtraction;
            if (sender == MultiplicationButton)
                selectedOperation = NumericalOperators.Multiplication;
            if (sender == DivisionButton)
                selectedOperation = NumericalOperators.Division;
        }

        private void PointButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString().Contains("."))
            {
                //Do nothing
            }
            else
            {
                ResultLabel.Content = ResultLabel.Content + ".";
            }
        }
    }

    public enum NumericalOperators
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class NumericalOperation
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }

}


