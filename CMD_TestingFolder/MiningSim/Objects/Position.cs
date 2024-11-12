public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Moving_Move(Position pos){
        Moving_UpdateOwnPosition(Moving_CalculateJumpVector(pos));
        return Moving_CalculateDistanceTo(pos);
    }

    public int Moving_CostToMove(Position pos){
        return Moving_CalculateDistanceTo(pos);
    }

    private void Moving_UpdateOwnPosition(Position vector)
    {
        X += vector.X;
        Y += vector.Y;
    }

    private Position Moving_CalculateJumpVector(Position position)
    {
        int x = 0; x -= position.X;
        int y = 0; y-= position.Y;

        return new Position(x, y);
    }

    private int Moving_CalculateDistanceTo(Position other)
    {
        int deltaX = X - other.X;
        int deltaY = Y - other.Y;
        return (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}