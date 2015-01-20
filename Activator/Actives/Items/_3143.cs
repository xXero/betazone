﻿#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3143 : Item
    {
        internal override int Id
        {
            get { return 3143; }
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
            get { return "Randuin's Omen"; }
        }
        internal override float Range
        {
            get { return 450f; }
        }

        internal override ScalingType Scaling
        {
            get { return ScalingType.Ad; }
        }

        internal override ItemType Type
        {
            get { return ItemType.Defensive; }
        }

        internal override void Construct()
        {
            SubMenu.AddItem(new MenuItem("minEnemiesAround", "Min. enemies around").SetValue(new Slider(2, 1, 5)));
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