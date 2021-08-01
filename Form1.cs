using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Alarm
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        int hour, minute, second;
        string alarmHour, alarmMinute;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeNowTimer.Start();

            for (int hrs = 0; hrs < 24; hrs++)
            {
                comboBoxHour.Items.Add(hrs);
            }

            for(int mins = 0; mins<60; mins++)
            {
                comboBoxMinutes.Items.Add(mins);
            }
        }

        private void TimeNowTimer_Tick(object sender, EventArgs e)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            lblHours.Text = hour.ToString();
            lblMinutes.Text = minute.ToString();
            lblSeconds.Text = second.ToString();

            Ring_Alarm();
        }

        private void btnSetAlarm_Click(object sender, EventArgs e)
        {
            alarmHour = comboBoxHour.Text;
            alarmMinute = comboBoxMinutes.Text;

            btnSetAlarm.Hide();
        }

        void Ring_Alarm()
        {
            if(alarmHour==hour.ToString() && alarmMinute==minute.ToString() && second.ToString() == "0")
            {
                player.URL = "Alarm Sound.mp3";
                player.controls.play();
            }
        }
    }
}
