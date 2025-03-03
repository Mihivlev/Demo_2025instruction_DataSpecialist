using ForDemo.Classes;
using System.Linq;
using System.Windows;

namespace ForDemo
{
	/// <summary>
	/// Логика взаимодействия для PasswordChengerWindow.xaml
	/// </summary>
	public partial class PasswordChengerWindow : Window
	{
		public PasswordChengerWindow()
		{
			InitializeComponent();
		}

		private void Save(object sender, RoutedEventArgs e)
		{
			// Проверка введеного пароля
			var account = AppConnect.DataBase.Accounts.FirstOrDefault(x => x.Login == Manager.Login && x.Password == IPassword.Text);
			// Введен верный пароль
			if (account != null)
			{
				// проверка нового пароля
				if ((INewPassword.Text == INewPasswordSecond.Text) && !string.IsNullOrWhiteSpace(INewPassword.Text))
				{
					// сохранение нового пароля
					account.Password = INewPassword.Text;
					AppConnect.DataBase.SaveChanges();
					MessageBox.Show("Информация сохранена");
					Manager.CountFail = 0;
					this.Close();
				}
				else MessageBox.Show("Повторите новый пароль");
			}
			// Пароль введен неверно
			else
			{
				// Сообщение и проверка количества ошибок
				MessageBox.Show("Неверный пароль");
				Manager.CountFail += 1;
				if (Manager.CountFail > 2)
				{
					// пароль был введен неправильно 3 раза \ блокировка аккаунта
					MessageBox.Show("Теперь данный аккаунт заблокирован \nДля решения этой пролбемы обратитесь к администратору");
					Bans ban = new Bans();
					ban.Login = Manager.Login;
					AppConnect.DataBase.Bans.Add(ban);
					AppConnect.DataBase.SaveChanges();
					this.Close();
					Manager.MainFrame.Navigate(new AutorizationPage());
				}
			}
		}

		private void Cancel(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
    }
}
