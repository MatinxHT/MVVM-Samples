using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Abstractions;

namespace MvvmSampleWPF.Services.UI
{
    public class DependencyInjectionNavigationViewPageProvider(IServiceProvider serviceProvider)
    : INavigationViewPageProvider
    {
        public object? GetPage(Type pageType)
        {
            return serviceProvider.GetService(pageType);
        }
    }
}
