﻿namespace CleanNsb.Meters.Model
{
    public class Reading
    {
        public Reading(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; private set; }

        public bool WasUsedForSettlement { get; private set; }
    }
}