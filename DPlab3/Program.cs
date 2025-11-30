struct Prices
{
    public int Drink;
    public int FirstDish;
    public int SecondDish;
}

struct Order
{
    public int DrinkCount;
    public int FirstDishCount;
    public int SecondDishCount;
}

class Program
{
    static int CalculateOrderCost(Prices prices, Order order)
    {
        return prices.Drink * order.DrinkCount +
               prices.FirstDish * order.FirstDishCount +
               prices.SecondDish * order.SecondDishCount;
    }

    static void Main()
    {
        Prices menuPrices;
        menuPrices.Drink = 10;
        menuPrices.FirstDish = 20;
        menuPrices.SecondDish = 30;

        Order client1Order;
        client1Order.DrinkCount = 2;
        client1Order.FirstDishCount = 1;
        client1Order.SecondDishCount = 0;

        int client1Total = CalculateOrderCost(menuPrices, client1Order);
        System.Console.WriteLine("Стоимость заказа первого клиента: " + client1Total);

        Order client2Order;
        client2Order.DrinkCount = 1;
        client2Order.FirstDishCount = 2;
        client2Order.SecondDishCount = 3;

        int client2Total = CalculateOrderCost(menuPrices, client2Order);
        System.Console.WriteLine("Стоимость заказа второго клиента: " + client2Total);
    }
}
