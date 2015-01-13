#region

using System;
using Activator.Actives;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator
{
    internal static class Activator
    {
        internal static Menu Config;
        internal static Obj_AI_Hero Player;

        internal static void Load()
        {
            try
            {
                //Assign the player object
                Player = ObjectManager.Player;

                //Load the menu
                Config = new Menu("Activator", "Activator", true);

                //Load the item manager
                ItemManager.Load();

                //Will be removed later, gotta change the ts first
                TargetSelector.AddToMenu(Config.SubMenu("Target selector"));

                //Add the menu as main menu
                Config.AddToMainMenu();

                //Print our hello
                Game.PrintChat("Activator# loaded!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}