using System;
using Xamarin.Forms;
using System.Diagnostics;
using Acr.UserDialogs;

namespace FormsSample
{
public class NumericValidationTriggerAction : TriggerAction<Entry>
	{
		protected override void Invoke(Entry entry)
		{
			double result;
			bool isValid = Double.TryParse(entry.Text, out result);
			entry.TextColor = isValid ? Color.Default : Color.Red;

			if (!isValid)
			{
				UserDialogs.Instance.Alert("Item Cost must be numeric", "Invalid Entry");

			}	
		}


	}
}
