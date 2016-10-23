using System;
using Xamarin.Forms;
using System.Diagnostics;
using Acr.UserDialogs;

namespace FormsSample
{
	public class StringValidationTriggerAction : TriggerAction<Entry>
	{
		protected override void Invoke(Entry entry)
		{
			
			bool isEmpty = String.IsNullOrWhiteSpace(entry.Text);
            entry.BackgroundColor = !isEmpty ? Color.Default : Color.Red;

			if (isEmpty)
			{
				UserDialogs.Instance.Alert("This field can NOT be empty", "Value Required");
			}
		}


	}
}
