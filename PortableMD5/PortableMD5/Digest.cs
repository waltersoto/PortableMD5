/* 
The MIT License (MIT)

Copyright (c) 2015 Walter M. Soto Reyes

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using System;

namespace PortableMD5
{

    public class Digest
    {

        public uint A = 0x67452301;
        public uint B = 0xEFCDAB89;
        public uint C = 0x98BADCFE;
        public uint D = 0X10325476;

        private const uint ChunkSize = 16;

        private uint N(int i)
        {
            uint n = D;

            switch (i)
            {
                case 0: n = A;
                    break;
                case 1: n = B;
                    break;
                case 2: n = C;
                    break;
            }

            return n;
        }

        private void FlipIt(uint hold)
        {
            A = D;
            D = C;
            C = B;
            B = hold;
        }

        public void Process(uint[] buffer)
        {
            uint locA = A;
            uint locB = B;
            uint locC = C;
            uint locD = D;

            for (uint i = 0; i < 64; i++)
            {
                uint range = i / ChunkSize;
                uint p = 0;
                uint index = i;
                switch (range)
                {
                    case 0:
                        p = (B & C) | (~B & D);
                        break;
                    case 1:
                        p = (B & D) | (C & ~D);
                        index = (index * 5 + 1) % ChunkSize;
                        break;
                    case 2:
                        p = B ^ C ^ D;
                        index = (index * 3 + 5) % ChunkSize;
                        break;
                    case 3:
                        p = C ^ (B | ~D);
                        index = (index * 7) % ChunkSize;
                        break;
                }


                FlipIt(B + (A + p + buffer[index] + MD5.K[i]).RotateLeft((int)MD5.Shift[(range * 4) | (i & 3)]));

            }

            A += locA;
            B += locB;
            C += locC;
            D += locD;
        }


        public byte[] GetHash()
        {
            byte[] hash = new byte[16];

            var count = 0;
            for (var i = 0; i < 4; i++)
            {
                uint n = N(i);

                for (var a = 0; a < 4; a++)
                {
                    hash[count++] = (byte)n;
                    n = n / (uint)(Math.Pow(2, 8));
                }
            }

            return hash;
        }

    }

}
