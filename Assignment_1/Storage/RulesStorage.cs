namespace CS201;

public class RulesStorage
{
    private MyList<Rule> _rules;

    public RulesStorage(bool defaultRules = true)
    {
        _rules = new MyList<Rule>();
        if (defaultRules)
        {
            AddRule("+", 1, 2, args => args[0] + args[1]);
            AddRule("-", 1, 2, args => args[0] - args[1]);
            AddRule("*", 2, 2, args => args[0] * args[1]);
            AddRule("/", 2, 2, args => args[0] / args[1]);
            AddRule("^", 3, 2, args => Math.Pow(args[0], args[1]));
            
            AddRule("sin", 4, 1, args => Math.Sin(args[0] * Math.PI / 180.0));
            AddRule("cos", 4, 1, args => Math.Cos(args[0] * Math.PI / 180.0));
            AddRule("tg", 4, 1, args => Math.Tan(args[0] * Math.PI / 180.0));
            AddRule("ctg", 4, 1, args => 1.0 / Math.Tan(args[0] * Math.PI / 180.0));

            
            AddRule("max", 4, 2, args => Math.Max(args[0], args[1]));
            AddRule("min", 4, 2, args => Math.Min(args[0], args[1]));

            AddRule("(", 0, 0, null);
            AddRule(")", 0, 0, null);
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
    
    
    public void AddRule(string name, int priority, int argsCount, Func<double[], double> action)
    {
        foreach (Rule rule in _rules)
        {
            if (rule.Name == name)
            {
                throw new Exception("Rule already exists");
            }
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