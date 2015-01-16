#region

using System.Linq;
using LeagueSharp;

#endregion

namespace Activator.Actives.Events
{
    internal class Stealth
    {
        public delegate void OnStealthDelegate(Obj_AI_Hero unit);

        //TODO: Add remaining spells to this when L# updates
        public static string[] StealthSpells = {"khazixR"};

        static Stealth()
        {
            Obj_AI_Base.OnProcessSpellCast += ObjAiBaseOnOnProcessSpellCast;
        }

        public static event OnStealthDelegate OnStealth;

        private static void ObjAiBaseOnOnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            // Make sure sender is an enemy
            if (!sender.IsEnemy)
            {
                return;
            }

            // Check is spell is listed in the array above
            if (!StealthSpells.Any(x => x.Equals(args.SData.Name)))
            {
                return;
            }

            // Fire the event
            if (OnStealth != null)
            {
                OnStealth(sender as Obj_AI_Hero);
            }
        }
    }
}