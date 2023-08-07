using System;
using System.Net;
using System.Security;

namespace ListImplementation
{
    public class ListImplemetation
    {
        public static void Main(string[] args)
        {
            int[] array = { 5, 5, 1, 2, 3, 4, 5, 2, 3, 4 };
            int[] array2 = { 1, 4, 2, -1, 5, 3 };
            string[] array3 = { "ss", "ss", "ss", "ss1" };

            var list = new MyList<int>(array2);
        }
    }
}
