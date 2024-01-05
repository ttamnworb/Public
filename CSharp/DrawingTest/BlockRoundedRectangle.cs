using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;
    internal class BlockRoundedRectangle : Block
    {
        System.Windows.Shapes.Rectangle m_Shape = new System.Windows.Shapes.Rectangle();
        System.Drawing.Size m_Radius = new Size(0, 0);
        System.Drawing.Size Radius { get { return m_Radius; } set { m_Radius = value; } }
        public BlockRoundedRectangle(System.Drawing.Point topLeft, System.Drawing.Size size, Colour colorFill, Colour colorLine, System.Drawing.Size radius)
            : base(topLeft, size, colorFill, colorLine)
        { 
            Radius = radius;
        }

        public override void Draw(Canvas canvas)
        {
            if (Index != Block.InvalidIndex)
            {
                canvas.Children.Remove(m_Shape);
            }
            else
            {
                m_Shape = new System.Windows.Shapes.Rectangle();
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

            m_Shape.RadiusX = m_Radius.Width;
            m_Shape.RadiusY = m_Radius.Height;

            Index = canvas.Children.Add(m_Shape);
            Canvas.SetLeft(m_Shape, (double)X);
            Canvas.SetTop(m_Shape, (double)Y);
        }
    }
}
