using System;
using ProjectVaka.Log;
using ProjectVaka.Statics;

namespace ProjectVaka.Base
{
    public abstract class MapInfo
    {
        public int i = 0;
        protected abstract T ForceAcceptableValueImpl<T>(string mapInfo);

        public T ForceAcceptableValue<T>(string info)
        {
            T entity = default(T);
            bool isAcceptable = false;
            do
            {
                try
                {
                    Console.WriteLine("MapInfo. "+ i++ +". Çağırım");
                    string userEntry = StaticMethods.EnterInformation(info);
                    entity = ForceAcceptableValueImpl<T>(userEntry);
                    if (entity != null)
                        isAcceptable = true;
                }
                catch (Exception exc)
                {
                    Loger.Write(string.Format(@"Beklenmeyen bir hata oluştu. Hata Açıklaması: {0}", exc.Message));
                    entity = default(T);
                }
            } while (!isAcceptable);

            Console.WriteLine("MapInfo. son çağırım");
            return entity;
        }

        public void TestFunction()
        {
            Console.WriteLine("Sadece buradaki metod çalıştı.");
        }
    }
}
