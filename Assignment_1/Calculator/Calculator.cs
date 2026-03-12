namespace CS201;

public class Calculator
{
    private RulesStorage _rulesStorage;
    private Computation _computation;
    
    public Calculator(bool defaultRules = true)
    {
        Console.WriteLine("Welcome to Calculator. Made by Anton");
        _rulesStorage = new RulesStorage(defaultRules);
        _computation = new Computation(_rulesStorage);
    }
    

    public void AddRule(string name, int priority, int argsCount, Func<double[], double> action) => 
        _rulesStorage.AddRule(name, priority, argsCount, action);

    public void RemoveRule(string name) => _rulesStorage.RemoveRule(name);
    public void RemoveRuleAt(int index) => _rulesStorage.RemoveRuleAt(index);
    public void ShowRules() => _rulesStorage.ShowRules();


    public void AddVariable(string name, string value)
    {
        _rulesStorage.AddRule(name, 4, 0, doubles => Calculate(value));   
    }
    public void RemoveVariable(string name) => _rulesStorage.RemoveRule(name);
    public void RemoveVariableAt(int index) => _rulesStorage.RemoveRuleAt(index);
    public void ShowVariables() => _rulesStorage.ShowRules();
    
    
    public double Calculate(string userInput, bool AST=false) => _computation.Calculate(userInput, AST);
}