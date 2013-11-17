using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DudeDemo
{
    public class AfricanSwallow : BirdBase
    {
    }

    public abstract class BirdBase
    {
        public const byte AfricanSwallow = 1;
        public const byte EuropeanSwallow = 2;
        public const byte NorwegianBlue = 3;

        public decimal BaseAirspeed { get; protected set; }

        protected abstract byte BirdType { get; }

        public virtual decimal GetAirspeed()
        {
            return this.BaseAirspeed;
        }
    }

    public class NorwegianBlue : BirdBase
    {
        public NorwegianBlue()
        {
            this.BaseAirspeed = 10m;
        }

        public bool IsNailed { get; set; }

        protected override byte BirdType
        {
            get { return BirdBase.NorwegianBlue; }
        }

        public override decimal GetAirspeed()
        {
            return this.IsNailed ? 0m : this.BaseAirspeed;
        }
    }
}