namespace ConsoleApp1
{
    internal class Menu
    {
        private int option;

        public Menu(int option)
        {
            this.option = option;
        }

        public void execute()
        {
            switch (this.option)
            {
                case 0:
                    Console.WriteLine("enter a file name");
                    try
                    {
                        Console.WriteLine(
                            "amount of words " + this.count(
                                File.ReadAllText(Console.ReadLine()))
                        );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                case 1:
                    Console.WriteLine("enter first number");
                    double fN = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("enter second number");
                    double sN = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("which arithmetic operation to perform + , - , * , /");
                    char arithmeticOperator = Convert.ToChar(Console.ReadLine());

                    Console.WriteLine(this.calc(fN, sN, arithmeticOperator));
                    break;
                default:
                    Console.WriteLine("bb");
                    break;
            }
        }

        public int count(string text)
        {
            return text.Split(' ').Count();
        }

        public double calc(double fN, double sN, char arithmeticOperator)
        {
            switch (arithmeticOperator)
            {
                case '+':
                    return fN + sN;
                case '-':
                    return fN - sN;
                case '*':
                    return fN * sN;
                case '/':
                    return fN / sN;
                default:
                    throw new ArgumentException("try again", nameof(arithmeticOperator));
            }
        }
    }
}