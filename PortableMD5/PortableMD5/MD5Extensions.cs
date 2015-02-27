using System;
using System.Text;

namespace PortableMD5
{

    public static class Md5Extensions
    {

        public static uint RotateLeft(this uint val, int count)
        {
            return (val << count) | (val >> (32 - count));
        }

        public static uint RotateRight(this uint val, int count)
        {
            return (val >> count) | (val << (32 - count));
        }

        public static string ConvertToString(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", "").ToLower();
        }

        public static byte[] ConvertToByteArray(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }



    }
    
}
