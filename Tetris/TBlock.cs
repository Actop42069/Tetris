namespace Tetris
{
    public class TBlock : Block
    {
        protected readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,1), new(1,0), new(1,1), new(1,2) },
            new Position[] {new (0,1), new (1,1), new (1,2), new (2,1) },
            new Position[] {new(1, 0), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 1) }
        };
        public override int ID => 6;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles; 
    }
}
