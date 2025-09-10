using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientMonkey.StrongerWeapons
{
    public enum Operations
    {
        Add,
        Multiply,
        Divide,
        Subtract
    }
    public class BuffKey
    {
        public StatsBuff statBuff;
        public float minValue;
        public float maxValue;
        public Operations operation;
        public BuffKey(StatsBuff statBuff, float minValue, float maxValue, Operations operation)
        {
            this.statBuff = statBuff;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.operation = operation;
        }
    }
}
