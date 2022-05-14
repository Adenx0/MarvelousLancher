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
using Panuon.UI.Silver;
using KMCCC.Launcher;

namespace MarvelousLancher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public static LauncherCore Core = LauncherCore.Create();
        public MainWindow()
        {
            InitializeComponent();
            var versions = Core.GetVersions().ToArray();
            versionCombo.ItemsSource = versions;//绑定数据源
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            var ver = (KMCCC.Launcher.Version)versionCombo.SelectedItem;
            var result = InvalidProgramException.Core.Lancher(new LamcherOptions
            {
            Version = ver,//Ver为Versions里你要的版本名字
            MaxMemory = 1024,//最大内存,int类型
            Authenticator = new OfflineAuthenticator("Dev"),//离线启动,Dev是测试游戏名
            //Authenticator = new YggdrasilLogin("邮箱","密码",true),//正版启动,最后一个为是否twitch登录
            Mode = LancherMode.MCLancher,//启动模式
            //Server = new ServerInfo { Address = "服务器IP地址",Port="服务器端口"},//设置进入游戏后自动加入所选IP的服务器
            //Size = new WindowSize { Height = 768,Width = 1280}//设置窗口大小(有没有都可以)
            });
.        }
    }
}
