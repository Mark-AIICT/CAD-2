System.Console.WriteLine("Type a number");
int number = Convert.ToInt32(Console.ReadLine());
int result = MwCadMath.MathOps.Cube(number);
System.Console.WriteLine($"The cube of {number} is {result}");
Console.ReadLine();

