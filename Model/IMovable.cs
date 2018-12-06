namespace PlatLegeretSain.Model
{
    public interface IMovable
    {
        int X { get; set; }
        int Y { get; set; }

        void MoveUp(int distance);
        void MoveDown(int distance);
        void MoveLeft(int distance);
        void MoveRight(int distance);
    }
}