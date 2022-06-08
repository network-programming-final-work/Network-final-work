using DZY_NoteSystem.LoginServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
    /// InfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        Service1Client service = new Service1Client();
        public int infoId;
        public InfoPage()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            DataTable dt = service.showInfo(0);
            gridview0.ItemsSource = dt.DefaultView;
            dt = service.showInfo(1);
            gridview1.ItemsSource = dt.DefaultView;
        }

        private void haveDone_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0]);
            Task.Run(() => { service.ChangeState(1, i); });
            MessageBox.Show("修改成功！");
            refresh();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0]);
            Task.Run(() => { service.ChangeState(2, i); });
            MessageBox.Show("取消成功！");
            refresh();
        }

        //private void NeedDo_Click(object sender, RoutedEventArgs e)
        //{
        //    int i = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0]);
        //    Task.Run(() => { service.ChangeState(0, i); });
        //    MessageBox.Show("修改成功！");
        //    refresh();
        //}

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            infoId = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[0].ToString());
            txtConten.Text = (((FrameworkElement)sender).DataContext as DataRowView)[1].ToString();
            type.SelectedIndex = Convert.ToInt32((((FrameworkElement)sender).DataContext as DataRowView)[2].ToString())-1;
            txtFinishTime.Text = (((FrameworkElement)sender).DataContext as DataRowView)[3].ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string infoContent = txtConten.Text;
            int typeid = type.SelectedIndex+1;
            DateTime finishTime = Convert.ToDateTime(txtFinishTime.Text);
            int num = DateTime.Compare(finishTime, DateTime.Now);
            if (num <= 0)
            {
                MessageBox.Show("更新的日期不可小于等于当日");
            }
            else
            {
                if (service.Update(infoId, infoContent, typeid, finishTime))
                {
                    MessageBox.Show("修改成功");
                    refresh();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }
    }
}
