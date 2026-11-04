using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Controls
{

    public static class clsTheme
    {
        public static readonly Color Background = ColorTranslator.FromHtml("#F4F6F8");
        public static readonly Color Sidebar = ColorTranslator.FromHtml("#0B3B3A");
        public static readonly Color SidebarText = ColorTranslator.FromHtml("#E6F2F1");
        public static readonly Color Active = ColorTranslator.FromHtml("#2DD4BF");
        public static readonly Color ActiveText = ColorTranslator.FromHtml("#052E2C");
        public static readonly Color Primary = ColorTranslator.FromHtml("#0F766E");
        public static readonly Color Card = Color.White;
        public static readonly Color Border = ColorTranslator.FromHtml("#E2E8F0");
        public static readonly Color Text = ColorTranslator.FromHtml("#1B2430");
        public static readonly Color TextMuted = ColorTranslator.FromHtml("#475569");
        public static readonly Color SuccessBg = ColorTranslator.FromHtml("#DCFCE7");
        public static readonly Color SuccessText = ColorTranslator.FromHtml("#166534");
        public static readonly Color WarningBg = ColorTranslator.FromHtml("#FEF3C7");
        public static readonly Color WarningText = ColorTranslator.FromHtml("#92400E");
        public static readonly Color DangerBg = ColorTranslator.FromHtml("#FEE2E2");
        public static readonly Color DangerText = ColorTranslator.FromHtml("#991B1B");

        public static readonly Font Body = new Font("Cairo", 10.5f);
        public static readonly Font Title = new Font("Cairo", 18f, FontStyle.Bold);
        public static readonly Font BigNum = new Font("Cairo", 21f, FontStyle.Bold);
    }
}
