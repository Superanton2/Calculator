using System.Security.Cryptography;

namespace CS201;


public class ShuntingYard
{

    private static MyList<string> _output;
    private static MyStack<string> _stack;
    
    public static MyList<string> PerformAlgorithm(MyList<string> tokens, RulesStorage rules)
    {
        _output = new MyList<string>();
        _stack = new MyStack<string>();
        
        foreach (string token in tokens)
        {
            _processToken(token, rules);
        }
    
        // забираємо все що лишилось в стеку
        while (!_stack.IsEmpty())
        {
            _output.Add(_stack.Remove());
        }

        return _output;
    }

    private static void _processToken(string token, RulesStorage rules)
    {
        // цифра або змінна
        if (double.TryParse(token, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
        {
            _output.Add(token);
        }
        
        
        // дужки
        else if (token == "(")
        {
            _stack.Add(token);
        }
        else if (token == ")")
        {
            while (!_stack.IsEmpty() && _stack.Peek() != "(")
            {
                _output.Add(_stack.Remove());
            }
            
            if ( _stack.Peek() == "(") _stack.Remove();
        }
        
        
        // перший аргумент закінчився
        else if (token == ",")
        {
            while (!_stack.IsEmpty() && _stack.Peek() != "(")
            {
                _output.Add(_stack.Remove());
            }
        }
        
        // оператори та функції
        else
        {
            _processOperator(token, rules);
        }
    }

    private static void _processOperator(string token, RulesStorage rules)
    {
        Rule currentRule = rules.Find(token);
        
        // якщо є правило
        if (currentRule != null)
        {
            // перевірка на пріоритетність
            while (!_stack.IsEmpty() && _stack.Peek() != "(")
            {
                Rule topRule = rules.Find(_stack.Peek());

                // Remove поки зверхи більший або такий самий пріоритет
                if (topRule.Priority >= currentRule.Priority)
                {
                    _output.Add(_stack.Remove());
                }
                else
                {
                    break;
                }
            }
            _stack.Add(token);
        }
        else
        {
            throw new ArgumentException($"Unknown token: {token}");
        }
    }
}