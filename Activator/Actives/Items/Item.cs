#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class Item
    {
        internal virtual int Id { get; set; }
        internal virtual string Name { get; set; }
        internal virtual List<Utility.Map.MapType> Maps { get; set; }
        internal virtual float Range { get; set; }
        internal virtual ItemType Type { get; set; }

        internal bool IsActive
        {
            get { return LeagueSharp.Common.Items.CanUseItem(Id) && MenuItem.GetValue<bool>(); }
        }

        internal MenuItem MenuItem { get; private set; }

        internal Item CreateMenuItem(Menu parent) //Will add custom menus for items if needed later
        {
            MenuItem =
                parent.SubMenu(Type == ItemType.Offensive ? "Offensive" : "Defensive")
                    .AddItem(new MenuItem(Name, "Use " + Name).SetValue(true));
            return this;
        }

        internal virtual void Use() {}

        internal enum ItemType
        {
            Defensive,
            Offensive
        }
    }
}