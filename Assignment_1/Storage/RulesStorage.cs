namespace CS201;

public class RulesStorage
{
    private MyList<Rule> _rules;

    public RulesStorage(bool defaultRules = true)
    {
        _rules = new MyList<Rule>();
        if (defaultRules)
        {
            VariablesStorage variables = new VariablesStorage();
            AddRule("+", 1, 2, args => args[0] + args[1], variables);
            AddRule("-", 1, 2, args => args[0] - args[1], variables);
            AddRule("*", 2, 2, args => args[0] * args[1], variables);
            AddRule("/", 2, 2, args => args[0] / args[1], variables);
            AddRule("^", 3, 2, args => Math.Pow(args[0], args[1]), variables);
            
            AddRule("sin", 4, 1, args => Math.Sin(args[0] * Math.PI / 180.0), variables);
            AddRule("cos", 4, 1, args => Math.Cos(args[0] * Math.PI / 180.0), variables);
            AddRule("tg", 4, 1, args => Math.Tan(args[0] * Math.PI / 180.0), variables);
            AddRule("ctg", 4, 1, args => 1.0 / Math.Tan(args[0] * Math.PI / 180.0), variables);

            
            AddRule("max", 4, 2, args => Math.Max(args[0], args[1]), variables);
            AddRule("min", 4, 2, args => Math.Min(args[0], args[1]), variables);

            AddRule("(", 0, 0, null, variables);
            AddRule(")", 0, 0, null, variables);
        }
    }

    public Rule Find(string name)
    {
        for (int i = 0; i < _rules.Length(); i++)
        {
            if (_rules.Get(i).Name == name)
            {
                return _rules.Get(i);
            }
        }
        return null;
    }
    
    
    public void AddRule(string name, int priority, int argsCount, Func<double[], double> action, 
        VariablesStorage variables)
    {
        if (variables.Find(name) != null)
        {
            throw new ArgumentException($"Rule {name} is already defined as a variable");
        }
        if (Find(name) != null)
        {
            throw new Exception("Rule already exists");
        }

        _rules.Add(new Rule(name, priority, argsCount, action));
    }

    public void RemoveRule(string name)
    {
        for (int i = 0; i < _rules.Length(); i++)
        {
            if (_rules.Get(i).Name == name)
            {
                _rules.RemoveAt(i);
            }
        }
    }

    public void RemoveRuleAt(int index) => _rules.RemoveAt(index);

    public void ShowRules()
    {
        Console.WriteLine();
        Console.WriteLine("Rules:");
        for (int i = 0; i < _rules.Length(); i++)
        {
            string spaces = new string(' ', (3 - i.ToString().Length));
            Console.WriteLine($"{i}{spaces}| {_rules.Get(i)}");
        }
    }
}