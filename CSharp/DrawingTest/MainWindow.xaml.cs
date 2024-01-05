using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DrawingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrentBlock m_CurrentBlock = new CurrentBlock();

        private List<Block> m_Blocks = new List<Block>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the create button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Color fill = (Color)ColorConverter.ConvertFromString("Red");
            System.Windows.Media.Color line = (Color)ColorConverter.ConvertFromString("Black");

            AddBlockRect(0, 0, 100, 100, fill, line);
            AddBlockRect(150, 0, 100, 100, fill, line);
            AddBlockCircle(300, 0, 100, 100, fill, line);
            AddBlockArrow(150, 200, 50, 50, fill, line, BlockArrow.EOrientation.Right, true);
            AddBlockArrow(150, 300, 50, 50, fill, line, BlockArrow.EOrientation.Left, true);
            AddBlockArrow(250, 200, 50, 50, fill, line, BlockArrow.EOrientation.Up, false);
            AddBlockArrow(250, 300, 50, 50, fill, line, BlockArrow.EOrientation.Down, false);
            AddBlockImage(0, 200, 50, 50, @"Examples\image1.png");
            AddBlockImage(0, 300, 50, 50, @"Examples\image2.png");
            AddBlockRounded(0, 400, 100, 25, fill,line, 20, 10);

            foreach (Block block in m_Blocks)
            {
                block.Draw(background);
            }
        }

        /// <summary>
        /// Add a block to the screen
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        void AddBlockRect(int x, int y, int w, int h, System.Windows.Media.Color fill, System.Windows.Media.Color line)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            m_Blocks.Add(new BlockRectangle(tl, size, fill, line));
        }
        void AddBlockRounded(int x, int y, int w, int h, System.Windows.Media.Color fill, System.Windows.Media.Color line, int radiusX, int radiusY)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            m_Blocks.Add(new BlockRoundedRectangle(tl, size, fill, line, new System.Drawing.Size(radiusX, radiusX)));
        }
        
        void AddBlockCircle(int x, int y, int w, int h, System.Windows.Media.Color fill, System.Windows.Media.Color line)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            BlockCircle circle = new BlockCircle(tl, size, fill, line);
            m_Blocks.Add(circle);
        }
        void AddBlockArrow(int x, int y, int w, int h, System.Windows.Media.Color fill, System.Windows.Media.Color line, BlockArrow.EOrientation orientation, bool isFilled)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            BlockArrow arrow = new BlockArrow(tl, size, fill, line);
            arrow.Orientation = orientation;
            arrow.IsFilled = isFilled;
            m_Blocks.Add(arrow);
        }
        void AddBlockProcess(int x, int y, int w, int h, System.Windows.Media.Color fill, System.Windows.Media.Color line)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            BlockProcess process = new BlockProcess(tl, size, fill, line);
            m_Blocks.Add(process);
        }
        void AddBlockImage(int x, int y, int w, int h, string filename)
        {
            System.Drawing.Point tl = new System.Drawing.Point(x, y);
            System.Drawing.Size size = new System.Drawing.Size(w, h);
            m_Blocks.Add(new BlockImage(tl, size, filename));
        }
        /// <summary>
        /// Mouse click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void background_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.RightButton == MouseButtonState.Pressed)
            {
                Block block = GetBlockUnderMouse();
                if (Utilities.isDerivedFrom(block.GetType(), typeof(Block)))
                {
                    ((Block)block).FillColor = (Color)ColorConverter.ConvertFromString("Blue");
                    block.Draw(background);
                }

            }
            if (e.RightButton == MouseButtonState.Released)
            {
                Block block = GetBlockUnderMouse();
                if (Utilities.isDerivedFrom(block.GetType(), typeof(Block)))
                {
                    ((Block)block).FillColor = (Color)ColorConverter.ConvertFromString("Red");
                    block.Draw(background);
                }
            }
        }

        /// <summary>
        /// Mouse click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void background_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                System.Windows.Point mousePosition = Mouse.GetPosition(background);
                if (!m_CurrentBlock.isValid)
                {
                    m_CurrentBlock.SetBlock(GetBlockUnderPoint(mousePosition), mousePosition);
                }
                m_CurrentBlock.block.Move(m_CurrentBlock.OffsetPosition(mousePosition));
                m_CurrentBlock.block.Draw(background);
            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                if (m_CurrentBlock.isValid)
                {
                    m_CurrentBlock.UnsetBlock();
                }
            }
            {
                System.Windows.Point mousePosition = Mouse.GetPosition(background);
                string xPos = string.Format("{0}", (int)mousePosition.X);
                string yPos = string.Format("{0}", (int)mousePosition.Y);
                mousePosX.Text = xPos;
                mousePosY.Text = yPos;
            }
        }

        /// <summary>
        /// Get the block under the current mouse position.
        /// </summary>
        /// <returns></returns>
        private Block GetBlockUnderMouse()
        {
            return GetBlockUnderPoint(Mouse.GetPosition(background));
        }
        /// <summary>
        /// Get the block under the given position.
        /// </summary>
        /// <returns></returns>
        private Block GetBlockUnderPoint(Point point)
        {
            foreach (Block block in m_Blocks)
            {

                if (block.IsMouseOver(point))
                {
                    return block;
                }
            }
            return new Block();
        }


    }
}
