using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;

    internal class BlockArrow : Block
    {
        public enum EOrientation
        {   // Point to the ...
            Right,
            Left,
            Up,
            Down
        }

        public EOrientation Orientation { get; set; }

        private System.Windows.Shapes.Polygon m_Shape = new System.Windows.Shapes.Polygon();
        
        public BlockArrow(System.Drawing.Point position = new System.Drawing.Point(), System.Drawing.Size size = new System.Drawing.Size(), Colour colorFill = new Colour(), Colour colorLine = new Colour())
            : base(position, size, colorFill, colorLine)
        {
            Orientation = EOrientation.Right;
        }
        public override void Draw(Canvas canvas)
        {
            // The arrow point in the XY of the object (point 0).
            // The two corners of the triangle are points 1 and 2
            // The two corners of the rectangle nearest the point are 3 & 4
            // The two other corners of the rectangle are 5 & 6.
            if (Index != Block.InvalidIndex)
            {
                canvas.Children.Remove(m_Shape);
            }

            // TODO These could be calculated only when the Size changes to improve performance.
            double thirdSizeX = Size.Width * 0.33;
            double twoThirdSizeX = Size.Width - thirdSizeX;
            double halfSizeX = Size.Width * 0.5;
            double quarterSizeX = Size.Width * 0.25;

            double thirdSizeY = Size.Height * 0.33;
            double twoThirdSizeY = Size.Height - thirdSizeY;
            double halfSizeY = Size.Height * 0.5;
            double quarterSizeY = Size.Height * 0.25;

            m_Shape.Points.Clear();
            switch (Orientation)
            {
                case EOrientation.Left:
                    {
                        m_Shape.Points.Add(new System.Windows.Point(0, halfSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(thirdSizeX, Size.Height));
                        m_Shape.Points.Add(new System.Windows.Point(thirdSizeX, Size.Height - quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, Size.Height - quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(thirdSizeX, quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(thirdSizeX, 0));
                        m_Shape.Points.Add(new System.Windows.Point(0, halfSizeY));
                    }
                    break;
                case EOrientation.Right:
                    {
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, halfSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(twoThirdSizeX, 0));
                        m_Shape.Points.Add(new System.Windows.Point(twoThirdSizeX, quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(0, quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(0, halfSizeY + quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(twoThirdSizeX, halfSizeY + quarterSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(twoThirdSizeX, Size.Height));
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, halfSizeY));
                    }
                    break;
                case EOrientation.Up:
                {
                        m_Shape.Points.Add(new System.Windows.Point(halfSizeX, 0));
                        m_Shape.Points.Add(new System.Windows.Point(0, thirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX, thirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX, Size.Height));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX+halfSizeX, Size.Height));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX + halfSizeX, thirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, thirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(halfSizeX, 0));
                    }
                break;
                case EOrientation.Down:
                {
                        m_Shape.Points.Add(new System.Windows.Point(halfSizeX, Size.Height));
                        m_Shape.Points.Add(new System.Windows.Point(Size.Width, twoThirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX + halfSizeX, twoThirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX + halfSizeX, 0));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX, 0));
                        m_Shape.Points.Add(new System.Windows.Point(quarterSizeX, twoThirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(0, twoThirdSizeY));
                        m_Shape.Points.Add(new System.Windows.Point(halfSizeX, Size.Height));
                    }
                break;
            }

            m_Shape.HorizontalAlignment = HorizontalAlignment.Left;
            m_Shape.VerticalAlignment = VerticalAlignment.Top;
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
            // TODO need to make this more arrow like.
            System.Drawing.Rectangle area = new System.Drawing.Rectangle(Position, Size);
            return area.Contains(point);
        }
    }
}
