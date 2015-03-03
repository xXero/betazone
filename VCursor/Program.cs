using LeagueSharp.Common;

namespace VCursor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        static void Game_OnGameLoad(System.EventArgs args)
        {
            VirtualCursor.Draw();
        }
    }
}