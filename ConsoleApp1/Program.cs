using ConsoleApp1;

Console.WriteLine("(0)Text counter\n(1)Calculator");
Menu menu = new Menu(Convert.ToInt32(Console.ReadLine()));
menu.execute();