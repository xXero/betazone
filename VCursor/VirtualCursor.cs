using System;
using System.Drawing;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using VCursor.Properties;

namespace VCursor
{
    static class VirtualCursor
    {
        public enum CursorIcon
        {
            Default,
            HoverEnemy,
            HoverFriendly,
            HoverShop,
            HoverUse,
            SingleTarget,
            SingleTargetAlly,
            SingleTargetEnemy,
            SingleTargetEnemyCannotAttack,
            DefaultColorblind,
            HoverEnemyColorblind,
            HoverUseColorblind,
            SingleTargetColorblind,
            SingleTargetEnemyColorblind,
            SingleTargetEnemyCannotAttackColorblind
        }

        private static readonly Render.Sprite CursorSprite;
        public static bool FollowCursor = true;
        private static CursorIcon _icon;

        static VirtualCursor()
        {

                CursorSprite = new Render.Sprite(Resources.Hand1, Vector2.Zero)
                {
                    PositionUpdate = () => FollowCursor ? Drawing.WorldToScreen(Game.CursorPos).GetRelativePosition() : Vector2.Zero
                };
            _icon = CursorIcon.Default;
            

            AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Game.OnGameUpdate += Game_OnGameUpdate;
        }

        private static void Game_OnGameUpdate(EventArgs args)
        {
            var shop = ObjectHandler.Get<Obj_Shop>().FirstOrDefault(o => o.Position.Distance(Game.CursorPos) < 300);
            if(shop != null)// && !MenuGUI.IsShopOpen)
            {
                SetIcon(CursorIcon.HoverShop);
                Console.WriteLine("SHOP");
                return;
            }
            SetIcon(CursorIcon.Default);
            Utils.ClearConsole();
        }

        private static Vector2 GetRelativePosition(this Vector2 vector)
        {
            Vector2 offset = new Vector2();

            if (_icon.Equals(CursorIcon.Default) || _icon.Equals(CursorIcon.DefaultColorblind))
            {
                offset = new Vector2(-8, -8);
            }
            else if(_icon.Equals(CursorIcon.HoverShop))
            {
                offset = new Vector2(-20, -15);
            }

            return vector + offset;
        }

        public static void SetIcon(CursorIcon icon)
        {
            Bitmap data;

            switch (icon)
            {
                case CursorIcon.Default:
                    data = Resources.Hand1;
                    break;
                case CursorIcon.DefaultColorblind:
                    data = Resources.Hand2;
                    break;
                case CursorIcon.HoverEnemy:
                    data = Resources.HoverEnemy;
                    break;
                case CursorIcon.HoverEnemyColorblind:
                    data = Resources.HoverEnemy_Colorblind;
                    break;
                case CursorIcon.HoverFriendly:
                    data = Resources.HoverFriendly;
                    break;
                case CursorIcon.HoverShop:
                    data = Resources.HoverShop;
                    break;
                case CursorIcon.HoverUse:
                    data = Resources.HoverUse;
                    break;
                case CursorIcon.HoverUseColorblind:
                    data = Resources.HoverUse_Colorblind;
                    break;
                case CursorIcon.SingleTarget:
                    data = Resources.SingleTarget;
                    break;
                case CursorIcon.SingleTargetAlly:
                    data = Resources.SingleTargetAlly;
                    break;
                case CursorIcon.SingleTargetColorblind:
                    data = Resources.SingleTarget_Colorblind;
                    break;
                case CursorIcon.SingleTargetEnemy:
                    data = Resources.SingleTargetEnemy;
                    break;
                case CursorIcon.SingleTargetEnemyCannotAttack:
                    data = Resources.SingleTargetEnemyCannoyAttack;
                    break;
                case CursorIcon.SingleTargetEnemyCannotAttackColorblind:
                    data = Resources.SingleTargetEnemyCannoyAttack_Colorblind;
                    break;
                case CursorIcon.SingleTargetEnemyColorblind:
                    data = Resources.SingleTargetEnemy_Colorblind;
                    break;
                default:
                    data = Resources.Hand1;
                    break;
            }

            _icon = icon;
            CursorSprite.UpdateTextureBitmap(data, CursorSprite.Position);
        }

        public static void SetPosition(Vector2 position = new Vector2())
        {
            if (position == Vector2.Zero)
            {
                position = Drawing.WorldToScreen(Game.CursorPos);
            }

            CursorSprite.Position = position;
        }

        public static void Draw()
        {
            CursorSprite.Add();
        }

        public static void Hide()
        {
            CursorSprite.Hide();
        }

        public static void Show()
        {
            CursorSprite.Show();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CursorSprite.Dispose();
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            CursorSprite.Dispose();
        }

        private static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            CursorSprite.Dispose();
        }
    }
}