#region

using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3159 : Item
    {
        internal override int Id
        {
            get { return 3159; }
        }

        internal override List<Utility.Map.MapType> Maps
        {
            get
            {
                return new List<Utility.Map.MapType>
                {
                    Utility.Map.MapType.CrystalScar,
                    Utility.Map.MapType.TwistedTreeline
                };
            }
        }

        internal override string Name
        {
            get { return "Grez's Spectral Lantern"; }
        }

        internal override float Range
        {
            get { return 800; }
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
            // Get the nearest valid target enemy
            var nearestEnemy = TargetSelector.GetTarget(Range, TargetSelector.DamageType.True);

            if (nearestEnemy == null)
            {
                return;
            }

            // Get best bush nearest to the enemy
            var bestBush =
                ObjectManager.Get<GrassObject>()
                    .Where(x => Activator.Player.Distance(x.Position) < Range)
                    .OrderBy(x => nearestEnemy.Distance(x.Position))
                    .FirstOrDefault();

            if (bestBush != null)
            {
                LeagueSharp.Common.Items.UseItem(Id, bestBush.Position);
            }
        }
    }
}