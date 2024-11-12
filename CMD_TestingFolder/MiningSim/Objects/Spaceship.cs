public class Spaceship
{
    public Position Position { get; set; }
    public int MaxCargoSize { get; set; }
    public int CurrentCargoSize { get { return Cargo.Count; } }
    public List<Resource> Cargo { get; set; }
    public int Speed { get; set; }
    public int Fuel { get; set; }
    public int MaxFuel { get; set; }
    public SpaceshipState State { get; private set; }
    public List<Position> KnownTradeStations { get; set; }
    public List<Position> KnownPlanets { get; set; }

    public Spaceship(Position position, int maxCargoSize, int speed, int fuel)
    {
        Position = position;
        MaxCargoSize = maxCargoSize;
        Speed = speed;
        Fuel = fuel;
        MaxFuel = fuel;
        Cargo = new List<Resource>();
        State = SpaceshipState.Idle;

        // Initialize known trade stations and planets with some predefined positions
        KnownTradeStations = new List<Position>
        {
            new Position(0, 0), // Tradehub at origin
            new Position(20, 20) // Another tradehub
        };

        KnownPlanets = new List<Position>
        {
            new Position(10, 10), // Planet 1
            new Position(30, 30) // Planet 2
        };
    }

    public void FlyTo(Position position)
    {
        Position.Moving_Move(position);
        State = SpaceshipState.InTransit;
    }

    public void DockAtTradehub(Position tradehubPosition)
    {
        if (Position.Equals(tradehubPosition))
        {
            State = SpaceshipState.DockedAtTradehub;
        }
    }

    public void LandOnPlanet(Position planetPosition)
    {
        if (Position.Equals(planetPosition))
        {
            State = SpaceshipState.DockedAtPlanet;
        }
    }

    public Dictionary<Resource, int> GetCargoCount()
    {
        return Cargo.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    }

    public Error LoadCargo(Resource resource, int amount)
    {
        if (CurrentCargoSize + amount > MaxCargoSize)
        {
            return Error.NotEnoughCargoSpace;
        }

        for (int i = 0; i < amount; i++)
        {
            Cargo.Add(resource);
        }

        return Error.None;
    }

    public Error UnloadCargo(Resource resource, int amount)
    {
        if (Cargo.Count(c => c == resource) < amount)
        {
            return Error.NotEnoughCargoLoaded;
        }

        for (int i = 0; i < amount; i++)
        {
            Cargo.Remove(resource);
        }

        return Error.None;
    }
}