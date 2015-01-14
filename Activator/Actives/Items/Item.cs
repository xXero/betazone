#region

using System.Collections.Generic;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator.Actives.Items
{
    internal class Item
    {
        internal virtual int Id { get; set; }
        internal virtual string Name { get; set; }
        internal virtual List<Utility.Map.MapType> Maps { get; set; }
        internal virtual float Range { get; set; }
        internal virtual ScalingType Scaling { get; set; }
        internal virtual PredictionInput SpellData { get; set; }
        internal virtual ItemType Type { get; set; }

        internal bool IsActive
        {
            get { return LeagueSharp.Common.Items.CanUseItem(Id) && MenuItem.GetValue<bool>(); }
        }

        internal MenuItem MenuItem { get; private set; }

        internal Item CreateMenuItem(Menu parent) //will add a delegate later that allows to extend the menu if needed
        {
            MenuItem =
                parent.SubMenu(Type == ItemType.Defensive ? "Defensive" : "Offensive")
                    .SubMenu(Scaling == ScalingType.Ad ? "AD" : "AP")
                    .SubMenu(Name)
                    .AddItem(new MenuItem("Enabled", "Enabled").SetValue(true));

            return this;
        }

        internal void Cast(Obj_AI_Hero target = null, bool skillshot = false)
        {
            if (target.IsValidTarget() && skillshot)
            {
                var prediction =
                    Prediction.GetPrediction(
                        new PredictionInput
                        {
                            Aoe = SpellData.Aoe,
                            Collision = SpellData.Collision,
                            Delay = SpellData.Delay,
                            Radius = SpellData.Radius,
                            Range = SpellData.Range,
                            Speed = SpellData.Speed,
                            Type = SpellData.Type,
                            Unit = target
                        });

                LeagueSharp.Common.Items.UseItem(Id, prediction.CastPosition);
            }
            else
            {
                LeagueSharp.Common.Items.UseItem(Id, target ?? Activator.Player);
            }
        }

        internal virtual void Use() {}

        internal enum ItemType
        {
            Defensive,
            Offensive
        }

        internal enum ScalingType
        {
            Ad,
            Ap
        }
    }
}