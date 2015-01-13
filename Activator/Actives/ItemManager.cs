#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Activator.Actives.Items;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives
{
    internal static class ItemManager
    {
        private static readonly List<Item> Items = new List<Item>();

        static ItemManager()
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
        }

        private static Menu ItemsSubMenu
        {
            get { return Activator.Config.SubMenu("Items"); }
        }

        internal static void Load()
        {
            const string @namespace = "Activator.Actives.Items";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Name != "Item" && t.Namespace == @namespace
                select t;

            q.ToList().ForEach(t => LoadItem((Item) System.Activator.CreateInstance(t)));
        }

        private static void Game_OnGameUpdate(EventArgs args)
        {
            //Add a keydown check here maybe
            Items.Where(item => item.IsActive).ToList().ForEach(item => item.Use());
        }

        private static void LoadItem(Item item) //will move the mapcheck to the reflection later
        {
            if (!item.Maps.Contains(Utility.Map.GetMap().Type))
            {
                return;
            }

            Items.Add(item.CreateMenuItem(ItemsSubMenu));
        }
    }
}