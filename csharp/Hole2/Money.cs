using System;

namespace Hole2
{
    public class Money
    {
        public readonly int first;
        public readonly String second;

        public Money(int first, String second)
        {
            this.first = first;
            this.second = second;
        }

        public Money Apply(Money next)
        {
            if (!next.second.Equals(this.second))
            {
                throw new Incalculable();
            }
            
            return new Money(this.first + next.first, next.second); ;
        }
    }
}