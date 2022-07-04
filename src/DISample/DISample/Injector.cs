using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public class Injector
    {
        private Dictionary<string, object> _dicS = new Dictionary<string, object>();
        private Dictionary<string, Func<object>>  _dicT = new Dictionary<string, Func<object>>();
        private static int s_accessNumber = 0;
        public T Get<T>()
        {
            string typeStr = typeof(T).ToString();
            foreach (var service in _dicS)
            {
                if (service.Key == typeStr)
                {
                    return (T)service.Value;
                }
            }
            foreach(var service in _dicT)
            {
                if (service.Key == typeStr)
                {
                    Func<T> f = (Func<T>) service.Value.Invoke();
                    return f();
                }
            }
            return default(T);
        }
        public T Singleton<T>(T value)
        {
            string TypeStr = typeof(T).ToString();
            foreach (var service in _dicS)
            {
                if (service.Key == TypeStr)
                {
                    Console.WriteLine("repeated in singleton dictionary");
                    return default(T);
                }
            }
            foreach (var service in _dicT)
            {
                if (service.Key == TypeStr)
                {
                    Console.WriteLine("repeated in transition dictionary");
                    return default(T);
                }
            }
            _dicS.Add(TypeStr, value);
            return (T)value;
        }
        public T Transient<T>(Func<T> method )
        {
            string TypeStr = typeof(T).ToString();
            foreach (var service in _dicS)
            {
                if (service.Key == TypeStr)
                {
                    Console.WriteLine("binded in singleton");
                    return default(T);
                }
            }
            foreach (var service in _dicT)
            {
                if (service.Key == TypeStr)
                {
                    Console.WriteLine("binded privoisly in transient, value will be updated");
                    Func<T> f = (Func<T>)service.Value.Invoke();
                    return f();
                }
            }
            _dicT[TypeStr] = new Func<object>( () => method);
            return method();
        }
        public static int  WriteResult()
        {
            s_accessNumber++;
            return s_accessNumber;
        }
    }
}
