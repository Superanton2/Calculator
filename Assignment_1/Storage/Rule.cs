namespace CS201;

public class Rule
{
    public string Name { get; }
    public int Priority { get; }
    public int ArgsCount { get; }
    public Func<double[], double> Action { get; }

    public Rule(string name, int priority, int argsCount, Func<double[], double> action)
    {
        Name = name;
        Priority = priority;
        ArgsCount = argsCount;
        Action = action;
    }

    public override string ToString()
    {
        string spaces = new string(' ', 8 - Name.Length);
        return $"Name: {Name}{spaces}| priority: {Priority}      | args: {ArgsCount}";
    }
}