namespace Nucleo.Generators.Abstractions;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class GyurmaAttribute : Attribute
{
	///	asdasdasd
	public GyurmaAttribute(params Type[] type)
	{
		Type = type;
	}

	public Type[] Type { get; }
}
