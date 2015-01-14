#region

using System.Collections.Generic;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3092 : Item
    {
        internal override int Id
        {
            get { return 3092; }
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
            get { return "Frost Queen's Claim"; }
        }

        internal override PredictionInput SpellData

        {
            get
            {
                return new PredictionInput
                {
                    Aoe = true,
                    Collision = false,
                    Delay = 0.25f,
                    Radius = 275f,
                    Range = 600f,
                    Speed = 1600f,
                    Type = SkillshotType.SkillshotCircle
                };
            }
        }

        internal override float Range
        {
            get { return 850f; }
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

            if (target.IsValidTarget(Range))
            {
                Cast(target, true);
            }
        }
    }
}