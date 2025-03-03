using System.Windows;

namespace mod4
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GetData(object sender, RoutedEventArgs e)
		{
			// загрузка данных в приложение
			Functions.LoadData();

			TBData.Text = Storage.user;
		}

		private void GetResult(object sender, RoutedEventArgs e)
		{
			// проверка наличия данных

			// данных не загружены
			if (string.IsNullOrWhiteSpace(TBData.Text))
			{
				TBResult.Text = "Данные не получены";
			}
			// данные загружены
			else
			{
				// массив с запрещенными символами
				string[] sym = {"@","/","#","=","%","|","(", ")","&",";",":","!","?","*","^","+","-"};

				string FIO = TBData.Text;
				bool IsClear = true;

				// провека наличия запрещенных символов
				for (int i = 0; i < sym.Length; i++)
				{
					if (FIO.Contains(sym[i]))
					{
						// ФИО содержит запрещенные символы.
						// Дальнейший перебор бессмысленен, поэтому записываем false в IsClrear и завершаем цикл for
						IsClear = false;
						break;
					}
				}

				if (IsClear)
					TBResult.Text = "ФИО не содержит запрещенные символы";
				else
					TBResult.Text = "ФИО содержит запрещенные символы";
			}
		}
	}
}
