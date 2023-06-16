using System;
using System.Reflection;

namespace Mliybs
{
    namespace MliybsLibrary
    {
        /// <summary>
        /// Mliybs相关特性
        /// </summary>
        public class MliybsAttribute : Attribute
        {
            /// <summary>
            /// <para>传入特性数据</para>
            /// <para>采用或运算符 "|" 添加多个特性数据</para>
            /// </summary>
            /// <param name="info"></param>
            public MliybsAttribute(MliybsInfo info = MliybsInfo.Default) => Info = info;

            /// <summary>
            /// 特性数据
            /// </summary>
            public MliybsInfo Info { get; set; }
        }

        /// <summary>
        /// 特性数据枚举
        /// </summary>
        public enum MliybsInfo
        {
            /// <summary>
            /// 不包含任何信息
            /// </summary>
            Default = 0b1,

            /// <summary>
            /// 该元素不再被使用
            /// </summary>
            NotOnUse = 0b10,

            /// <summary>
            /// 该元素不完善或有缺陷需要改进
            /// </summary>
            ImproveNeeded = 0b100
        }

        /// <summary>
        /// Mliybs依赖库静态类
        /// </summary>
        public static class MliybsLibraryStatic
        {
            /// <summary>
            /// 获取MliybsInfo数据 可能为空
            /// </summary>
            /// <param name="self"></param>
            /// <returns></returns>
            public static MliybsInfo? GetMliybsInfo(this MemberInfo self) => self.GetCustomAttribute<MliybsAttribute>()?.Info;

            /// <summary>
            /// <para>获取MliybsInfo数据</para>
            /// <para>返回表示是否成功的布尔值</para>
            /// <para>获取内容通过out参数传出</para>
            /// </summary>
            /// <param name="self"></param>
            /// <param name="info"></param>
            /// <returns></returns>
            public static bool TryGetMliybsInfo(this MemberInfo self, out MliybsInfo? info)
            {
                var attr = self.GetCustomAttribute<MliybsAttribute>();

                if (attr is null)
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

            /// <summary>
            /// 返回是否存在MliybsInfo
            /// </summary>
            /// <param name="self"></param>
            /// <returns></returns>
            public static bool IsMliybsInfoExisting(this MemberInfo self)
            {
                if (self.GetCustomAttribute<MliybsAttribute>() is null)
                    return false;

                else
                    return true;
            }
        }
    }
}
