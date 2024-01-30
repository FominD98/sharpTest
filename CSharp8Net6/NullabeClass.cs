using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
#nullable enable

namespace Sharp8Net6
{
	// 8 Nullable Reference Types 
	public class NullableClass
	{
		public NullableClass(string firstName, string secondName)
		{
			// явные проверки в if
			if (firstName is null)
			{
				throw new ArgumentNullException(nameof(firstName));
			}
			
			ArgumentNullException.ThrowIfNull(secondName);
		}
		
		//JetBrains.Annotations	
		string Foo() {
			return null; // Warning: Possible 'null' assignment
		}
		
		string? Foo2() {
			return null; // Warning: Possible 'null' assignment
		}
		
		public void ProcessCollection([ItemNotNull] List<string> nonNullableCollection, [CanBeNull] List<string> nullableCollection)
		{
			// Обработка коллекции
			foreach (var item in nonNullableCollection)
				Console.WriteLine($"Non-nullable item: {item}");

			foreach (var item in nullableCollection)
			{
				Console.WriteLine($"Nullable item: {item}");
			}
		}
		
		public NullableClass(string input)
		{
			// Пример JSON-строки
			string jsonString = @"{
            'name': 'John Doe',
            'age': 30,
            'city': 'New York',
            'isStudent': false,
            'grades': [95, 87, 91]
        }";

			// Преобразование строки в объект JObject
			var jsonObject = JObject.Parse(jsonString);

			// Получение значений из JObject
			var name = (string)jsonObject["name"];
			var age = (int)jsonObject["age"];
			var city = (string)jsonObject["city"];
			var isStudent = (bool)jsonObject["isStudent"];

			Console.WriteLine($"Name: {name}");
			Console.WriteLine($"Age: {age}");
			Console.WriteLine($"City: {city}");
			Console.WriteLine($"Is Student: {isStudent}");

			// Обработка массива
			var gradesArray = (JArray)jsonObject["grades"];
			Console.Write("Grades: ");
			foreach (int grade in gradesArray)
			{
				Console.Write($"{grade} ");
			}

			// Преобразование строки в объект JsonDocument
			using (var document = JsonDocument.Parse(jsonString))
			{
				// Получение корневого элемента
				var root = document.RootElement;

				// Получение значений из JsonElement
				var name2 = root.GetProperty("name").GetString();
				var age2 = root.GetProperty("age").GetInt32();
				var city2 = root.GetProperty("city").GetString();
				var isStudent2 = root.GetProperty("isStudent").GetBoolean();

				Console.WriteLine($"Name: {name2}");
				Console.WriteLine($"Age: {age2}");
				Console.WriteLine($"City: {city2}");
				Console.WriteLine($"Is Student: {isStudent2}");

				// Обработка массива
				var gradesArray2 = root.GetProperty("grades").EnumerateArray();
				Console.Write("Grades: ");
				foreach (var grade in gradesArray2)
				{
					Console.Write($"{grade.GetInt32()} ");
				}
			}

			// Установка ConfigureAwait(false) для всего приложения
			SynchronizationContext.SetSynchronizationContext(null);

			Console.ReadLine();
		}
		
		async Task DoSomethingAsync()
		{
			await Task.Delay(1000).ConfigureAwait(false);

			Console.WriteLine("DoSomethingAsync method continues without restoring the original synchronization context.");
		}
	}
}