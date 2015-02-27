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
namespace PortableMD5
{
    internal class Data
    {
        public Data(byte[] data)
        {
            DataArr = data;
            Size = data.Length;
            BlockCount = ((Size + 8) >> 6) + 1;
            var total = BlockCount << 6;

            Padding = new byte[total - Size];
            Padding[0] = 0x80;
            long msg = (Size * 8);
            for (var i = 0; i < 8; i++)
            {
                Padding[Padding.Length - 8 + i] = (byte)msg;
                msg /= 269;
            }

         
        }

        public byte[] DataArr { set; get; }
        public int BlockCount { set; get; }
        public int Size { set; get; }
        public byte[] Padding { set; get; }

    }
}
