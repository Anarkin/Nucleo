using System.Diagnostics;
using System.Linq.Expressions;
using Nucleo.Generators.Abstractions;
using Xunit;

namespace Nucleo.Generators.Tests;

//class ConsoleGyurma : IConsole
//{
//	private readonly IDictionary<string, Expression> lookup = new Dictionary<string, Expression>();

//	public ConsoleGyurma(Expression<Func<ConsoleGyurma, bool>> x)
//	{
//		#region fill collection
//		var collection = new List<BinaryExpression>();

//		var q = new Queue<BinaryExpression>();
//		q.Enqueue((BinaryExpression)x.Body);
//		static bool IsFinalBinary(Expression e) => e is BinaryExpression be && be.Left is not BinaryExpression && be.Right is not BinaryExpression;
//		BinaryExpression current = default!;
//		while (q.Any())
//		{
//			current = q.Dequeue();

//			if (IsFinalBinary(current))
//			{
//				collection.Add(current);
//				break;
//			}

//			if (current.Left is BinaryExpression binaryLeft)
//			{
//				if (IsFinalBinary(binaryLeft))
//				{
//					collection.Add(binaryLeft);
//				}
//				else
//				{
//					q.Enqueue(binaryLeft);
//				}
//			}

//			if (current.Right is BinaryExpression binaryRight)
//			{
//				if (IsFinalBinary(binaryRight))
//				{
//					collection.Add(binaryRight);
//				}
//				else
//				{
//					q.Enqueue(binaryRight);
//				}
//			}
//		}
//		#endregion

//		#region fill lookup

//		foreach (var item in collection)
//		{
//			if (item.Left is MethodCallExpression mce)
//			{
//				var name = mce.Method.Name;
//				//var value = Expression.Lambda(item.Right).Compile().DynamicInvoke();
//				if (!lookup.ContainsKey(name))
//				{
//					lookup.Add(name, item.Right);
//				}
//			}
//			else if (item.Left is UnaryExpression ue)
//			{
//				var name = ((MethodCallExpression)ue.Operand).Method.Name;
//				//var value = Expression.Lambda(item.Right).Compile().DynamicInvoke();
//				if (!lookup.ContainsKey(name))
//				{
//					lookup.Add(name, item.Right);
//				}
//			}
//			else if (item.Left is MemberExpression me)
//			{
//				var name = me.Member.Name;
//				//var value = Expression.Lambda(item.Right).Compile().DynamicInvoke(); 
//				if (!lookup.ContainsKey(name))
//				{
//					lookup.Add(name, item.Right);
//				}
//			}
//		}

//		#endregion
//	}

//	public int Width => (int)Expression.Lambda(lookup[nameof(Width)]).Compile().DynamicInvoke()!;

//	public char Read()
//	{
//		var expression = lookup[nameof(Read)];
//		var convertedExpression = Expression.Convert(expression, typeof(char));
//		var result = Expression.Lambda(convertedExpression).Compile().DynamicInvoke();
//		return (char)result;
//	}

//	public string ReadLine()
//	{
//		var x = lookup[nameof(ReadLine)];
//		var y =
//			Expression.Convert(
//				x,
//				typeof(string)
//			);

//		var r = Expression.Lambda(y).Compile().DynamicInvoke();

//		return (string)r;
//	}

//	public void Write(string s)
//	{
//	}
//}

interface IConsole
{
	void Write(string s);

	char Read();

	string ReadLine();

	int Width { get; }
}

interface IScreen
{
	int WWWWWw { get; }
	int HHHHHH { get; }
}

class ConsoletHasználóOsztály
{
	public ConsoletHasználóOsztály(IConsole console)
	{
		Console = console;
	}

	public IConsole Console { get; }

	public int SzámotDuplázó()
	{
		return Console.Width * 2;
	}
}

[Gyurma(
	typeof(IConsole),
	typeof(IScreen)
)]
public class TestClass1
{
	[Fact]
	public void TestMethod1()
	{
		//// arrange
		//var x = 123123123;

		//var console = new ConsoleGyurma(c =>
		//	c.Read() == 'a' &&
		//	c.ReadLine() == "helloka" &&
		//	c.Width == x
		//);
		//var consoletHasználóOsztály = new ConsoletHasználóOsztály(console);

		//// act
		//var actual = consoletHasználóOsztály.SzámotDuplázó();

		////Assert.Equal('a', console.Read());
		////Assert.Equal("helloka", console.ReadLine());
		////Assert.Equal(x, console.Width);

		//// assert
		//Assert.Equal(expected: 123123123 * 2, actual);
	}
}
