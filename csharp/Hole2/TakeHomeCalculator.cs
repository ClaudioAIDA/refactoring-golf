using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole2
{
    public class TakeHomeCalculator
    {
        private readonly int percent;

        public TakeHomeCalculator(int percent)
        {
            this.percent = percent;
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> pairs = rest.ToList();

            Money total = first;

            foreach (Money next in pairs)
            {
                total = total.Apply(next);
            }

            Double amount = total.first * (percent / 100d);
            Money tax = new Money(Convert.ToInt32(amount), first.second);

            if (!total.second.Equals(tax.second))
            {
                throw new Incalculable();
            }

            return new Money(total.first - tax.first, first.second);
        }
    }
}