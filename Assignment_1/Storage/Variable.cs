namespace CS201;

public class Variable
{
    public string Name { get ; }
    public MyList<string> Value { get; }
    private string _valuePrint;
    
    public Variable(string name, MyList<string> value, string valuePrint)
    {
        Name = name;
        Value = value;
        _valuePrint = valuePrint;
    }
    

    public override string ToString()
    {
        // string value = String.Join(' ', Value);
        string spaces = new string(' ', 4 - Name.Length);
        return $"{Name}{spaces}= {_valuePrint}";
    }
}