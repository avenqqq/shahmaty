using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ChessLib;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double cellWidth;
        private double cellHeight;
        public MainWindow()
        {
            InitializeComponent();

            cellWidth = Field.Width / 8;
            cellHeight = Field.Height / 8;
            char[] board = new char[64];
            for (int i = 0; i < 64; i++)
            {
                var cell = new Rectangle();
                cell.Width = cellWidth;
                cell.Height = cellHeight;
                cell.Fill = new SolidColorBrush(((i / 8 + i % 8) % 2) == 0? Colors.Wheat : Colors.Black);
                cell.Margin = new Thickness(i % 8 * cellWidth, i / 8 * cellHeight, 0, 0);
                Field.Children.Add(cell);
                board[i] = 'K';
            }
            InitBoard(board);
        }

        private string GetFigureImage(char c) {
            string str = char.IsUpper(c) ? "W" : "B";
            c = char.ToLower(c);
            if (c == 'k')
                return str + "King.png";
            if (c == 'n')
                return str + "Knight.png";
            if (c == 'r')
                return str + "Rook.png";
            if (c == 'q')
                return str + "Queen.png";
            if (c == 'p')
                return str + "Pawn.png";
            if (c == 'b')
                return str + "Bishop.png";

            return "";
        }

        public void InitBoard(char[] pos)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                Image im = new Image();
                BitmapImage mipMap = new BitmapImage();
                mipMap.BeginInit();
                mipMap.UriSource = new Uri("pack://application:,,," + (pos[i]));
                mipMap.EndInit();
                im.Source = mipMap;
                Field.Children.Add(im);
            }
        }
    }
}