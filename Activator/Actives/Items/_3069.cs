#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3069 : Item
    {
        internal override int Id
        {
            get { return 3069; }
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
            get { return "Talisman of Ascension"; }
        }

        internal override float Range
        {
            get { return 600f; }
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
            SubMenu.AddItem(new MenuItem("minAlliesAround", "Min. allies around").SetValue(new Slider(1, 1, 5)));
        }
        internal override void Use()
        {
            if (Activator.Player.CountEnemiesInRange(Range) >= SubMenu.Item("minAlliesAround").GetValue<Slider>().Value)
            {
                Cast();
            }
        }
    }
}