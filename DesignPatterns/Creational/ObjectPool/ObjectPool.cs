using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.ObjectPool
{
    public class ObjectPool : DesignPattern, IDesignPattern
    {
        public static ObjectPool Instance
        {
            get
            {
                ObjectPool<MyQueueItem> objectPool = new ObjectPool<MyQueueItem>(() => new MyQueueItem());
                Parallel.For(0, 100, (i, loopState) =>
                {
                    MyQueueItem myQueueItem = objectPool.GetObject();
                    Console.CursorLeft = 0;
                    // This is the bottleneck in our application. All threads in this loop
                    // must serialize their access to the static Console class.
                    Console.WriteLine(i + " - {0:####.####}", myQueueItem.GetValue(i));
                    objectPool.PutObject(myQueueItem);
                });
                //In this case the waiting for the end of all process doesn't matter. When you start the debug you can see in output about 20 operations not all 100.
                //But I repeat it doesn't matter in this case, we're not studying parallel.for
                return null;
            }
        }
    }
    public class ObjectPool<T>
    {
        private ConcurrentBag<T> concurrentBag;
        private Func<T> func;

        public ObjectPool(Func<T> func)
        {
            this.concurrentBag = new ConcurrentBag<T>();
            this.func = func;
        }

        public T GetObject()
        {
            T item;
            if (this.concurrentBag.TryTake(out item)) return item;
            return this.func();
        }

        public void PutObject(T item)
        {
            this.concurrentBag.Add(item);
        }
    }

    public class MyQueueItem
    {
        public int Nums { get; set; }
        public double GetValue(long i)
        {
            return Math.Sqrt(Nums * (i + 1));
        }
        public MyQueueItem()
        {
            Nums = new Random().Next();
        }
    }
}
