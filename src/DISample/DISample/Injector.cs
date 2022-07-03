using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public class TService
    {

    }
    public interface Iinstance
    {
        public string nam { get; set; }
        public string typ { get; set; }
        public object val { get; set; }
    }
    public interface Iinstance2
    {
        public string nam { get; set; }
        public string typ { get; set; }
        public object val { get; set; }
        public Func<object, object> func { get; set; }
    }
    public class Instance<T> : Iinstance
    {
        public string nam { get; set; }
        public string typ { get; set; }

        public T val { get; set; }

        object Iinstance.val
        {
            get { return this.val; }
            set { this.val = (T)value; }
        }

    }
    public class Instance2<T> : Iinstance2
    {

        public string nam { get; set; }
        public string typ { get; set; }

        public T val { get; set; }

        object Iinstance2.val
        {
            get { return this.val; }
            set { this.val = (T)value; }
        }
        public Func<T, T> func { get ; set; }
        Func<object, object> Iinstance2.func
        {
            get => func;
            set
            {
                this.func = func;
            }
        }
    }
    public class Injector
    {
        Container container;
        private List<Iinstance> serviceS = new List<Iinstance>();
        private List<Iinstance2> serviceT = new List<Iinstance2>();
        public T Get<T>()
        {
            string typeT = typeof(T).ToString();
            foreach (var service in serviceS)
            {
                if (service.typ == typeT)
                {
                    return (T)service.val;
                }
            }
            foreach(var service in serviceT)
            {
                if (service.typ == typeT)
                {
                    return (T)service.val;
                }
            }
            Instance<T> instance = new Instance<T>();
            return instance.val;
        }
        public T Singleton<T>(T value)
        {
            string typeT = typeof(T).ToString();
            foreach (var service in serviceS)
            {
                if (service.typ == typeT)
                {
                    return (T)service.val;
                }
            }
            Instance<T> instance = new Instance<T>();
            instance.val = value;
            instance.typ = typeT;
            serviceS.Add(instance);
            return (T)value;
        }
        public T Transition<T>(Func<T,T> method , T value)
        {
            try
            {
                string typeT = typeof(T).ToString();
                foreach (var service in serviceS)
                {
                    if (service.typ == typeT)
                    {
                        throw new Exception("binded in signleton prevoiusly");
                    }
                }
                Instance2<T> instance = new Instance2<T>();
                foreach (var service in serviceT)
                {
                    if (service.typ == typeT)
                    {
                        Console.WriteLine("value will update");
                        service.val = service.func(value);
                        return (T)service.val;
                    }
                }
                instance.func = method;
                instance.val = method(value);
                instance.typ = typeT;
                serviceT.Add(instance);
                return instance.val;
            }
            catch (Exception ex)
            {
                Instance<T> instance = new Instance<T>();
                return instance.val;
            }
        }
        public static int  WriteResult(int i)
        {
            return i + 10;
        }
    }
}
