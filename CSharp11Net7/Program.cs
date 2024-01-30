var person = new Person
{
	FirstName = "ivan",
	LastName = "ivanov"
};

// 2. ListPatterns
var seq1 = new[] { 1, 2, 3 };
if (seq1 is [1, 2, 3])
{
	Console.WriteLine("seq1 is [1, 2, 3]");
}

var list = new List<string>() { "a", "b", "c" };
if (list is [var first, "b", var last])
{
	Console.WriteLine($"First: {first}, Last: {last}");
}

// 3.Многострочные строки
var text = """
			<element attr="content">
			  <body>
			  </body>
			</element>
			""";
Console.WriteLine(text);

Console.WriteLine(person);

//0 модификатор file
file record Person
{
	// 1. Модификатор required
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
}
