using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microwave
{
    public class ThreadSafe
    {
        public delegate void SetControlTextCallback_uc(UserControl uc, Control c, string s);
        public static void SetControlTextThreadSafe_uc(UserControl uc, Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new SetControlTextCallback_uc(SetControlTextThreadSafe_uc);
                uc.Invoke(d, new object[] { uc, c, s });
            }
            else
            {
                c.Text = s;
            }
        }

        public delegate void AppendControlTextCallback_uc(UserControl uc, Control c, string s);
        public static void AppendControlTextThreadSafe_uc(UserControl uc, Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new AppendControlTextCallback_uc(AppendControlTextThreadSafe_uc);
                uc.Invoke(d, new object[] { uc, c, s });
            }
            else
            {
                c.Text += s;
            }
        }

        public delegate void AddRemoveListboxControl(UserControl uc, ListBox lb, string s, bool addNOTREMOVE);
        public static void AddRemoveListboxThreadSafe_uc(UserControl uc, ListBox lb, string s, bool addNOTREMOVE)
        {
            if (lb.InvokeRequired)
            {
                var d = new AddRemoveListboxControl(AddRemoveListboxThreadSafe_uc);
                uc.Invoke(d, new object[] { uc, lb, s, addNOTREMOVE });
            }
            else
            {
                if (addNOTREMOVE)
                {
                    lb.Items.Add(s);
                }
                else
                {
                    lb.Items.Remove(s);
                }
            }
        }

        public delegate void ListAddRemoveListboxControl(UserControl uc, ListBox lb, List<string> s);
        public static void ListAddRemoveListboxThreadSafe_uc(UserControl uc, ListBox lb, List<string> s)
        {
            if (lb.InvokeRequired)
            {
                var d = new ListAddRemoveListboxControl(ListAddRemoveListboxThreadSafe_uc);
                uc.Invoke(d, new object[] { uc, lb, s });
            }
            else
            {
                foreach (string sx in s)
                {
                    lb.Items.Add(sx);
                }
            }
        }
            
        public delegate void SetControlTextCallback_f(Form f, Control c, string s);
        public static void SetControlTextThreadSafe_f(Form f, Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new SetControlTextCallback_f(SetControlTextThreadSafe_f);
                f.Invoke(d, new object[] { f, c, s });
            }
            else
            {
                c.Text = s;
            }
        }

        public delegate void AppendControlTextCallback_f(Form f, Control c, string s);
        public static void AppendControlTextThreadSafe_f(Form f, Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new AppendControlTextCallback_f(AppendControlTextThreadSafe_f);
                f.Invoke(d, new object[] { f, c, s });
            }
            else
            {
                c.Text += s;
            }
        }

    }
}
