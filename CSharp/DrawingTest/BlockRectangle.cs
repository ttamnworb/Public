using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;

    internal class BlockRectangle : Block
    {
        System.Windows.Shapes.Rectangle m_Shape = new System.Windows.Shapes.Rectangle();

        public BlockRectangle(System.Drawing.Point topLeft, System.Drawing.Size size, Colour colorFill, Colour colorLine)
            : base(topLeft, size, colorFill, colorLine)
        { }

        public override void Draw(Canvas canvas)
        {
            if (Index != Block.InvalidIndex)
            {
                canvas.Children.Remove(m_Shape);
            }
 
            m_Shape.Width = Size.Width;
            m_Shape.Height = Size.Height;

            SolidColorBrush lineBrush = new SolidColorBrush(LineColor);
            m_Shape.Stroke = lineBrush;
            m_Shape.StrokeThickness = 1;
            if (IsFilled)
            {
                SolidColorBrush fillBrush = new SolidColorBrush(FillColor);
                m_Shape.Fill = fillBrush;
            }

            Index = canvas.Children.Add(m_Shape);
            Canvas.SetLeft(m_Shape, (double)X);
            Canvas.SetTop(m_Shape, (double)Y);
        }
    }
}
