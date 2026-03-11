namespace CS201;
public class Tokenizer
{
    private static MyList<string> _resultList;
    private static string _numberBuffer;
    private static string _letterBuffer;
    
    public static MyList<string> GetTokens(string userInput)
    {
        _resultList = new MyList<string>();
        _numberBuffer = "";
        _letterBuffer = "";
        
        for (int i = 0; i < userInput.Length; i++)
        {
            char c = userInput[i];
            _processChar(c);
        }
        
        FlushBuffers();
        MyList<string> tokens = _resultList;
        _resultList =  default;
        
        return tokens;
    }

    
    private static void _processChar(char c)
    {
        if (char.IsWhiteSpace(c))
        {
            FlushBuffers();
            return;
        }

        // цифри та кома
        if (char.IsDigit(c) || c == '.' || c == ',')
        {
            // перший аргумент закінчився
            if (c == ',')
            {
                FlushBuffers();
                _resultList.Add(",");
            }
            else
            {
                if (_letterBuffer.Length > 0) FlushBuffers(); 
                _numberBuffer += c;
            }
        }
            
        // букви
        else if (char.IsLetter(c))
        {
            // якщо перед букою цифра
            if (_numberBuffer.Length > 0) FlushBuffers();
                
            _letterBuffer += c;
        }

        else
        {
            FlushBuffers();
            _resultList.Add(c.ToString());
        }
    }


    private static void FlushBuffers()
    {
        if (_numberBuffer.Length > 0)
        {
            _resultList.Add(_numberBuffer);
            _numberBuffer = "";
        }
        if (_letterBuffer.Length > 0)
        {
            _resultList.Add(_letterBuffer);
            _letterBuffer = "";
        }
    }
}