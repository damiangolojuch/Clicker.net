using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker.net
{
    public partial class Form1 : Form
    {
        private Clicker clicker;
        private WebSocketHandler ws;
        private bool hasBeenSubscibed = false;
        private bool hasBeenConnected = false;

        public Form1()
        {
            InitializeComponent();
            clicker = new Clicker();
            ws = new WebSocketHandler();
        }

        private void handleMouseEvent(MouseEventExtArgs e)
        {
            label1.Text = "Ostatnio kliknięty myszek: " +e.Button.ToString() + " - timestamp: " + e.Timestamp;
            ws.Send("{\"event\":\"mouseClick\", \"details\": {\"button\": \"" + e.Button.ToString() + "\", \"timestamp\":\"" + e.Timestamp + "\"}}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hasBeenSubscibed)
            {
                clicker.Unsubscribe();
                button1.Text = "Przechwytuj myszkę";
            } else
            {
                clicker.Subscribe(handleMouseEvent);
                button1.Text = "Zakończ przechwytywanie";               
            }
            
            hasBeenSubscibed = !hasBeenSubscibed;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hasBeenConnected)
            {
                textBox1.Enabled = true;
                button2.Text = "Połącz";
                ws.Disconnect();
                hasBeenConnected = false;
            }
            else
            {
                ws.Connect(textBox1.Text, () =>
                {
                    textBox1.Enabled = false;
                    button2.Text = "Rozłącz";
                    hasBeenConnected = true;
                });
            }
        }
    }
}
