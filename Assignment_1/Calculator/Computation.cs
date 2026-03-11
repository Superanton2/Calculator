namespace CS201;

public class Computation
{
    private RulesStorage _rulesStorage;
    private VariablesStorage _variablesStorage;

    public Computation(RulesStorage rulesStorage, VariablesStorage variablesStorage)
    {
        _rulesStorage = rulesStorage;
        _variablesStorage = variablesStorage;
    }

    public double Calculate(string userInput, bool AST=false )
    {
        MyList<string> tokens = Tokenizer.GetTokens(userInput);
        MyList<string> sortedTokens = ShuntingYard.PerformAlgorithm(tokens, _rulesStorage, _variablesStorage);
        
        double result = _performCalculations(sortedTokens);
        if (AST) _ASTtree(sortedTokens);
        
        return Math.Round(result, 10);
    }

    private double _performCalculations(MyList<string> tokens)
    {
        MyStack<double> stack = new MyStack<double>();
    
        foreach (string token in tokens)
        {
            _processToken(token, stack);
        }
        
        if (stack.Length() != 1)
        {
            throw new ArgumentException("Incorrect expression: after calculation, extra numbers remained!");
        }
    
        return stack.Remove();
    }

    private void _processToken(string token, MyStack<double> stack)
    {
        // число або змінна
        // if (double.TryParse(token, out double number))
        if (double.TryParse(token, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double number))
        {
            stack.Add(number);
        }
        // змінна
        else if (_variablesStorage.Find(token) != null)
        {
            MyList<string> variableTokens = _variablesStorage.Find(token).Value;
            double varResult = _performCalculations(variableTokens);
            stack.Add(varResult);
        }
        
        
        // оператор
        else
        {
            Rule currentRule = _rulesStorage.Find(token);
            // кількість аргументів
            double[] args = new double[currentRule.ArgsCount];

            // задом наперед
            for (int i = currentRule.ArgsCount - 1; i >= 0; i--)
            {
                // Захист: якщо чисел у стеку менше, ніж вимагає функція
                if (stack.IsEmpty())
                {
                    throw new ArgumentException($"There are not enough arguments for the operation '{token}'!");
                }

                args[i] = stack.Remove();
            }

            // виконуємо операцію
            double result = currentRule.Action(args);
            stack.Add(result);
        }
    }
    
    
    
    private void _ASTtree(MyList<string> tokens)
    {
        // вище, перший
        TreeNode root = ASTBuilder.BuildTree(tokens, _rulesStorage, _variablesStorage);
        ASTBuilder.Print(root);
    }
}