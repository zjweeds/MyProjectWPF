using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Moders.TableModers
{
    public class TextBoxExtendModel
    {

        private int m_TCID = 1;
        public int TCID
        {
            get { return m_TCID; }
            set { m_TCID = value; }
        }

        private int m_TCCIID = 1;
        public int TCCIID
        {
            get { return m_TCCIID; }
            set { m_TCCIID = value; }
        }

        private bool m_TCIsFlage = false;
        public bool TCIsFlage
        {
            get { return m_TCIsFlage; }
            set { m_TCIsFlage = value; }
        }

        private int m_TCShowType =0;
        public int TCShowType
        {
            get { return m_TCShowType; }
            set { m_TCShowType = value; }
        }
        private int m_TCMarkType = 0;
        public int TCMarkType
        {
            get { return m_TCMarkType; }
            set { m_TCMarkType = value; }
        }

        /// <summary>
        /// 是否被更新标记
        /// </summary>
        private bool m_updateFlage = false;
        public bool updateFlage
        {
            get { return m_updateFlage; }
            set { m_updateFlage = value; }
        }
    }
}
