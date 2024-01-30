//4. Глобальное использование using
global using CSharp10Net7;

var ivan = new User { Name = "ivan", Age = 30 };
// 3. with для структур
var oleg = ivan with { Name = "oleg", Age = 25 };
var petr = ivan with { Name = "petr", Age = 45 };

// 4.  DateOnly \ TimeOnly
var birthday = new DateOnly(1990, 1, 1);
var alarm = new TimeOnly(8, 30, 0);

// 5. PriorityQueque
var priorityQueque = new PriorityQueue<User, int>();
priorityQueque.Enqueue(ivan, 1);
priorityQueque.Enqueue(oleg, 4);
priorityQueque.Enqueue(petr, 0);
//petr, ivan, oleg

// 6. MaxBy/MinBy, D
var list = new List<User>
{
	ivan, oleg, petr
};
var younger = list.MinBy(x => x.Age);
var older = list.MaxBy(x => x.Age);
var distinct = list.DistinctBy(x => x.Age);

// 7. Chunk
foreach (var batch in list.Batch(30))
{
	Console.WriteLine(batch);
}

foreach (var chunk in list.Chunk(30))
{
	Console.WriteLine(chunk);
}

Console.WriteLine(ivan);
Console.WriteLine(oleg);

// 9. Constant interpolated string
const string before = "before";
const string beforeString = $"was: {before}"; // const string
Console.WriteLine(beforeString);

