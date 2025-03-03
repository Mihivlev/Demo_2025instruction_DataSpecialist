using ForDemo.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для EmoployeePage.xaml
	/// </summary>
	public partial class EmoployeePage : Page
	{
		public EmoployeePage()
		{
			InitializeComponent();
			LoadAccounts();
		}
		private void LoadAccounts()
		{
			DGUsers.Items.Clear();
			var accounts = AppConnect.DataBase.Accounts.ToList();
			foreach (Accounts account in accounts)
			{
				if (account.Login == Manager.Login)
				{
					continue;
				}
				AccountVH item = new AccountVH();
				item.Login = account.Login;

				var BanStatus = AppConnect.DataBase.Bans.FirstOrDefault(x => x.Login == account.Login);
				if (BanStatus != null)
				{
					item.BanStatus = "Разблокировать";
				}
				else
				{
					item.BanStatus = "Заблокировать";
				}

				var user = AppConnect.DataBase.Users.FirstOrDefault(x => x.ID == account.UserID);
				if (user != null)
				{
					item.FIO = user.FIO;
				}
				DGUsers.Items.Add(item);

			}
		}
		private void ChangePassword(object sender, RoutedEventArgs e)
		{
			Window window = new PasswordChengerWindow();
			window.ShowDialog();
		}
		private void ChangeBanStatus(object sender, RoutedEventArgs e)
		{
			AccountVH view = (sender as Button).DataContext as AccountVH;
			var ban = AppConnect.DataBase.Bans.FirstOrDefault(x => x.Login == view.Login);
			if (ban != null)
			{
				AppConnect.DataBase.Bans.Remove(ban);
			}
			else
			{
				Bans NewBan = new Bans();
				NewBan.Login = view.Login;
				AppConnect.DataBase.Bans.Add(NewBan);
			}
			AppConnect.DataBase.SaveChanges();
			LoadAccounts();
		}
		private void EditPassword(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			AccountVH accountVH = button.DataContext as AccountVH;
			Accounts account = AppConnect.DataBase.Accounts.FirstOrDefault(x => x.Login == accountVH.Login);
			Window window = new UserPasswordWindow(account, accountVH.FIO);
			window.ShowDialog();
		}
		private void Delete(object sender, RoutedEventArgs e)
		{
			MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить этот аккаунт", "Удаление аккаунта",
				MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				Button button = (Button)sender;
				AccountVH accountVH = button.DataContext as AccountVH;
				Accounts accounts = AppConnect.DataBase.Accounts.FirstOrDefault(x => x.Login == accountVH.Login);
				AppConnect.DataBase.Accounts.Remove(accounts);
				AppConnect.DataBase.SaveChanges();
				LoadAccounts();

			}
		}

		private void CreateUser(object sender, RoutedEventArgs e)
		{
			Manager.MainFrame.Navigate(new NewUserPage());
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
			{
				AppConnect.DataBase.ChangeTracker.Entries().ToList().ForEach(entry => { entry.Reload(); });
			}
			LoadAccounts();
		}
	}
}
