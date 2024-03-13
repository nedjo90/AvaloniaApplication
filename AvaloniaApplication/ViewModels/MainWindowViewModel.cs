using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Calculate MyCalc { get; set; }
    public IncrementDecrement MyIncDec { get; set; }

    public MainWindowViewModel()
    {
        MyCalc = new Calculate();
        MyIncDec = new IncrementDecrement();
    }
}