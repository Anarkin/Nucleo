using System.Linq.Expressions;

namespace Nucleo.Generators.Abstractions;

public abstract class GyurmaBase
{
	private readonly IDictionary<string, Expression> lookup = new Dictionary<string, Expression>();

	public GyurmaBase(Expression<Func<GyurmaBase, bool>> expression)
	{
		var binaryExpressionsFlattened = GetBinaryExpressionsFlattened(expression);

		lookup = ToLookup(binaryExpressionsFlattened);
	}

	private static List<BinaryExpression> GetBinaryExpressionsFlattened(Expression<Func<GyurmaBase, bool>> x)
	{
		var collection = new List<BinaryExpression>();

		var q = new Queue<BinaryExpression>();
		q.Enqueue((BinaryExpression)x.Body);
		static bool IsFinalBinary(Expression e) => e is BinaryExpression be && be.Left is not BinaryExpression && be.Right is not BinaryExpression;
		BinaryExpression current = default!;
		while (q.Any())
		{
			current = q.Dequeue();

			if (IsFinalBinary(current))
			{
				collection.Add(current);
				break;
			}

			if (current.Left is BinaryExpression binaryLeft)
			{
				if (IsFinalBinary(binaryLeft))
				{
					collection.Add(binaryLeft);
				}
				else
				{
					q.Enqueue(binaryLeft);
				}
			}

			if (current.Right is BinaryExpression binaryRight)
			{
				if (IsFinalBinary(binaryRight))
				{
					collection.Add(binaryRight);
				}
				else
				{
					q.Enqueue(binaryRight);
				}
			}
		}

		return collection;
	}

	private IDictionary<string, Expression> ToLookup(List<BinaryExpression> binaryExpressionsFlattened)
	{
		var d = new Dictionary<string, Expression>();
		
		foreach (var item in binaryExpressionsFlattened)
		{
			if (item.Left is MethodCallExpression mce)
			{
				var name = mce.Method.Name;
				if (!d.ContainsKey(name))
				{
					d.Add(name, item.Right);
				}
			}
			else if (item.Left is UnaryExpression ue)
			{
				var name = ((MethodCallExpression)ue.Operand).Method.Name;
				if (!d.ContainsKey(name))
				{
					d.Add(name, item.Right);
				}
			}
			else if (item.Left is MemberExpression me)
			{
				var name = me.Member.Name;
				if (!d.ContainsKey(name))
				{
					d.Add(name, item.Right);
				}
			}
		}
		
		return d;
	}
}
