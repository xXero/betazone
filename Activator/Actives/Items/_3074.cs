#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3074 : Item
    {
        internal override int Id
        {
            get { return 3074; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get
            {
                return new List<Utility.Map.MapType>
                {
                    Utility.Map.MapType.CrystalScar,
                    Utility.Map.MapType.HowlingAbyss,
                    Utility.Map.MapType.SummonersRift,
                    Utility.Map.MapType.TwistedTreeline
                };
            }
        }

        internal override string Name
        {
            get { return "Ravenous Hydra"; }
        }

        internal override float Range
        {
            get { return 385f; }
        }

        internal override ScalingType Scaling
        {
            get { return ScalingType.Ad; }
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