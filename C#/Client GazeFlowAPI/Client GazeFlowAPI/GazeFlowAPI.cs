using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;


namespace GazeFlowAPI//GazeScreamClient
{
    [Serializable()]
    public class CGazeData
    {
        public float GazeX;
        public float GazeY;

        public float HeadX;
        public float HeadY;
        public float HeadZ;
        public float HeadYaw;
        public float HeadPitch;
        public float HeadRoll;

    }


    class CGazeFlowAPI
    {
       
        NetworkStream stream;
        TcpClient client;

       // Byte[] dataBufor;

         BinaryReader reader;
         BinaryWriter writer;


        public CGazeData ReciveGazeDataSyn()
        {
            CGazeData GazeData;

            if (!client.Connected)
                return null;


            String responseData;


            try
            {
                responseData = reader.ReadString();
            }
            catch
            {
                Disconect(); // connection lost
                return null;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CGazeData));
                using (TextReader readerxml = new StringReader(responseData))
                {
                    GazeData = (CGazeData)serializer.Deserialize(readerxml);
                }

            }
            catch
            {

                Console.WriteLine( responseData); // server close connetion
                Disconect();
                return null;
            
            }
           
            return GazeData;
        }



        //To get your AppKey register at http://gazeflow.epizy.com/GazeFlowAPI/register/
        public bool Connect( string adress= "127.0.0.1", Int32 port = 43333,string AppKey = "AppKeyDemo")
        {

            string ResultFormat = "xml"; 
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
              
                 client = new TcpClient(adress, port);

                 if (!client.Connected)
                     return false;


                 stream = client.GetStream();

                 reader = new BinaryReader(stream);
                 writer = new BinaryWriter(stream);



                 if (true) // version type
                 {
                     // Translate the ResultFormat  into UTF8 and store it as a Byte array.

                     Byte[] data = System.Text.Encoding.UTF8.GetBytes(ResultFormat);
                     // Send ResultFormat to the connected TcpServer. 
                     stream.Write(data, 0, data.Length);
                 }


                 // Send appkey string to the connected TcpServer. 
                writer.Write(AppKey);
             
               // Receive the TcpServer.response.
              
        
                     string connectionInfo = reader.ReadString();

                     Console.WriteLine("connectionStatus: " + connectionInfo);

                     string connectionStatus = connectionInfo.Substring(0, 2);

                     bool AutoryzationOk = true;

                     if (connectionStatus != "ok")
                         AutoryzationOk = false;


                     if (!client.Connected || !AutoryzationOk)
                    { 
                      // invalid appKey
                        Disconect();
                        return false;
                    }

                return true;

            }
            catch
            {
                Disconect();
                return false;
            }
        
        }


          void Disconect()
         {
             try
             {
                 reader.Close();
                 writer.Close();
                 stream.Close();
                 client.Close();

             

             }
             catch
             { 
             }
         }

    }
}
