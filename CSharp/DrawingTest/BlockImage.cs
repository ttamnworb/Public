using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DrawingTest.BlockArrow;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;
    internal class BlockImage : Block
    {
        private Canvas m_Shape = new Canvas();
        private string m_Filename = string.Empty;
        public string Filename { get { return m_Filename; } set { m_Filename = value; } }
        public BlockImage(System.Drawing.Point position = new System.Drawing.Point(), System.Drawing.Size size = new System.Drawing.Size(), string filename = "")
            : base(position, size)
        {
            Filename = filename;
        }
        public override void Draw(Canvas canvas)
        {
            if (Index != Block.InvalidIndex)
            {
                canvas.Children.Remove(m_Shape);
            }
            BitmapImage theImage = new BitmapImage(new Uri(Filename, UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            m_Shape.Width = Size.Width;
            m_Shape.Height = Size.Height;
            m_Shape.Background = myImageBrush;
            Canvas.SetLeft(m_Shape, (double)X);
            Canvas.SetTop(m_Shape, (double)Y);

            Index = canvas.Children.Add(m_Shape);
        }


    }
}
