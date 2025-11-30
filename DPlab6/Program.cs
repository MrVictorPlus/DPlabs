int a = InputPositiveInt("a");
int b = InputPositiveInt("b");
int c = InputPositiveInt("c");

int product = a * b * c;
Console.WriteLine(product);

static int InputPositiveInt(string name)
{
    while (true)
    {
        Console.Write($"Enter {name}: ");
        string str = Console.ReadLine();

        int result;
        bool parsed = int.TryParse(str, out result);

        if (!parsed)
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }

        if (result <= 2)
        {
            Console.WriteLine("Number must be greater than 2.");
            continue;
        }

        return result;
    }
}

