using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Avalonia.Interactivity;

namespace AvaloniaApplication.ViewModels;

public class IncrementDecrement : ViewModelBase, INotifyPropertyChanged 
{
    public int CurrentValue { get; set; }

    public string CurrentValueString { get; set; }

    public IncrementDecrement()
    {
        CurrentValue = 0;
        CurrentValueString = "0";
    }
    public void Increment()
    {
        if (CurrentValue + 1 < int.MaxValue)
        {
            CurrentValue++;
            CurrentValueString = $"{CurrentValue}";
            OnPropertyChanged(nameof(CurrentValueString));
        }
    }
    
    public void Decrement()
    {
        if (CurrentValue - 1 > int.MinValue)
        {
            CurrentValue--;
            CurrentValueString = $"{CurrentValue}";
            OnPropertyChanged(nameof(CurrentValueString));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}