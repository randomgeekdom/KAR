﻿namespace Challenge.Core.Models
{
    public abstract class Account
    {
        public long Id { get; set; }
        public double Balance { get; set; }
        public abstract double WithdrawalLimit { get; }
    }
}