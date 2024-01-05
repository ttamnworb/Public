using System.Drawing;
using System.Windows.Controls;

namespace DrawingTest
{
    using Colour = System.Windows.Media.Color;

    /// <summary>
    /// Base class of all blocks displayed.
    /// </summary>
    internal class Block
    {
        public const int InvalidIndex = -1;

        private System.Drawing.Point m_Position = new System.Drawing.Point();
        private System.Drawing.Size m_Size = new System.Drawing.Size();
        private Colour m_ColorFill = new Colour();
        private Colour m_ColorLine = new Colour();
        private int m_Index = Block.InvalidIndex;
        private bool m_IsFilled = true;

        public Point Position { get { return m_Position; } set { m_Position = value; } }
        public Size Size { get { return m_Size; } set { m_Size = value; } }
        public int X { get { return m_Position.X; } set { m_Position.X = value; } }
        public int Y { get { return m_Position.Y; } set { m_Position.Y = value; } }
        public int Width { get { return m_Size.Width; } set { m_Size.Width = value; } }
        public int Height { get { return m_Size.Height; } set { m_Size.Height = value; } }
        public Colour FillColor { get { return m_ColorFill; } set { m_ColorFill = value; } }
        public Colour LineColor { get { return m_ColorLine; } set { m_ColorLine = value; } }
        protected int Index { get { return m_Index; } set { m_Index = value; } }
        public bool IsFilled { get { return m_IsFilled; } set { m_IsFilled = value; } }



        public Block(Point position = new Point(), Size size = new Size(), Colour colorFill = new Colour(), Colour colorLine = new Colour())
        {
            Position = position;
            Size = size;
            FillColor = colorFill;
            LineColor = colorLine;
            Index = -1;
        }

        /// <summary>
        /// Is the given point over this block
        /// </summary>
        /// <param name="point">The point to test</param>
        /// <returns>true if it is, false otherwise</returns>
        public virtual bool IsMouseOver(System.Drawing.Point point)
        {
            System.Drawing.Rectangle area = new System.Drawing.Rectangle(Position, Size);
            return area.Contains(point);
        }
        public virtual bool IsMouseOver(System.Windows.Point point)
        {
            return this.IsMouseOver(new System.Drawing.Point((int)point.X, (int)point.Y));
        }

        /// <summary>
        /// Relocate the object from the current point to the given new point
        /// </summary>
        /// <param name="point">new top left for the block</param>
        public virtual void Move(Point point)
        {
            Position = point;
        }
        public virtual void Move(System.Windows.Point point)
        { this.Move(new System.Drawing.Point((int)point.X, (int)point.Y)); }

        /// <summary>
        /// Draw the block on the given canvas at the current highest level
        /// </summary>
        /// <param name="canvas">The control to draw on</param>
        public virtual void Draw(Canvas canvas)
        { }


    }
}
