namespace RobotToy.Domain
{
    public class TableDimensions
    {
        public const int DefaultSize = 5;

        public TableDimensions(int inputWidth, int inputLength)
        {
            Width = inputWidth;
            Length = inputLength;
        }

        public TableDimensions()
        {
            Width = DefaultSize;
            Length = DefaultSize;
        }


        public int Length { get; }
        public int Width { get; }
    }
}