using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sharp8Net6
{
	//1. readonly struct
	public readonly struct Rectangle
	{
		public Rectangle(double length, double height)
		{
			Length = length;
			Height = height;
		}
		public double Length { get; }
		public double Height { get; }
	}
	
	//2. default implements
	public interface IDefaultInterfaceMethod
	{
		public void DefaultMethod()
		{
			Console.WriteLine("I am a default method in the interface!");
		}
	}
	
	public class MyClass
	{
		public MyClass()
		{
			//3. Range, Index		
			var numbers = new int[] { 0, 1, 2, 3, 4, 5 };
			// Получение подпоследовательности с индекса 2 до конца массива
			var subArray = numbers[2..];
			// Получение элемента с конца массива с использованием индекса
			var lastElement = numbers[^1];
			// Получить последние три элемента
			var lastThree = numbers[^3..];
			// Получение подпоследовательности с индекса 2 до предпоследнего элемента
			var subArray2 = numbers[2..^1];
			Console.WriteLine(string.Join(", ", lastThree, lastElement, subArray, subArray2));
			
			//4. Pattern Matching (update from c# 7)
			// Сопоставление по типу с фильтром:
			var message = DateTime.Today.DayOfWeek switch
			{
				DayOfWeek.Monday => "work",
				DayOfWeek.Tuesday => "work",
				DayOfWeek.Wednesday => "work",
				DayOfWeek.Thursday => "work",
				DayOfWeek.Friday => "work",
				DayOfWeek.Saturday => "relax",
				DayOfWeek.Sunday => "relax",
				_ => throw new ArgumentOutOfRangeException()
			};
			
			Shape shape = new Circle { Radius = 7.0 };
			switch (shape)
			{
				case Circle c when c.Radius > 5:
					Console.WriteLine("Large circle");
					break;
				case Circle _:
					Console.WriteLine("Small circle");
					break;
			}

			// Сопоставление с кортежами
			var point = (3, 4);
			switch (point)
			{
				case (0, 0):
					Console.WriteLine("Origin");
					break;
				case (var x, 0):
					Console.WriteLine($"On x-axis at {x}");
					break;
				case (0, var y):
					Console.WriteLine($"On y-axis at {y}");
					break;
				default:
					Console.WriteLine("Somewhere else");
					break;
			}

			// 5. Property pattern
			var today = DateTime.Today;
			if (today is { DayOfWeek: DayOfWeek.Monday, Hour: 13 })
			{
				Console.WriteLine("Dinner time");
			}
			
			// Использование Property pattern
			var person = new Person { Name = "John", Age = 25 };

			switch (person)
			{
				case { Age: 25, Name: "John" }:
					Console.WriteLine("Person is John, 25 years old");
					break;
				case { Age: 30 }:
					Console.WriteLine("Person is 30 years old");
					break;
				default:
					Console.WriteLine("Other cases");
					break;
			}

			var myObject = new object();
			if (myObject is Rectangle rectangle)
				Console.WriteLine(rectangle.Height);

			if (myObject is List<int> singleList1 && singleList1.Count == 1)
				Console.WriteLine(singleList1.Single());
			
			if (myObject is List<int>{Count: 1} singleList)
			{
				Console.WriteLine(singleList.Single());
			}

			if (myObject is Rectangle {Length: 5, Height: 10} rectangle2)
			{
				Console.WriteLine($"Rectangle Length: {rectangle2.Length} and Height: {rectangle2.Height}");
			}

			var result = SportsLike("one", "two", "three");
			
			// 6. Static Local Functions (Local func from c# 7) && Tuple Patterns
			static string SportsLike(string sport1, string sport2, string sport3)
			{
				var result = (sport1, sport2, sport3) switch
				{
					//matches if Cricket, Football, and Swimming given as input
					("Cricket", "Football", "Swimming") => "I like Cricket, Football, and Swimming.",
					//matches if Cricket, Football, and Baseball given as input
					("Cricket", "Football", "Baseball") => "I like Cricket, Football, and Baseball.",
					//matches if Hockey, Football, and Swimming given as input
					("Hockey", "Football", "Swimming") => "I like Hockey, Football, and Swimming.",
					//matches if Table Tennis, Football, and Swimming given as input
					("Table Tennis", "Football", "Swimming") => "I like Table Tennis, Football and Swimming.",
					//Default case
					(_, _, _) => "Invalid input!"
				};
				return result;
			}
		}

		// 7. async Dispose, await foreach
		public async Task SomeMethod()
		{
			// async IAsyncDisposable
			await using var resource = new Resource(); 
			resource.DoSomethings();
			
			// async IAsyncEnumerable
			await foreach (var number in GenerateSequence())
			{
				Console.WriteLine(number);
			}
		}
		
		private async IAsyncEnumerable<int> GenerateSequence()
		{
			for (int i = 0; i < 20; i++)
			{
				await Task.Delay(100);
				yield return i;
			}
		}
	}

	#region SomeClass

	public class Shape
	{
		// ... Какие-то свойства или методы класса
	}

	public class Circle : Shape
	{
		public double Radius { get; set; }
	}
	
	public partial class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}

	public class Resource : IAsyncDisposable
	{
		public void DoSomethings()
		{
			
		}
		public ValueTask DisposeAsync()
		{
			return ValueTask.CompletedTask;
			// TODO release managed resources here
		}
	}

	#endregion
}