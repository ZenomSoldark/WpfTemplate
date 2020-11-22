using MahApps.Metro.Controls;
using Prism.Services.Dialogs;
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

namespace WpfTemplate.Views
{
    /// <summary>
    /// DialogBase.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogBase : MetroWindow, IDialogWindow
    {
        public DialogBase()
        {
            InitializeComponent();    
        }

        public IDialogResult Result { get; set; }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
    }
}
