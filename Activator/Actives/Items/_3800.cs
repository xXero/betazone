#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3800 : Item
    {
        internal override int Id
        {
            get { return 3800; }
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
            get { return "Righteous Glory"; }
        }

        internal override float Range
        {
            //TODO Check this.
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
            var MaxUnits = 3000f*(Activator.Player.MoveSpeed*1.6f);
            var target = TargetSelector.GetTarget(MaxUnits, TargetSelector.DamageType.True);
            if (target.IsValidTarget() && Activator.Player.CountEnemiesInRange(Range) >= SubMenu.Item("minAlliesAround").GetValue<Slider>().Value)
            {
                Cast();
            }
        }
    }
}