using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ.Commands;

namespace Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reciever();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void reciever()
        {
            IConnectionFactory factory = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection connect = factory.CreateConnection();
            connect.Start();
            ISession session = connect.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination destination = SessionUtil.GetDestination(session,"Tan ne1");
            IMessageConsumer reciever = session.CreateConsumer(destination);
            reciever.Listener += new MessageListener(Message_Listener);
        }
        private void Message_Listener(IMessage mess)
        {
            if(mess is ActiveMQTextMessage)
            {
                ActiveMQTextMessage msg = mess as ActiveMQTextMessage;
                MessageBox.Show(msg.Text);
            }          
        }
    }
}
