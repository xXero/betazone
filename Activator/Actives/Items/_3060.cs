#region

using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
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
            // find a target that is nearby
            var nearbyTarget = TargetSelector.GetTarget(Range, TargetSelector.DamageType.True);
            if (!nearbyTarget.IsValidTarget())
            {
                return;
            }

            // try to find a siege minion
            var bestMinion =
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(x => x.Distance(Activator.Player) < Range)
                    .Where(x => x.IsAlly)
                    .FirstOrDefault(
                        x => x.BaseSkinName == "SRU_OrderMinionSiege" || x.BaseSkinName == "SRU_ChaosMinionSiege");

            if (bestMinion != null)
            {
                LeagueSharp.Common.Items.UseItem(Id, bestMinion);
                return;
            }

            // didn't find siege minion, find minion with most health that isn't a super minion
            var nextMinion =
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(x => x.Distance(Activator.Player) < Range)
                    .Where(x => x.IsAlly)
                    .Where(x => x.BaseSkinName != "SRU_OrderMinionSuper" && x.BaseSkinName != "SRU_ChaosMinionSuper")
                    .OrderBy(x => x.Health)
                    .FirstOrDefault();

            if (nextMinion != null)
            {
                LeagueSharp.Common.Items.UseItem(Id, nextMinion);
            }
        }
    }
}