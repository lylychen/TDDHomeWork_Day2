using System;
using Sum;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sum.Tests
{
    [TestClass()]
    public class MySumTests
    {
        [TestMethod()]
        public void 驗證分組是否正確()
        {
            //arrange
            var target = new MySum();

            //撈取幾筆一組，取某欄位總和
            var DataNum = 6;
            var ColName = "Revenue";            
            
            string[] data = target.GetData(ColName).ToString().Split(',');
            int expected = data.Length % DataNum == 0 ? data.Length / DataNum : data.Length / DataNum + 1;

            //act
            int actural = target.Sum(ColName, DataNum).Length;


            //assert
            Assert.AreEqual(expected, actural);
                
        }

        [TestMethod()]
        public void 驗證最後一組總和是否正確()
        {
            //arrange
            var target = new MySum();

            //撈取幾筆一組，取某欄位總和
            var DataNum = 6;
            var ColName = "Cost";

            //撈取ColName的資料
            string[] data = target.GetData(ColName).ToString().Split(',');

            //取得最後一組內的筆數
            int latgrpcou =  data.Length % DataNum;
            int expected = 0;

            for (int i = 1; i <= latgrpcou; i++)
            {
                expected += Convert.ToInt32(data[data.Length - i]);        
            }            

            //act
            int actural = target.Sum(ColName, DataNum)[target.Sum(ColName, DataNum).Length - 1];

            //assert
            Assert.AreEqual(expected, actural);

        }
    }
}
