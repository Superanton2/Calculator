namespace CS201;
using System;

public class ASTBuilder
{
    private static MyStack<TreeNode> _stack;
    
    public static TreeNode BuildTree(MyList<string> tokens, RulesStorage rules)
    {
        _stack = new MyStack<TreeNode>();

        foreach (string token in tokens)
        {
            //число або змінна
            // if (double.TryParse(token, out _)) 
            if (double.TryParse(token, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                _stack.Add(new TreeNode(token));
            }
            
            // оператор
            else
            {   
                _processOperator(token, rules);
            }
        }
        return _stack.Remove();
    }

    private static void _processOperator(string token, RulesStorage rules)
    {
        Rule currentRule = rules.Find(token);
        
        
        TreeNode node = new TreeNode(token);
        TreeNode[] tempChildrens = new TreeNode[currentRule.ArgsCount];
        
        // витягуємо задом наперед
        for (int i = currentRule.ArgsCount - 1; i >= 0; i--)
        {
            tempChildrens[i] = _stack.Remove();
        }
        for (int i = 0; i < currentRule.ArgsCount; i++)
        {
            node.Children.Add(tempChildrens[i]);
        }
        
        _stack.Add(node);
    }
    
    public static void Print(TreeNode node, string indent = "", bool isLast = false, bool isRoot = true)
    {
        if (node == null) Console.WriteLine("Tree is empty");

        // поячткова відстань
        Console.Write(indent);

        if (!isRoot)
        {
            if (isLast) Console.Write("└── ");
            else Console.Write("├── ");
        }

        Console.WriteLine(node.Value);
        
        string a = "";

        if (!isRoot)
        {
            if (isLast) a = "    ";
            else a = "│   ";
        }
        
        string nextIndent = indent + a;
        
        // діти
        int childrenCount = node.Children.Length();
        for (int i = 0; i < childrenCount; i++)
        {
            bool isLastChild = (i == childrenCount - 1);
            Print(node.Children.Get(i), nextIndent, isLastChild, false);
        }
    }
}