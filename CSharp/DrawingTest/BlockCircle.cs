using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;
    internal class BlockCircle : Block
    {
        System.Windows.Shapes.Ellipse m_Shape = new System.Windows.Shapes.Ellipse();

        public BlockCircle(System.Drawing.Point centre, System.Drawing.Size size, Colour colorFill, Colour colorLine)
            : base(centre, size, colorFill, colorLine)
        { }

        public override void Draw(Canvas canvas)
        {
            // TODO Think this could be refactored.
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

        public override bool IsMouseOver(System.Drawing.Point point)
        {
            // TODO need to make this more circular.
            System.Drawing.Rectangle area = new System.Drawing.Rectangle(Position, Size);
            return area.Contains(point);
        }
    }
}
