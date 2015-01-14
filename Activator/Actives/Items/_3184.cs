#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3184 : Item
    {
        internal override int Id
        {
            get { return 3184; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get
            {
                return new List<Utility.Map.MapType>
                {
                    Utility.Map.MapType.CrystalScar,
                    Utility.Map.MapType.HowlingAbyss
                };
            }
        }

        internal override string Name
        {
            get { return "Entropy"; }
        }

        internal override float Range
        {
            get { return Orbwalking.GetRealAutoAttackRange(null) + 65f; }
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

            if (target.IsValidTarget(Range))
            {
                Cast();
            }
        }
    }
}