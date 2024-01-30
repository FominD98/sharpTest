using CSharp9Net6;
using FluentAssertions;
using Shouldly;

namespace СSharp8Tests;

[TestFixture]
public class Tests
{
	[Test]
	public void PersonRecordTest()
	{
		// Act
		var person = new Person("ivan", "ivanov");
		var another = new Person("ivan", "ivanov");
		var equals = person == another;
		
		// Assert
		equals.ShouldBeTrue();
		Assert.AreEqual(another, person);
		another.Should().Be(person);
		another.ShouldBe(person);
	}
	
	[Test]
	public void PersonClassTest()
	{
		// Act
		var person = new PersonClass{FirstName = "ivan", LastName = "ivanov"};
		var another = new PersonClass{FirstName = "ivan", LastName = "ivanov"};
		var equals = person == another;

		// Assert
		equals.ShouldBeTrue();
		Assert.AreEqual(another, person);
		another.Should().Be(person);
		another.ShouldBe(person);
	}
}