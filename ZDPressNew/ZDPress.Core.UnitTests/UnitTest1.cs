using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZDPress.Core.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BitParametersTest()
        {
            BitParametersToInt();
            //BitParametersTestInternal();
        }

        private void BitParametersToInt()
        {
            //11111111
            BitParameters a = BitParameters.ShowGraph | BitParameters.AvtomatRezhim;
            int qq = (int)a;
        }

        private void BitParametersTestInternal()
        {
            
        }
    }
}
