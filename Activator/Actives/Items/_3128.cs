#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3128 : Item
    {
        internal override int Id
        {
            get { return 3128; }
        }

        internal override string Name
        {
            get { return "Deathfire Grasp"; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get { return new List<Utility.Map.MapType> { Utility.Map.MapType.SummonersRift }; }
        }

        internal override float Range
        {
            get { return 750f; }
        }

        internal override ScalingType Scaling
        {
            get { return ScalingType.Ap; }
        }

        internal override ItemType Type
        {
            get { return ItemType.Offensive; }
        }

        internal override void Use()
        {
            var target = TargetSelector.GetTarget(Range, TargetSelector.DamageType.Magical);

            //TODO: Add logic to this :<
            if (target.IsValidTarget(Range))
            {
                Cast(target);
            }
        }
    }
}