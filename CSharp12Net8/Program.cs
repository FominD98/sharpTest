using Sharp12Net8;
using People = System.Collections.Generic.List<Sharp12Net8.Person>;

//2 Псевдонимы типов
var person = new People { new Person("ivan", "ivanov") };
Console.WriteLine(person);

//3 Входные параметры лямбда-выражения
Action<string> line = (string message = "дефолтное сообщение") => Console.WriteLine(message);

var IncrementBy = (int source, int increment = 1) => source + increment;

Console.WriteLine(IncrementBy(5)); // 6
Console.WriteLine(IncrementBy(5, 2)); // 7