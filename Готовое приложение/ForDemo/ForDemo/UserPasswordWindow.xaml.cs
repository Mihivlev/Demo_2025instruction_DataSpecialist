using ForDemo.Classes;
using System.Windows;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для UserPasswordWindow.xaml
	/// </summary>
	public partial class UserPasswordWindow : Window
	{
		public UserPasswordWindow(Accounts account, string FIO)
		{
			InitializeComponent();
			DataContext = account;
			TBFIO.Text = FIO;
		}

		private void Save(object sender, RoutedEventArgs e)
		{
			AppConnect.DataBase.SaveChanges();
			MessageBox.Show("Измение сохранено");
			this.Close();
		}

		private void Cancel(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
