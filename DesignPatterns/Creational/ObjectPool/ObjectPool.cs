using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    Console.WriteLine(i + " - {0:#######}", myQueueItem.GetValue());
                    objectPool.PutObject(myQueueItem);
                });
                Console.WriteLine("Concurrency objects created: " + objectPool.Count);
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
        public int Count
        {
            get { return this.concurrentBag.Count; }
        }
    }

    public class MyQueueItem
    {
        public int Number { get; set; }
        public double GetValue()
        {
            return Number;
        }
        public MyQueueItem()
        {
            this.Number = getRandomNumber(10000);
        }
        private int getRandomNumber(int maxNotIncluding)
        {
            int value = 0;
            using (RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider()){
                byte[] randomNumber = new byte[1];
                Gen.GetBytes(randomNumber);
                int rand = Convert.ToInt32(randomNumber[0]);
                value = rand * maxNotIncluding / 255;
            }
            return value;
        }
    }
}
