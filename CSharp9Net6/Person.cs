namespace CSharp9Net6
{
	// 2 record
	public record Person(string FirstName, string LastName);

	// 3 init only
	public record PersonClass
	{
		public string FirstName { get; init; } = null!;
		public string LastName { get; init; } = null!;
	}
}