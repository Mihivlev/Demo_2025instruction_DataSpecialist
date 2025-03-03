using ForDemo.Classes;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для NewUserPage.xaml
	/// </summary>
	public partial class NewUserPage : Page
	{
		Accounts account = new Accounts();
		bool UserChoiced = false;

		public NewUserPage()
		{
			InitializeComponent();
			DataContext = account;

            foreach (var item in AppConnect.DataBase.Users)
            {
                if (item.RoleID == 4)
					DGNewAccount.Items.Add(item);
            }
        }

		private void Save(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (String.IsNullOrEmpty(ILogin.Text))
				errors.AppendLine("Введите логин");
			if (String.IsNullOrEmpty(ILogin.Text))
				errors.AppendLine("Введите пароль");
			if (UserChoiced == false)
				errors.AppendLine("Выберите владельца аккаунта");

			if (errors.Length > 0)
			{
				MessageBox.Show(errors.ToString());
			}
			else
			{
				AppConnect.DataBase.Accounts.Add(account);
				AppConnect.DataBase.SaveChanges();
				MessageBox.Show("Информация сохранена");
				Manager.MainFrame.GoBack();
			}
		}
		private void Cancel(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.GoBack();
		}

		private void Choice(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			Users user = button.DataContext as Users;
			account.UserID = user.ID;
			UserChoiced = true;
		}
	}
}
