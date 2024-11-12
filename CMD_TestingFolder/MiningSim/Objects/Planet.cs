public class Planet
{
    public Position Position { get; set; }
    public string Name { get; set; }
    public Dictionary<Resource, ResourceInfo> Resources { get; set; }

    public Planet(string name,Position position)
    {
        Name = name;
        Position = position;
        Resources = new Dictionary<Resource, ResourceInfo>();
    }

    public void AddResource(Resource resource, int amount, int miningSpeed)
    {
        if (Resources.ContainsKey(resource))
        {
            Resources[resource].Amount += amount;
            Resources[resource].MiningSpeed = miningSpeed; // Update mining speed if needed
        }
        else
        {
            Resources[resource] = new ResourceInfo(amount, miningSpeed);
        }
    }

    public void RemoveResource(Resource resource, int amount)
    {
        if (Resources.ContainsKey(resource))
        {
            Resources[resource].Amount -= amount;
            if (Resources[resource].Amount <= 0)
            {
                Resources.Remove(resource);
            }
        }
    }

    public Dictionary<Resource, ResourceInfo> GetResourceInfos()
    {
        return Resources;
    }

    public Dictionary<Resource, int> MineResources(Resource resource)
    {
        return MineResource(resource, Resources[resource].MiningSpeed);
    }

    private Dictionary<Resource, int> MineResource(Resource resource, int miningSpeed)
    {
        var minedResources = new Dictionary<Resource, int>();
        minedResources[resource] = 0;

        if (Resources.ContainsKey(resource))
        {
            int minedAmount = Math.Min(Resources[resource].Amount, miningSpeed);
            Resources[resource].Amount -= minedAmount;
            if (Resources[resource].Amount <= 0)
            {
                Resources.Remove(resource);
            }
            minedResources[resource] = minedAmount;
        }

        return minedResources;
    }
}