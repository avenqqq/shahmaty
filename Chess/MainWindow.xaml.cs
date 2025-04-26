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
        public MainWindow()
        {
            InitializeComponent();

            double cellWidth = Field.Width / 8;
            double cellHeight = Field.Height / 8;
            for (int i = 0; i < 64; i++)
            {
                var cell = new Rectangle();
                cell.Width = cellWidth;
                cell.Height = cellHeight;
                cell.Fill = new SolidColorBrush(((i / 8 + i % 8) % 2) == 0? Colors.Wheat : Colors.Black);
                cell.Margin = new Thickness(i % 8 * cellWidth, i / 8 * cellHeight, 0, 0);
                Field.Children.Add(cell);
            }

        }
    }
}