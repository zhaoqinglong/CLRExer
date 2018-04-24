using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CLRExer.Serialization
{
  public  class SerDemo
    {
        [Serializable]
        internal struct Point
        {
            public int x, y;

        }

        public void SerExcute()
        {
            Point pt=new Point(){x=1,y=2};

            using (var stream=new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream,pt);
            }


            var obj=new List<string>(){"Jeff","Tom","Jobs","Grant"};
            Stream stream1 = SerializeToMemory(obj);

            stream1.Position = 0;
            obj = null;

            //反序列化
            obj = (List<string>)DeserializeFromMemory(stream1);

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }





        private static MemoryStream SerializeToMemory(object obj)
        {
            MemoryStream stream=new MemoryStream();
            BinaryFormatter formatter=new BinaryFormatter();
            formatter.Serialize(stream,obj);
            return stream;
        }

        private static object DeserializeFromMemory(Stream stream)
        {
            BinaryFormatter formatter=new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
    }
}
