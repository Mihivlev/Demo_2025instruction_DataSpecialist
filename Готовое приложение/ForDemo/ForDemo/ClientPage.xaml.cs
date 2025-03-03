using System.Windows;
using System.Windows.Controls;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для ClientPage.xaml
	/// </summary>
	public partial class ClientPage : Page
	{
		public ClientPage()
		{
			InitializeComponent();
		}

		private void ChangePassword(object sender, RoutedEventArgs e)
		{
			Window window = new PasswordChengerWindow();
			window.ShowDialog();
        }
    }
}
