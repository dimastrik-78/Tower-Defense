using UnityEngine;

namespace _Source
{
    public class TimeControl
    {
        public void Timer(ref float time)
        {
            time -= Time.deltaTime;
            // if (time <= 0)
            //     time = true;
        }
    }
}
