using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Mliybs解释器
        /// </summary>
        public class MliybsInterpreter
        {
            /// <summary>
            /// Mliybs解释器信息
            /// </summary>
            public static string Info { get; } = "MliybsInterpreter 1.0.0:\n";

            /// <summary>
            /// 通用变量声明池
            /// </summary>
            public static Dictionary<(string, Type), object> Variables { get; private set; }

            /// <summary>
            /// 启动Mliybs解释器
            /// </summary>
            public void Launch()
            {
                Console.Title = "Mliybs Interpreter";

                Console.CursorVisible = true;

                Console.WriteLine(Info);

                var input = Console.ReadLine().Split(" ");

                while (input[0] != "exit")
                {
                    switch (input)
                    {
                        case ["bool", _, "=", _]:

                            break;

                        case ["byte", _, "=", _]:

                            break;

                        case ["char", _, "=", _]:

                            break;

                        case ["decimal", _, "=", _]:

                            break;

                        case ["float", _, "=", _]:

                            break;

                        case ["int", _, "=", _]:

                            break;

                        case ["long", _, "=", _]:

                            break;

                        case ["object", _, "=", _]:

                            break;

                        case ["sbyte", _, "=", _]:

                            break;

                        case ["short", _, "=", _]:

                            break;

                        case ["string", _, "=", _]:

                            break;

                        case ["uint", _, "=", _]:

                            break;

                        case ["ulong", _, "=", _]:

                            break;

                        case ["ushort", _, "=", _]:

                            break;

                        default:

                            Console.WriteLine("语法错误！");

                            break;
                    }

                    input = Console.ReadLine().Split(" ");
                }
            }

            public static dynamic VariableNewer(Type type)
            {
                var method = typeof(Activator).GetMethod("CreateInstance", new Type[] { });

                var info = method.MakeGenericMethod(type);

                return info.Invoke(null, null);
            }
        }
    }
}
