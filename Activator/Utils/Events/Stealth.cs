#region

using System.Linq;
using LeagueSharp;

#endregion

namespace Activator.Utils.Events
{
    internal class Stealth
    {
        public delegate void OnStealthDelegate(Obj_AI_Hero unit);

        public static string[] StealthSpells = { "khazixR" };

        static Stealth()
        {
            Obj_AI_Base.OnProcessSpellCast += ObjAiBaseOnOnProcessSpellCast;
        }

        public static event OnStealthDelegate OnStealth;

        private static void ObjAiBaseOnOnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsEnemy)
            {
                return;
            }

            if (!StealthSpells.Any(x => x.Equals(args.SData.Name)))
            {
                return;
            }

            if (OnStealth != null)
            {
                OnStealth((Obj_AI_Hero) sender);
            }
        }
    }
}