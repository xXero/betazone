#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class _3140 : Item
    {
        private readonly BuffType[] buffs = { BuffType.Blind, BuffType.Charm, BuffType.CombatDehancer, BuffType.Fear, BuffType.Flee, BuffType.Knockback, BuffType.Knockup, BuffType.Polymorph, BuffType.Silence, BuffType.Sleep, BuffType.Snare, BuffType.Stun, BuffType.Suppression, BuffType.Taunt };
        internal override int Id
        {
            get { return 3140; }
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
            get { return "Mercurial Scimitar"; }
        }

        internal override float Range
        {
            get { return 0f; }
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
            SubMenu.AddItem(new MenuItem("minBuffs", "Min. buffs to cleanse").SetValue(new Slider(2, 1, 5)));

            for (int i = 0; i < buffs.Count(); i++)
            {
                SubMenu.AddItem(new MenuItem(buffs[i].ToString(), buffs[i].ToString()).SetValue(true));
            }
        }

        internal override void Use()
        {
            var buffNumbers = buffs.Count(Buff => Activator.Player.HasBuffOfType(Buff) && SubMenu.Item(Buff.ToString()).GetValue<bool>());

            if (buffNumbers >= SubMenu.Item("minBuffs").GetValue<Slider>().Value)
            {
                Cast();
            }
        }
    }
}