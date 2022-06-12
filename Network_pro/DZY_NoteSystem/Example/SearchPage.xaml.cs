using DZY_NoteSystem.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DZY_NoteSystem.Example
{
    /// <summary>
    /// TypePage.xaml 的交互逻辑
    /// </summary>
    public partial class TypePage : Page
    {
        Service1Client service = new Service1Client();
        public TypePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = service.SearchInfo(search.Text);
            gridview0.ItemsSource = dt.DefaultView;
        }
    }
}
