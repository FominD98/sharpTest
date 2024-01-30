//1 file-scoped namespace
namespace CSharp10Net7;

// 2 Инициализация полей структуры
public struct User
{
	// 2.1 конструктор без параметров, если поля инициализированы
	public User(){}
	public User(string name, int age)
	{
		Name = name;
		Age = age;
	}
	public string Name { get; set; } = string.Empty;
	public int Age { get; set; } = 18;
}

// record struct
public readonly record struct Person(string Name);