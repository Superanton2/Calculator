using System.ComponentModel;

namespace CS201;

public class VariablesStorage
{
    private MyList<Variable> _variables;

    public VariablesStorage()
    {
        _variables = new MyList<Variable>();
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
    
    public void AddVariable(string name, string value, RulesStorage rules)
    {
        
        foreach (Variable variable in _variables)
        {
            if (variable.Name == name)
            {
                throw new WarningException($"Variable {name} was already defined. Now it's value is {value}");
            }
        }
        
        MyList<string> valueTokens = Tokenizer.GetTokens(value);
        MyList<string> sortedTokens = ShuntingYard.PerformAlgorithm(valueTokens, rules, this);
        
        
        _variables.Add( new Variable(name, sortedTokens, value));
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

    public void RemoveVariableAt(int index) => _variables.RemoveAt(index);
    
    public void ShowVariables()
    {
        Console.WriteLine();
        Console.WriteLine("Variables: ");
        for (int i = 0; i < _variables.Length(); i++)
        {
            string spaces = new string(' ', 3- i.ToString().Length);
            Console.WriteLine($"{i}{spaces}| {_variables.Get(i)}");
        }
    }
}