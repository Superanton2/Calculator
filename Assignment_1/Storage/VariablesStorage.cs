namespace CS201;

public class VariablesStorage
{
    private MyList<Variable> _variables;

    public VariablesStorage()
    {
        _variables = new MyList<Variable>();
    }
    
    public void AddVariable(string name, string value, RulesStorage rules)
    {
        foreach (Variable variable in _variables)
        {
            if (variable.Name == name)
            {
                throw new Exception("Variable already exists");
            }
        }
        
        MyList<string> valueTokens = Tokenizer.GetTokens(value);
        MyList<string> sortedTokens = ShuntingYard.PerformAlgorithm(valueTokens, rules, this);
        
        
        _variables.Add( new Variable(name, sortedTokens));
    }

    
    public void RemoveVariable(string name)
    {
        for (int i = 0; i < _variables.Length(); i++)
        {
            if (_variables.Get(i).Name == name)
            {
                _variables.RemoveAt(i);
            }
        }
    }

    public void ShowVariables()
    {
        foreach (Variable variable in _variables)
        {
            Console.WriteLine(variable);
        }
    }
    
    public Variable Find(string name)
    {
        for (int i = 0; i < _variables.Length(); i++)
        {
            if (_variables.Get(i).Name == name)
            {
                return _variables.Get(i);
            }
        }
        return null;
    }
}