using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;
    internal class BlockProcess : Block
    {
        protected BlockRectangle m_Rectangle;
        protected Dictionary<BlockArrow.EOrientation, BlockArrow> m_Arrows;

        public BlockProcess(System.Drawing.Point topLeft, System.Drawing.Size size, Colour colorFill, Colour colorLine)
            : base(topLeft, size, colorFill, colorLine)
        {
            // The rectangle formed by topLeft .. size is the overall area for the shape.
            // The central rectangle will cover w/2,h/2
            // The arrows will be w/4,h/4
            double XHalf = size.Width * 0.5;
            double XQuarter = XHalf * 0.5;
            double X8th = XQuarter * 0.5;
            double YHalf = size.Height * 0.5;
            double YQuarter = YHalf * 0.5;
            double Y8th = YQuarter * 0.5;

            System.Drawing.Point rectangle_TL = new System.Drawing.Point((int)(XQuarter), (int)(YQuarter));
            System.Drawing.Size rectangle_Size = new System.Drawing.Size((int)(XHalf), (int)(YHalf));

            System.Drawing.Size arrowSize = new System.Drawing.Size((int)(XQuarter), (int)(YQuarter));   // All arrows are the same size.

            System.Drawing.Point arrow_up = new System.Drawing.Point((int)(XHalf - X8th), 0);
            System.Drawing.Point arrow_down = new System.Drawing.Point((int)(XHalf - X8th), (int)(YHalf + YQuarter));
            System.Drawing.Point arrow_left = new System.Drawing.Point(0, (int)(YHalf - Y8th));
            System.Drawing.Point arrow_right = new System.Drawing.Point((int)(XHalf + XQuarter), (int)(YHalf - Y8th));


            m_Rectangle = new BlockRectangle(rectangle_TL, rectangle_Size, colorFill, colorLine);
            m_Arrows = new Dictionary<BlockArrow.EOrientation, BlockArrow>(Utilities.EnumCount(typeof(BlockArrow.EOrientation)));
            m_Arrows.Add(BlockArrow.EOrientation.Up, new BlockArrow(arrow_up, arrowSize, colorFill, colorLine));
            m_Arrows.Add(BlockArrow.EOrientation.Down, new BlockArrow(arrow_down, arrowSize, colorFill, colorLine));
            m_Arrows.Add(BlockArrow.EOrientation.Left, new BlockArrow(arrow_left, arrowSize, colorFill, colorLine));
            m_Arrows.Add(BlockArrow.EOrientation.Right, new BlockArrow(arrow_right, arrowSize, colorFill, colorLine));
        }

        public override void Draw(Canvas canvas)
        {
            m_Rectangle.Draw(canvas);
            foreach (var item in m_Arrows.Values)
            {
                item.Draw(canvas);
            }
        }

        public override bool IsMouseOver(System.Drawing.Point point)
        {
            if (m_Rectangle.IsMouseOver(point))
            {
                return true;
            }
            foreach (var item in m_Arrows.Values)
            {
                if (item.IsMouseOver(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
