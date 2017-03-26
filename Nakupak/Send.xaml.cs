using System;
using System.Collections.Generic;
using Plugin.Messaging;

using Xamarin.Forms;

namespace Nakupak
{
	public partial class Send : ContentPage
	{
		public Send(string Content)
		{
			InitializeComponent();
			content.Text = Content;
		}

		public void send(object sender, EventArgs args)
		{


			var smsMessenger = MessagingPlugin.SmsMessenger;
			if (smsMessenger.CanSendSms)
				smsMessenger.SendSms("+420"+phone.Text, content.Text);

			Navigation.PopAsync();
		}
	}
}
