using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_project.Class
{
    class ChatLog
    {
        string chat;

        Form1 m_form;
        public Form1 M_form
        {
            get { return m_form; }
        }

        public ChatLog(Form1 form)
        {
            m_form = form;
        }
        void Add_chat(string txt)
        {
            m_form.lbxView.Items.Add(txt);
        }
    }
}
