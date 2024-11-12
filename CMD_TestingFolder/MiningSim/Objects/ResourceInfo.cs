public class ResourceInfo
{
    public int Amount { get; set; }
    public int MiningSpeed { get; set; }

    public ResourceInfo(int amount, int miningSpeed)
    {
        Amount = amount;
        MiningSpeed = miningSpeed;
    }
}