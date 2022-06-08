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
    /// CancelPage.xaml 的交互逻辑
    /// </summary>
    public partial class CancelPage : Page
    {
        Service1Client service = new Service1Client();
        public CancelPage()
        {
            InitializeComponent();
            refresh();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0].ToString());
            if (service.Delete(i))
            {
                MessageBox.Show("删除成功！");
                refresh();
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }
        public void refresh()
        {
            DataTable dt = service.showInfo(2);
            gridview0.ItemsSource = dt.DefaultView;
        }

        private void ReDone_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0].ToString());
            if (service.ChangeState(0, i))
            {
                MessageBox.Show("返回成功！");
                refresh();
            }
            else
            {
                MessageBox.Show("返回失败！");
            }
            refresh();
        }
    }
}
