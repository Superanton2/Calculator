using CS201;
Console.WriteLine();

Calculator calculator = new Calculator(); 



// ПРАВИЛА
calculator.ShowRules();
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

try { calculator.AddRule("lg", 4, 1, values => Math.Log10(values[0])); }
catch (Exception e)
{
    Console.WriteLine();
    Console.WriteLine(e);
}

calculator.ShowRules();

calculator.RemoveRule("lg");
calculator.RemoveRuleAt(13);
calculator.ShowRules();
// повернув правила наазд
calculator.AddRule("arccos", 4, 1, value => Math.Acos(value[0]));
calculator.AddRule("lg", 4, 1, values => Math.Log10(values[0]));




// ЗМІННІ
calculator.ShowVariables();
// інтуп для того щоб була крапка, а не кома
calculator.AddVariable("Pi", Math.PI.ToString(System.Globalization.CultureInfo.InvariantCulture)); // "π"
calculator.AddVariable("e", Math.E.ToString(System.Globalization.CultureInfo.InvariantCulture));
calculator.AddVariable("x", "2 + 23");
calculator.AddVariable("y", "x");
calculator.ShowVariables();

calculator.RemoveVariable("y");
calculator.RemoveVariableAt(2);
calculator.ShowVariables();
calculator.AddVariable("x", "2 + 20");



// ПРИКЛАДИ
double basic1 = calculator.Calculate("1+3"); 
double basic2 = calculator.Calculate("1 + 3");
double basic3 = calculator.Calculate(" 1 +     3    ");
Console.WriteLine($"'1+3' = {basic1} \n'1 + 3' = {basic2} \n' 1 +     3    ' = {basic3}\n\n");


double fractional1 = calculator.Calculate("1.5 + 2.5"); // 4
double fractional2 = calculator.Calculate("10.5 * 2");  // 21
Console.WriteLine($"'1.5 + 2.5' = {fractional1} \n'10.5 * 2' = {fractional2}\n\n");


double trigonometric1 = calculator.Calculate("sin(30) + cos(60)"); // 1
double trigonometric2 = calculator.Calculate("tg(45) - ctg(45)");  // 0
double trigonometric3 = calculator.Calculate("sin(0) + cos(0)");   // 1
Console.WriteLine($"'sin(30) + cos(60)' = {trigonometric1} \n'tg(45) - ctg(45)' = {trigonometric2} \n'sin(0) + cos(0)' = {trigonometric3}\n\n");


double functions1 = calculator.Calculate("5!");        // 120
double functions2 = calculator.Calculate("ln e + 2");  // 2 
double functions3 = calculator.Calculate("ln(e + 1)"); // 0.69...
double functions4 = calculator.Calculate("max(10, 20) * min(5, 10)"); // 100
double functions5 = calculator.Calculate("Mod(10, 3)"); // 3
Console.WriteLine($"'5!' = {functions1} \n'ln e + 2' = {functions2} \n'ln(e + 1)' = {functions3} \n" +
                  $"'max(10, 20) * min(5, 10)' = {functions4} \n'Mod(10, 3)' = {functions5}");


calculator.Calculate("3 * (5 + 2) - 2", AST:true);
calculator.Calculate("max(, 2^(3+1-2), 5)", AST: true);
calculator.Calculate("max( 2^3 * sin(30) + tg(45) , cos(60) * max(10 , 5*4) - ctg(45) )", AST:true);


// тригонометрія через градуси
// округлення до 10 знаків після коми
// кома - розділовий знак
// крапка - десяткові дроби