using DZY_NoteSystem.LoginServiceReference;
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

namespace DZY_NoteSystem.Example
{
    /// <summary>
    /// AddInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class AddInfoPage : Page
    {
        Service1Client service = new Service1Client();
        public AddInfoPage()
        {
            InitializeComponent();
        }

        private void SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            string Info = infoContent.Text.ToString();
            int InfoType = type.SelectedIndex+1;
            string StrInfoType = type.SelectedItem.ToString();
            DateTime Date = Convert.ToDateTime(finishTime.ToString());
            int InfoState = state.SelectedIndex;
            if(service.Add(Info, InfoType, Date, InfoState))
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }
    }
}
