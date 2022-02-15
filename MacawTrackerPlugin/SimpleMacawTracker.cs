using System.Collections.Generic;
using System.Linq;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace MacawTracker

{
    internal class SimpleMacawTracker
	{
		private MacawList _playerList = null;
		private MacawList _opponentList = null;

		public SimpleMacawTracker(MacawList playerList, MacawList opponentList)
		{

			_playerList = playerList;
			_opponentList = opponentList;

			// Hide in menu, if necessary
			if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
            {
				_playerList.Hide();
				_opponentList.Hide();
			}
				
		}

		// Reset on when a new game starts
		internal void GameStart()
		{
			_playerList.Update(new List<Card>());
			_opponentList.Update(new List<Card>());
		}

        internal void OnPlayerPlay(Card card)
        {
			if (!string.IsNullOrEmpty(card.EnglishText) && card.EnglishText.Contains("Battlecry:") && ! card.EnglishText.Contains("Repeat the last Battlecry"))
			{
				_playerList.Update(new List<Card>() { card });
			}
        }

		internal void OnOpponentPlay(Card card)
		{
			if (!string.IsNullOrEmpty(card.EnglishText) && card.EnglishText.Contains("Battlecry:") && !card.EnglishText.Contains("Repeat the last Battlecry"))
			{ 
				_opponentList.Update(new List<Card>() { card });
			}
        }

        // Need to handle hiding the element when in the game menu
        internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_playerList.Hide();
				_opponentList.Hide();
			}
		}

		// Update the card list on player's turn
		internal void TurnStart(ActivePlayer player)
		{

				_playerList.Show();
				_opponentList.Show();
		}
		
	}
}