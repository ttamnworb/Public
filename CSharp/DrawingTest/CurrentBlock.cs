using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTest
{
    internal class CurrentBlock
    {
        private Block m_DefautlBlock = new Block();
        private Block m_Block = new Block();
        private System.Windows.Point m_Offset = new System.Windows.Point();
        private bool m_bValid = false;

        public Block block { get { return m_Block; } set { } }
        public bool isValid { get { return m_bValid; } set { } }
        public System.Windows.Point offset { get { return m_Offset; } set { m_Offset = value; } }

        public void SetBlock(Block block, System.Windows.Point mousePosition)
        {
            m_Block = block;
            m_bValid = true;
            m_Offset = new System.Windows.Point(mousePosition.X - block.X, mousePosition.Y - block.Y);
        }
        public void UnsetBlock()
        {
            m_Block = m_DefautlBlock;
            m_bValid = false;
        }

        /// <summary>
        /// Take the mouse position and return a point adjusted by the stored offset.
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public System.Windows.Point OffsetPosition (System.Windows.Point mousePosition)
        {
            return new System.Windows.Point((mousePosition.X - offset.X), (mousePosition.Y - offset.Y));
        }

    };
}
