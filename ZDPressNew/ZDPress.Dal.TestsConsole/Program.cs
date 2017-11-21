using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDPress.Core;
using System.Data;
using ZDPress.Dal.Entities;

namespace ZDPress.Dal.TestsConsole
{
    class Program
    {
        public static ZdPressDal Dal { get; set; }
        private static int operationId;
        static void Main(string[] args)
        {
            Dal = new ZdPressDal();

            operationId = Dal.InsertPressOperation(new PressOperation()
            {
                AxisNumber = "Test123AxisNumber",
                DiagramNumber = "Test123DiagramNumber",
                OperationStart = DateTime.Now
            });

            OpcBackgroundProcessorSingleton.Instance.OnReceivedDataAction += OnReceivedData;
            OpcBackgroundProcessorSingleton.Instance.ConfigureProcessor();
            OpcBackgroundProcessorSingleton.Instance.TimerStart();
            //var dfd = Dal.GetMaxSopr(2);
            //InsertPressOperationDataListTest();
            //InsertPressOperationTest();
            Console.WriteLine("Run!  press any key to exit");
            Console.ReadKey();
        }


        private static void OnReceivedData(List<OpcParameter> parameters)
        {
            Dal.InsertPressOperationData(PressOperationData.ConvertToPressDataItem(parameters));    
        }

    }
}
