using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace MacawTracker
{

	public enum Location
    {
		Player,
		Opponent
    }

	public partial class MacawList
	{
		private Location _location;

		public MacawList(Location player = Location.Player)
		{
			_location = player;
		    InitializeComponent();
			//this.PlayerName.Content = _location == Location.Player ? "Macaw Tracker (Player)" : "Macaw Tracker (Opponent)";
		}

		public void Update(List<Card> cards)
		{
			// hide if card list is empty
			this.Visibility = cards.Count <= 0 ? Visibility.Hidden : Visibility.Visible;
			this.ItemsSource = cards;
			UpdatePosition();
		}

		public void UpdatePosition()
		{
			if (_location == Location.Player)
			{
				Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
				Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
			} else
            {
				Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
				Canvas.SetRight(this, Core.OverlayWindow.Width * 70 / 100);
			}
		}

		public void Show()
		{
			this.Visibility = Visibility.Visible;
		}

		public void Hide()
		{
			this.Visibility = Visibility.Hidden;
		}
	}
}