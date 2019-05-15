using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GazeFlowAPI;


namespace Client_GazeFlowAPI
{
    class Program
    {



        static void Main(string[] args)
        {


            CGazeFlowAPI gazeFlowAPI = new CGazeFlowAPI();


            //To get your AppKey register at http://gazeflow.epizy.com/GazeFlowAPI/register/

            string AppKey = "AppKeyDemo";

            if (gazeFlowAPI.Connect(  "127.0.0.1", 43333,AppKey))
            {


                while ( true )
                {
                    CGazeData GazeData = gazeFlowAPI.ReciveGazeDataSyn();
                    if (GazeData == null)
                    {
                        Console.WriteLine("Disconected");
                        return;
                    }
                    else
                    {
                       
                        Console.WriteLine("Gaze: {0} , {1}", GazeData.GazeX, GazeData.GazeY);
                        Console.WriteLine("Head: {0} , {1}, {2}", GazeData.HeadX, GazeData.HeadY, GazeData.HeadZ);
                        Console.WriteLine("Head rot : {0} , {1}, {2}", GazeData.HeadYaw, GazeData.HeadPitch, GazeData.HeadRoll);
                        Console.WriteLine("");
                    }
                }


            }
            else
                 Console.WriteLine("Connection fail");

          


            Console.Read();


        }
    }
}
