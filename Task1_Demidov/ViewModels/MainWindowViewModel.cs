using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Task1_Demidov_Core.Models;

namespace Task1_Demidov.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _real1 = "0";

        [ObservableProperty]
        private string _imaginary1 = "0";

        [ObservableProperty]
        private string _real2 = "0";

        [ObservableProperty]
        private string _imaginary2 = "0";

        [ObservableProperty]
        private string _result = "Result";

        [RelayCommand]
        private void Add() => Calculate((a, b) => a + b);

        [RelayCommand]
        private void Subtract() => Calculate((a, b) => a - b);

        [RelayCommand]
        private void Multiply() => Calculate((a, b) => a * b);

        [RelayCommand]
        private void Divide() => Calculate((a, b) => a / b);

        [RelayCommand]
        private void Compare() => Calculate((a, b) => a == b ? "Equal" : "Not equal");

        private static ComplexNumber ParseNumber(string real, string imaginary)
        {
            if (!double.TryParse(real, out double re))
                throw new ArgumentException("Invalid real part");

            if (!double.TryParse(imaginary, out double im))
                throw new ArgumentException("Invalid imaginary part");

            return new ComplexNumber(re, im);
        }

        private void Calculate(Func<ComplexNumber, ComplexNumber, object> operation)
        {
            try
            {
                var num1 = ParseNumber(Real1, Imaginary1);
                var num2 = ParseNumber(Real2, Imaginary2);
                var result = operation(num1, num2);
                Result = result.ToString() ?? "Error";
            }
            catch (Exception ex)
            {
                Result = $"Error: {ex.Message}";
            }
        }
    }
}
