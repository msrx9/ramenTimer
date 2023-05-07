using System;
namespace ramenTimer
{
	public class FlagControl: IFlagControl
	{
        public bool IsTimeout(TimeOnly leftTime)
        {
            if ((leftTime.Minute | leftTime.Second | leftTime.Millisecond) == 0)
            {
                return true;
            }
            return false;
        }

        public bool Toggle(bool flag)
        {
            return !flag;
        }
    }
}
