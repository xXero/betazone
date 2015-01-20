#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3060 : Item
    {
        internal override int Id
        {
            get { return 3060; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get
            {
                return new List<Utility.Map.MapType>
                {
                    Utility.Map.MapType.HowlingAbyss,
                    Utility.Map.MapType.SummonersRift
                };
            }
        }

        internal override string Name
        {
            get { return "Banner of Command"; }
        }

        internal override float Range
        {
            get { return 700f; }
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
            var nearbyTarget = TargetSelector.GetTarget(Range, TargetSelector.DamageType.True);

            if (!nearbyTarget.IsValidTarget())
            {
                return;
            }

            var bestMinion =
                MinionManager.GetMinions(Range, MinionTypes.All, MinionTeam.Ally)
                    .MaxOrDefault(minion => !minion.BaseSkinName.ToLower().Contains("super"));

            if (bestMinion != null)
            {
                Cast(bestMinion);
            }
        }
    }
}