using System;
using System.Reflection;

namespace MliybsLibrary
{
    public class MliybsAttribute : Attribute
    {
        public MliybsAttribute(MliybsInfo info) => Info = info;

        public MliybsInfo Info { get; set; }
    }

    public enum MliybsInfo
    {
        OnUse = 0b1
    }

    public static class MliybsLibraryStatic
    {
        public static MliybsInfo? GetMliybsInfo(this object self) => self.GetType().GetCustomAttribute<MliybsAttribute>()!.Info;

        public static bool TryGetMliybsInfo(this object self, out MliybsInfo? info)
        {
            var attr = self.GetType().GetCustomAttribute<MliybsAttribute>();

            if (attr == null)
            {
                info = null;

                return false;
            }

            else
            {
                info = attr.Info;

                return true;
            }
        }

        public static bool IsMliybsInfoExisting(this object self)
        {
            if (self.GetType().GetCustomAttribute<MliybsAttribute>() == null)
                return false;

            else
                return true;
        }
    }
}
