using System.Globalization;
double salario, salarioNovo, calculo;

Console.WriteLine("-------------------------");
Console.WriteLine("REAJUSTE SALARIAL EM 10%");
Console.WriteLine("-------------------------\n");

Console.Write("Informe o salário:");
salario = Convert.ToDouble(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
calculo = salario * 0.1;
salarioNovo = salario + calculo;

Console.WriteLine("O novo salário é " + salarioNovo.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")) + " com reajuste de " + calculo.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
Console.Read();