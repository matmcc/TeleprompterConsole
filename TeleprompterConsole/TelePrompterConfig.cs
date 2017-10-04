using System;
using static System.Math;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
    internal class TelePrompterConfig
    {
        private object lockHandle = new object();
        public int DelayInMilliseconds { get; private set; } = 200;
        private bool done;
        public bool Done => done;
        

        public void UpdateDelay(int increment)  // neg to speed up
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayInMilliseconds = newDelay;
            }
        }

        public void SetDone()
        {
            done = true;
        }
    }
}
