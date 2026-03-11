namespace CS201;

public class Calculator
{
    private RulesStorage _rulesStorage;
    private VariablesStorage _variablesStorage;
    private Computation _computation;
    
    public Calculator(bool defaultRules = true)
    {
        Console.WriteLine("Welcome to Calculator. Made by Anton");
        _rulesStorage = new RulesStorage(defaultRules);
        _variablesStorage = new VariablesStorage();
        _computation = new Computation(_rulesStorage, _variablesStorage);
    }
    

    public void AddRule(string name, int priority, int argsCount, Func<double[], double> action) => 
        _rulesStorage.AddRule(name, priority, argsCount, action);

    public void RemoveRule(string name) => _rulesStorage.RemoveRule(name);
    public void RemoveRuleAt(int index) => _rulesStorage.RemoveRuleAt(index);
    public void ShowRules() => _rulesStorage.ShowRules();
    
    
    public void AddVariable(string name, string value) => _variablesStorage.AddVariable(name, value, _rulesStorage);
    public void RemoveVariable(string name) => _variablesStorage.RemoveVariable(name);
    public void RemoveVariableAt(int index) => _variablesStorage.RemoveVariableAt(index);
    public void ShowVariables() => _variablesStorage.ShowVariables();
    
    
    public double Calculate(string userInput, bool AST=false) => _computation.Calculate(userInput, AST);
}