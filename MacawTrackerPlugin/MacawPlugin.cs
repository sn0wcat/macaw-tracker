using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace MacawTracker
{
	public class MacawPlugin : IPlugin
	{
		private MacawList _playerList;
		private MacawList _opponentList;

		public string Author
		{
			get { return "sn0wcat"; }
		}

		public string ButtonText
		{
			get { return "Settings"; }
		}

		public string Description
		{
			get { return "Macaw Tracker Plugin (Tracks last card which was played with BattleCry"; }
		}

		public MenuItem MenuItem
		{
			get { return null; }
		}

		public string Name
		{
			get { return "MacawTracker"; }
		}

		public void OnButtonPress()
		{
		}

		public void OnLoad()
		{
			_playerList = new MacawList(Location.Player);
			_opponentList = new MacawList(Location.Opponent);
			
			Core.OverlayCanvas.Children.Add(_playerList);
			Core.OverlayCanvas.Children.Add(_opponentList);

			SimpleMacawTracker curvy = new SimpleMacawTracker(_playerList, _opponentList);


			GameEvents.OnGameStart.Add(curvy.GameStart);
			GameEvents.OnInMenu.Add(curvy.InMenu);
			GameEvents.OnTurnStart.Add(curvy.TurnStart);
			GameEvents.OnPlayerPlay.Add(curvy.OnPlayerPlay);
            GameEvents.OnOpponentPlay.Add(curvy.OnOpponentPlay);


		}

		public void OnUnload()
		{
			Core.OverlayCanvas.Children.Remove(_playerList);
			Core.OverlayCanvas.Children.Remove(_opponentList);
		}

		public void OnUpdate()
		{
		}

		public Version Version
		{
			get { return new Version(1,0,0); }
		}
	}
}