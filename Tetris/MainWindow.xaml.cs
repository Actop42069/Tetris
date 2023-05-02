using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource [] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri ("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/TileRed.png", UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri ("Assets/BLock-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-I.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-J.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-L.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-O.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-S.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-T.png", UriKind.Relative)),
            new BitmapImage(new Uri ("Assets/BLock-Z.png", UriKind.Relative))
        };

        private readonly Image[,] imageControls;
        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas (gameState.GameGrid);
        }
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for(int c = 0; r < grid.Columns; r++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r-2) * cellSize);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r ,c] = imageControl;
                }
            }
            return imageControls;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int ID = grid[r, c];
                    imageControls[r, c].Source = tileImages[ID];
                }
            }
        }
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePosition())
            {
                imageControls[p.Row, p.Column].Source = tileImages[block.ID];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
        }
        private void Window_KeyDown (object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }
            switch(e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down: 
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                default:
                    return;
            }
            Draw(gameState);
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Draw(gameState);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
