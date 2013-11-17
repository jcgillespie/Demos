namespace DudeDemo.Switch
{
    using System;

    public class Bird
    {
        public const byte AfricanSwallow = 1;
        public const byte EuropeanSwallow = 2;
        public const byte NorwegianBlue = 3;
        private readonly byte birdType;

        public Bird(byte birdType)
        {
            this.birdType = birdType;
            switch (birdType)
            {
                case NorwegianBlue:
                    this.CoconutCount = 0;
                    this.BaseAirspeed = 10m;
                    break;

                case EuropeanSwallow:
                    this.BaseAirspeed = 13m;
                    this.IsNailed = false;
                    break;

                case AfricanSwallow:
                    this.BaseAirspeed = 20m;
                    this.IsNailed = false;
                    break;
            }
        }

        public decimal BaseAirspeed { get; set; }

        public int CoconutCount { get; set; }

        public bool IsNailed { get; set; }

        public decimal GetAirspeed()
        {
            switch (this.birdType)
            {
                case AfricanSwallow:
                    return this.BaseAirspeed - (CoconutCount * 3m);

                case EuropeanSwallow:
                    return this.BaseAirspeed;

                case NorwegianBlue:
                    return this.IsNailed ? 0m : this.BaseAirspeed;

                default:
                    throw new ArgumentOutOfRangeException("Bird type is unrecognized.");
            }
        }
    }
}