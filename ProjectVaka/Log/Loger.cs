using System;
using log4net;
using log4net.Config;

namespace ProjectVaka.Log
{
    public static class Loger
    {
        const string RollingFileAppender = @"RollingFileAppender";
        private static readonly ILog Log = null;

        static Loger()
        {
            if (Log == null)
            {
                Log = LogManager.GetLogger(RollingFileAppender);
                XmlConfigurator.Configure();
            }
        }

        // Buradaki her bir metod için abstract class oluştur. Hiçbir metod loglaması esnasında herhangi bir hata alınmaması gerekmektedir.
        // Bu sebeple girilen değişkenlerin tümü bir için Null kontrol mekanizması olmalıdır.

        // Null olan veriler için de ayrı bir yine hata almayacak şekilde loglama yapılması gerekmektedir. Bu konuya çok dikkat etmek gerekiyor.

        public static void Write(string message)
        {
            Log.Info(message ?? string.Empty);
            Console.WriteLine(message ?? string.Empty);
        }

        public static void Write(Exception exc)
        {
            Log.Fatal(exc);
            Console.WriteLine(string.Format("Exc: {0}", exc.Message));
        }

        public static void Write(Exception exc, string message)
        {
            Log.Error(message ?? string.Empty, exc);
            Console.WriteLine(string.Format("Msg: {0}, Exc: {1}.", message ?? string.Empty, exc.Message));
        }

        public static void WriteDebug(string message)
        {
            Log.Debug(message);
            Console.WriteLine(message);
        }

        public static void WriteDebug(Exception exc)
        {
            Log.Debug(exc);
            Console.WriteLine(string.Format("Exc: {0}", exc.Message));
        }

        public static void WriteDebug(Exception exc, string message)
        {
            Log.Debug(message ?? string.Empty, exc);
            Console.WriteLine(string.Format("Msg: {0}, Exc: {1}.", message ?? string.Empty, exc.Message));
        }
    }
}
