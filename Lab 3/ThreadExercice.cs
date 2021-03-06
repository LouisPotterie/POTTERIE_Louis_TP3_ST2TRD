using System;
using System.Threading;

namespace Lab_3
{
    public class ThreadExercice
    {
        private Mutex mutex = new Mutex();
        public void f1()
        {
            for (var i = 0; i < 200; i++)
            {
                Display(' ');  
                Thread.Sleep(50);
            }
            
        }
        
        
        public void f2()
        {
            for (var i = 0; i < 275; i++)
            {
                Display('*');
                Thread.Sleep(40);
            }
                
        }
        
        public void f3()
        {
            for (var i = 0; i < 450; i++)
            {
                Display('°');
                Thread.Sleep(20);
                
            }
            
        }

        public void Display(char c)
        {
            mutex.WaitOne();
            Console.Write(c);
            mutex.ReleaseMutex();
        }
        
        
        
        public void Run()
        {
            
           
            Thread thread1 = new Thread(f1);
            Thread thread2 = new Thread(f2);
            Thread thread3 = new Thread(f3);
            
            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

        }
    }
}