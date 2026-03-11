using CS201;
Console.WriteLine();

Calculator calculator = new Calculator(); 

calculator.ShowRules();
Console.WriteLine();

// double test = calculator.Calculate("1+3");
// // double test = calculator.Calculate("1 + 3");
// // double test = calculator.Calculate(" 1 +     3    ");
// Console.WriteLine("Answer: "+ test);
// Console.WriteLine();
//
// double b = calculator.Calculate("3 * (5 + 2) - 2", AST:true);
// Console.WriteLine("Answer: " + b);
// Console.WriteLine();
//
// calculator.RemoveRuleAt(0);
// double d = calculator.Calculate("1 + sin(1)");
// Console.WriteLine(d);
//
// double a = calculator.Calculate("max(, 2^(3+1-2), 5)", AST: true);
// Console.WriteLine("Answer: " + a);


calculator.AddRule("arccos", 4, 1, value => Math.Acos(value[0]));
calculator.AddRule("!", 6, 1, values =>
{
    int result = 1;
    for (int i = 1; i < values[0] + 1; i++)
    {
        result *= i;
    }
    return result;
});

calculator.AddRule("lg", 4, 1, values => Math.Log10(values[0]));
calculator.AddRule("ln", 4, 1, values => Math.Log(values[0]));
calculator.AddRule("log", 4, 1, values => Math.Log2(values[0]));

calculator.AddRule("%", 6, 2, values => (values[1] / 100) * values[0]);
calculator.AddRule("USD", 5, 1, values => (values[0] * 43.46) );
calculator.AddRule("Mod", 2, 2, values =>
{
    int first = (Int32) values[0];
    int second = (Int32) values[1];
    return first / second;
});


calculator.ShowRules();


double arccos = calculator.Calculate("(((cos( (arccos(12^(5*(0) - 3) ))) / 2)))", AST:true);
Console.WriteLine(arccos);




double g = calculator.Calculate("max( 2^3 * sin(30) + tg(45) , cos(60) * max(10 , 5*4) - ctg(45) )", AST:true);
Console.WriteLine(g);

Console.WriteLine();
Console.WriteLine();
calculator.AddVariable("Pi", Math.PI.ToString(System.Globalization.CultureInfo.InvariantCulture));
calculator.AddVariable("e", Math.E.ToString(System.Globalization.CultureInfo.InvariantCulture));
calculator.ShowVariables();
Console.WriteLine();
Console.WriteLine();
calculator.RemoveVariable("Pi");
calculator.ShowVariables();

double lne = calculator.Calculate("ln e");
Console.WriteLine(lne);

Console.WriteLine();
calculator.AddVariable("π", Math.PI.ToString(System.Globalization.CultureInfo.InvariantCulture));
calculator.ShowVariables();

calculator.AddVariable("x", "2+22");
calculator.AddVariable("y", "x");
double y = calculator.Calculate("y - 24", AST: true);
Console.WriteLine();
Console.WriteLine(y);

// тригонометрія через градуси
// кома - розділовий знак
// крапка - десяткові дроби