using ForDemo.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для AutorizationPage.xaml
	/// </summary>
	public partial class AutorizationPage : Page
	{
		public AutorizationPage()
		{
			InitializeComponent();
		}
		private void Enter(object sender, RoutedEventArgs e)
		{
			// Поиск аккаунта
			var account =  AppConnect.DataBase.Accounts.FirstOrDefault(x => x.Login == ILogin.Text && x.Password == IPassword.Text);
			// Аккаунт найден
			if (account != null)
			{
				// Проверка блокировки аккаунта
				var ban = AppConnect.DataBase.Bans.FirstOrDefault(x => x.Login == account.Login);
				// Аккаунт не заблокирован
				if (ban == null)
				{
					Manager.Login = account.Login;
					// Проверка принадлежности аккаунта
					var user = AppConnect.DataBase.Users.FirstOrDefault(x => x.ID == account.UserID);
					// аккаунт клиента
					if (user.RoleID == 4)
					{
						Manager.MainFrame.Navigate(new ClientPage());
					}
					// аккаунт сотрудника
					else
					{
						Manager.MainFrame.Navigate(new EmoployeePage());
					}
				}
				// Аккаунт заблокирован
				else MessageBox.Show("Данный аккаунт заблокирован \nДля решения этой пролбемы обратитесь к администратору");
			}
			// Аккаунт не найден
			else MessageBox.Show("Неправильно введен логин или пароль");
		}
	}
}
