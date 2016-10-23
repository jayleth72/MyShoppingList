using System;
using AppServiceHelpers.Models;

namespace FormsSample.Models
{
	public class ShopListItem : EntityData
	{
		public string ListItemName { get; set; }
		public bool HaveItem { get; set; }
		public double ItemCost { get; set; }
		public string ItemBrand { get; set; }
		public string LocalPhotoURI { get; set; }
	}
}
     