
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
