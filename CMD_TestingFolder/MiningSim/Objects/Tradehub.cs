using System.Collections.Generic;

public class Tradehub
{
    public Dictionary<Resource, int> ResourcePrices { get; set; }
    private int Money { get; set;}

    public Tradehub()
    {
        ResourcePrices = new Dictionary<Resource, int>();
        Money = 0;
    }

    public int GetMoney()
    {
        int tmp = Money;
        Money = 0;
        return tmp;
    }

    public void SetResourcePrice(Resource resource, int price)
    {
        ResourcePrices[resource] = price;
    }

    public void SellResource(Resource resource, int amount)
    {
        if (ResourcePrices.ContainsKey(resource))
        {
            int totalValue = ResourcePrices[resource] * amount;
            Money += totalValue;
        }
    }
}