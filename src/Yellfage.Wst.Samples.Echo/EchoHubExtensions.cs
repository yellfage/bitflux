using System;

namespace Yellfage.Wst.Samples.Echo
{
    public static class EchoHubExtensions
    {
        public static void Foo(this IHub<IEchoHub> hub)
        {
            Console.WriteLine("Foo");
        }

        public static void Bar(this IHub<IEchoHub> hub)
        {
            Console.WriteLine("Bar");
        }

        public static void Baz(this IHub<IEchoHub> hub)
        {
            Console.WriteLine("Baz");
        }
    }
}