#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3153 : Item
    {
        internal override int Id
        {
            get { return 3153; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get { return new List<Utility.Map.MapType> { Utility.Map.MapType.SummonersRift }; }
        }

        internal override string Name
        {
            get { return "Blade of the Ruined King"; }
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
            get { return ItemType.Offensive; }
        }

        internal override void Use()
        {
            var target = TargetSelector.GetTarget(Range, TargetSelector.DamageType.Physical);

            if (target.IsValidTarget(Range) &&
                Activator.Player.Health + Activator.Player.GetItemDamage(target, Damage.DamageItems.Botrk) <
                Activator.Player.MaxHealth)
            {
                UseItem(target);
            }
        }
    }
}