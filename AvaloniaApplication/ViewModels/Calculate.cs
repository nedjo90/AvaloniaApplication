using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using static System.Int32;

namespace AvaloniaApplication.ViewModels;

public class Calculate : ViewModelBase, INotifyPropertyChanged
{
    public string ResultString { get; set; }
    public int RandomFirstNumber { get; set; }
    
    public int RandomSecondNumber { get; set; }

    public string? First
    {
        get
        {
            return $"{RandomFirstNumber}";
        }
        set
        {
            RandomFirstNumber = Convert.ToInt32(value);
            OnPropertyChanged();
        }
    }

    public string? Second
    {
        get
        {
            return $"{RandomSecondNumber}";
        }
        set
        {
            RandomSecondNumber = Convert.ToInt32(value);
            OnPropertyChanged();
        }
    }

    long _min;
    long _max;

    public long Min
    {
        get => (int)_min;
        set
        {
            if (value < int.MinValue)
                value = MinValue;
            _min = (int)value;
            OnPropertyChanged();
        }
    }

    public long Max
    {
        get => (int)_max;
        set
        {
            if (value > int.MaxValue)
                value = MaxValue;
            _max = (int)value;
            OnPropertyChanged();
        }
    }
    

    public event PropertyChangedEventHandler? PropertyChanged;

    public Calculate()
    {
        NewRandom();
        _min = int.MinValue;
        _max = int.MaxValue;
        ResultString = "0";
    }

    private int RandomNumber()
    {
        return new Random().Next((int)_min, (int)_max);
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void NewRandom()
    {
        First = $"{RandomNumber()}";
        Second = $"{RandomNumber()}";
        OnPropertyChanged(nameof(First));
        OnPropertyChanged(nameof(Second));
    }

    public void OnMultiply()
    {
        BigInteger res = (BigInteger)RandomFirstNumber * (BigInteger)RandomSecondNumber;
        ResultString = $"{res:n0}";
        OnPropertyChanged(nameof(ResultString));
    }

    public void OnDivide()
    {
        if (RandomSecondNumber != 0)
        {
            BigInteger res = (BigInteger)RandomFirstNumber / (BigInteger)RandomSecondNumber;
            ResultString = $"{res:n0}";
        }
        else
        {
            ResultString = $"Impossible to divide by 0";
        }
        OnPropertyChanged(nameof(ResultString));
    }

    public void OnSum()
    {
        BigInteger res = (BigInteger)RandomFirstNumber + (BigInteger)RandomSecondNumber;
        ResultString = $"{res:n0}";
        OnPropertyChanged(nameof(ResultString));
    }

    public void OnDifference()
    {
        BigInteger res = (BigInteger)RandomFirstNumber - (BigInteger)RandomSecondNumber;
        ResultString = $"{res:n0}";
        OnPropertyChanged(nameof(ResultString));
    }
}