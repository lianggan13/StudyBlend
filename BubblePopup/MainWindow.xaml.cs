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

namespace BubblePopup
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Parent is Grid panel)
            {
                if(panel.Children.OfType<UserControl>().Any(u=>u.GetType() == typeof(BubblePopupUC))){
                    return;
                }

                var uc = new BubblePopupUC();
                Panel.SetZIndex(uc, 0);
                panel.Children.Add(uc);

                Task.Delay(3000).ContinueWith(t =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        panel.Children.Remove(uc);
                    });

                });
            }
             
        }
    }
}
