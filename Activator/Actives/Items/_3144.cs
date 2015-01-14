#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3144 : Item
    {
        internal override int Id
        {
            get { return 3144; }
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
            get { return "Bilgewater Cutlass"; }
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

            if (target.IsValidTarget(Range))
            {
                Cast(target);
            }
        }
    }
}