using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ImageSource[] tileImages = new ImageSource[]
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
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
