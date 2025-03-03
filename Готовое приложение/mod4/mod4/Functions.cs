using Newtonsoft.Json;
using System.Net.Http;

namespace mod4
{
	// Функции для получения данных через api и их сохранения
	internal class Functions
	{
		// Функция получения данных
		public static string GetUser()
		{
			using (HttpClient client = new HttpClient())
			{
				// отправление GET запроса на хост и загрузка с него ответа
				var response = client.GetAsync("http://localhost:4444/TransferSimulator/fullName").Result;

				// если ответ был успешно загружен
				if (response.IsSuccessStatusCode == true)
				{
					// ковертирование ответа из json текста в переменную с типом string
					return JsonConvert.ToString(response.Content.ReadAsStringAsync().Result);
				}
				// если ответ не был успешно загружен
				else return null;
			}
		}
		// Функция сохранения данных
		public static void LoadData()
		{
			// загрузка данных в переменную
			string user = GetUser();

			// переменная user вместе с небходимыми нам ФИО содержит лишние данные которые остались от json
			// поэтому мы обрежим переменную на 20 символов впереди и на 6 сзади
			user = user.Remove(0,20);
			int ind = user.Length - 6;
			user = user.Remove(ind);

			// записываем данные в переменную с глобальным контекстом
			Storage.user = user;
		}
	}
	// Класс для хранения данных
	public static class Storage
	{
		public static string user { get; set; }
	}
}
