// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

 // Initialize positions
Position spaceshipPosition = new Position(0, 0);
Position planetPosition = new Position(10, 10);
Position tradehubPosition = new Position(0, 0);

// Initialize planet
Planet planet = new Planet("Mars", planetPosition);
planet.AddResource(Resource.Iron, 100, 10);

// Initialize spaceship
Spaceship spaceship = new Spaceship(spaceshipPosition, 50, 10, 100);

// Initialize tradehub
Tradehub tradehub = new Tradehub();
tradehub.SetResourcePrice(Resource.Iron, 5);

// Simulation
Console.WriteLine("Spaceship flying to planet...");
spaceship.FlyTo(planet.Position);
spaceship.LandOnPlanet(planet.Position);

Console.WriteLine("Spaceship mining resources...");
var minedResources = planet.MineResources(Resource.Iron);
foreach (var resource in minedResources)
{
    spaceship.LoadCargo(resource.Key, resource.Value);
}

Console.WriteLine("Spaceship flying back to tradehub...");
spaceship.FlyTo(tradehubPosition);
spaceship.DockAtTradehub(tradehubPosition);

Console.WriteLine("Spaceship selling resources...");
var cargoCount = spaceship.GetCargoCount();
foreach (var resource in cargoCount)
{
    tradehub.SellResource(resource.Key, resource.Value);
}

Console.WriteLine($"Tradehub money: {tradehub.GetMoney()}");
