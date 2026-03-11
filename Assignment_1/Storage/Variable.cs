namespace CS201;

public class Variable
{
    private string _name;
    private MyList<string> _value;

    public Variable(string name, MyList<string> value)
    {
        _name = name;
        _value = value;
    }
    
    public string Name => _name;
    public MyList<string> Value => _value;
    
    public override string ToString()
    {
        string spaces = new string(' ', 5 - _name.Length);
        string value = String.Join(' ', _value);
        return $"{_name}{spaces}= {value}";
    }
}