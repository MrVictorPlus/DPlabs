//Console.WriteLine("Hello, World!");
//Console.ReadKey();

Console.WriteLine("Hello, Jerry!");

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("A");
    Console.WriteLine("B");
    Console.WriteLine("C");
    Thread.Sleep(500);
}

A();
A();
A();

void A()
{
    Console.WriteLine("Функция A");
    B();
    C();
}

void B()
{
    Console.WriteLine("Функция B");
}

void C()
{
    Console.WriteLine("Функция C");
}

