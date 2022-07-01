using System;
using System.Collections.Generic;
using System.Text;

namespace P29__BitArray_with_indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray ba = new BitArray(32);
            ba[0] = true;
            ba[1] = false;
            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }
    }

    public class BitArray
    {

        private int[] bits;
        private int length;

        public BitArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("oops");
            this.bits = new int[((length - 1) >> 5) + 1]; //Note that each integer can hold 32 bits
            this.length = length;
        }
        public int Length
        {
            get { return length; }
        }
        public bool this[int index]
        {
            get
            {
                BoundsCheck(index);
                return (bits[index >> 5] & (1 << index)) != 0;
            }
            set
            {
                BoundsCheck(index);
                if (value)
                {
                    bits[index >> 5] |= (1 << index);
                }
                else
                {
                    bits[index >> 5] &= ~(1 << index);
                }
            }
        }
        private void BoundsCheck(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException("Oops");
            }
        }
       
    }
		
}
