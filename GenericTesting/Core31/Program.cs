using System;

namespace Core31
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "{\"FontFace\":\"Helvetica Neue\",\"PageBackground\":\"#ECF2F7\",\"NavigationBarBackground\":\"#000\",\"MenuTextPrimary\":\"#fff\",\"MenuTextSecondary\":\"#c4dbf0\",\"PrimaryBodyText\":\"#2c3643\",\"SecondaryText\":\"#979ea3\",\"AccentColor\":\"#80b7d8\",\"DarkNeutral\":\"#333\",\"MediumNeutral\":\"#666\",\"LinksDefault\":\"#cc6600\",\"LinksVisited\":\"#9d5d33\",\"LinksUnderline\":\"false\",\"PrimaryActionButton\":\"#297cbb\",\"SecondaryActionButton\":\"#f2f2f2\",\"DisabledActionButton\":\"#dbe6ec\",\"DisabledButtonText\":\"#fff\",\"ButtonCornerRadius\":\"3px\",\"CourseThumbnail\":\"/userfiles/80/themeImages/Default_Course_Logo.png\",\"Logo\":\"/userfiles/80/themeImages/BroanUniversityLogo_Calibri.jpg\",\"Favicon\":\"/userfiles/80/themeImages/favicon-broan.png\",\"HeaderBackground\":\"/userfiles/80/themeImages/Header-Background5 (1).png\",\"pageBackgroundColor\":\"#feffff\",\"navBarBackgroundColor\":\"#004478\",\"primaryTextColor\":\"#3a3c3f\",\"secondaryTextColor\":\"#004478\",\"defaultLinkColor\":\"#728695\",\"visitedLinkColor\":\"#b0643a\",\"menuTextPrimaryColor\":\"#fff\",\"menuTextSecondaryColor\":\"#769dba\",\"PrimaryActionButtonColor\":\"#004478\",\"SecondaryActionButtonColor\":\"#f2f2f2\",\"DisabledButtonColor\":\"#bacbd9\",\"DarkNeutralColor\":\"#838383\",\"MediumNeutralColor\":\"#666\",\"HeaderTextColor\":\"#777777\",\"FooterBackgroundColor\":\"#777777\",\"FooterTextColor\":\"#fff\",\"CardTitleBackgroundColor\":\"#777777\",\"CardTitleTextColor\":\"#ffffff\"}";

            var t = s.GetSubString("CourseThumbnail\":\"", "\",", false, false);

            Console.WriteLine(t);

            Console.ReadLine();
        }
    }
}
