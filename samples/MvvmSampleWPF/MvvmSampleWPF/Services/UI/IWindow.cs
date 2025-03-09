using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmSampleWPF.Services.UI
{
    public interface IWindow
    {
        event RoutedEventHandler Loaded;
        void Show();
    }
}
