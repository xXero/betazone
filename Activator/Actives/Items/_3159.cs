#region

using System.Collections.Generic;
using Activator.Utils.Events;
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
            get { return 800f; }
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
            Stealth.OnStealth += sender => Cast(sender.ServerPosition);
        }
    }
}