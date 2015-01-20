#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3180 : Item
    {
        internal override int Id
        {
            get { return 3180; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get { return new List<Utility.Map.MapType> { Utility.Map.MapType.CrystalScar }; }
        }

        internal override string Name
        {
            get { return "Odyn's Veil"; }
        }

        internal override float Range
        {
            get { return 500f; }
        }

        internal override ScalingType Scaling
        {
            get { return ScalingType.Ap; }
        }

        internal override ItemType Type
        {
            get { return ItemType.Offensive; }
        }

        internal override void Construct()
        {
            SubMenu.AddItem(new MenuItem("minEnemiesAround", "Min. enemies around").SetValue(new Slider(1, 1, 5)));
        }

        internal override void Use()
        {
            if (Activator.Player.CountEnemiesInRange(Range) >= SubMenu.Item("minEnemiesAround").GetValue<Slider>().Value)
            {
                Cast();
            }
        }
    }
}