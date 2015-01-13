#region

using System;
using LeagueSharp.Common;

#endregion

namespace Activator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Activator.Load();
        }
    }
}