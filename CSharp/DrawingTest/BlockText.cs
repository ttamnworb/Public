using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawingTest
{
    using static DrawingTest.BlockArrow;
    using Colour = System.Windows.Media.Color;
    internal class BlockText : Block
    {
        private System.Windows.Shapes.Rectangle m_Shape = new System.Windows.Shapes.Rectangle();
        private string m_Text = string.Empty;
        public string Text { get { return m_Text; } set { m_Text = value; } }

        public BlockText(System.Drawing.Point position = new System.Drawing.Point(), System.Drawing.Size size = new System.Drawing.Size(), Colour colorFill = new Colour(), Colour colorLine = new Colour())
            : base(position, size, colorFill, colorLine)
        {
        }
        public override void Draw(Canvas canvas)
        {
            // TODO Finish this

            if (Index != Block.InvalidIndex)
            {
                canvas.Children.Remove(m_Shape);
            }

            // Create a new DrawingGroup of the control.
            DrawingGroup drawingGroup = new DrawingGroup();

            // Open the DrawingGroup in order to access the DrawingContext.
            using (DrawingContext drawingContext = drawingGroup.Open())
            {
                // Create the formatted text based on the properties set.
#pragma warning disable CS0618 // Type or member is obsolete
                FormattedText formattedText = new FormattedText(
                    Text,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Comic Sans MS Bold"),
                    48,
                    System.Windows.Media.Brushes.Black // This brush does not matter since we use the geometry of the text.
                    );
#pragma warning restore CS0618 // Type or member is obsolete

                // Build the geometry object that represents the text.
                Geometry textGeometry = formattedText.BuildGeometry(new System.Windows.Point(20, 0));

                // Draw a rounded rectangle under the text that is slightly larger than the text.
                drawingContext.DrawRoundedRectangle(System.Windows.Media.Brushes.PapayaWhip, null, new Rect(new System.Windows.Size(formattedText.Width + 50, formattedText.Height + 5)), 5.0, 5.0);

                // Draw the outline based on the properties that are set.
                drawingContext.DrawGeometry(System.Windows.Media.Brushes.Gold, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Maroon, 1.5), textGeometry);

                // Return the updated DrawingGroup content to be used by the control.
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
