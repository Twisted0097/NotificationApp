using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationApp
{
	public partial class Form1 : Form
	{
		private NotifyIcon notificationIcon;
		public Form1()
		{
			InitializeComponent();

			notificationIcon = new NotifyIcon();
			notificationIcon.Icon = this.Icon;
			notificationIcon.Visible = true;
			notificationIcon.Text = "My .NET Application";
		}

		private void ShowNotification(string title, string message)
		{
			notificationIcon.BalloonTipTitle = title;
			notificationIcon.BalloonTipText = message;
			notificationIcon.BalloonTipIcon = ToolTipIcon.Info;
			notificationIcon.ShowBalloonTip(5000);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			// Clean up NotifyIcon properly
			if (notificationIcon != null)
			{
				notificationIcon.Visible = false;
				notificationIcon.Dispose();
			}

			base.OnFormClosing(e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ShowNotification(
				"Test Notification",
				"This is a notification from my .NET Framework 4.8.1 application!"
			);
		}
	}
}
