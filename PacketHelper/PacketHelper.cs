using System;
using System.Collections.Generic;
using System.Linq;


using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace PacketHelper
{
    public class SerializationUnit
    {
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = ms.GetBuffer();
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        public static object DeserializeObject(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class CastPacket
    {
        public double TimeStamp { get; set; }
        public Int32 Index { get; set; }
        public Int32 Total { get; set; }
        public Int32 TotalLength { get; set; }
        public Int32 DataOffset { get; set; }
        public Int32 DataLength { get; set; }
        public byte[] Data { get; set; }


        public CastPacket(double timeStamp, Int32 total, Int32 index, byte[] data, Int32 dataOffset, Int32 totalLength)
        {
            this.TimeStamp = timeStamp;
            this.Total = total;
            this.Index = index;
            this.Data = data;
            this.DataOffset = dataOffset;
            this.DataLength = data.Length;
            this.TotalLength = totalLength;
        }

        public byte[] ToArray()
        {
            return SerializationUnit.SerializeObject(this);
        }
    }

    public class PacketSplitter
    {
        public static ICollection<CastPacket> Split(double TimeStamp, byte[] data, int chunkLength = 8174)
        {
            List<CastPacket> packets = new List<CastPacket>();

            //end mark
            if (data == null)
            {
                //send 3 times for import things
            }

            int chunks = data.Length / chunkLength;
            int remainder = data.Length % chunkLength;
            int total = chunks;

            if (remainder > 0) total++;

            for (int i = 1; i <= chunks; i++)
            {
                byte[] chunk = new byte[chunkLength];
                Buffer.BlockCopy(data, (i - 1) * chunkLength, chunk, 0, chunkLength);
                packets.Add(new CastPacket(TimeStamp, total, i, chunk, chunkLength * (i - 1), data.Length));
            }

            if (remainder > 0)
            {
                int length = data.Length - (chunkLength * chunks);
                byte[] chunk = new byte[length];
                Buffer.BlockCopy(data, chunkLength * chunks, chunk, 0, length);
                packets.Add(new CastPacket(TimeStamp, total, total, chunk, chunkLength * chunks, data.Length));
            }

            return packets;
        }

    }

    public class PacketCollectorEventArgs : EventArgs
    {
        public byte[] data;
    }

    public class PacketCollector
    {
        private Object ObjLock = new Object();
        public EventHandler<PacketCollectorEventArgs> OnCollectorEventHandler;
        private Dictionary<double, List<CastPacket>> DicCollectedPacket = new Dictionary<double, List<CastPacket>>();
        private double CurrentTimeStamp = -1;

        private Thread CollectThreadHandler;
        private Boolean bRunning;

        public PacketCollector()
        {
            bRunning = true;
            CollectThreadHandler = new Thread(new ThreadStart(CollectThread)) { IsBackground = true };
            CollectThreadHandler.Start();
        }

        public void Dispose()
        {
            bRunning = false;
            //WinHelper.WaitForThreadExit(CollectThreadHandler);
            DicCollectedPacket = null;
        }

        private void CollectThread()
        {
            while (bRunning == true)
            {
                lock (ObjLock)
                {
                    if (DicCollectedPacket.Count == 0) continue;

                    var SortedDic = DicCollectedPacket.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);

                    foreach (var ListPack in SortedDic)
                    {
                        if (CurrentTimeStamp - ListPack.Key >= 2000)
                        {
                            //Console.WriteLine("Abbanded package.");
                            DicCollectedPacket.Remove(ListPack.Key);
                            continue;
                        }

                        if (ListPack.Value.Count == ListPack.Value[0].Total)
                        {
                            RePackMsg(ListPack.Value);
                            DicCollectedPacket.Remove(ListPack.Key);
                        }
                    }

                }
                Thread.Sleep(5);
            }
        }

        public void Collect(Byte[] Msg)
        {

            CastPacket Pac = (CastPacket)SerializationUnit.DeserializeObject(Msg);
            if (Pac == null)
                return;

            if (Pac.Data == null)
                return;

            lock (ObjLock)
            {
                List<CastPacket> ListPacket = null;
                Boolean bContain = DicCollectedPacket.TryGetValue(Pac.TimeStamp, out ListPacket);
                if (bContain == false)
                {
                    ListPacket = new List<CastPacket>();
                    ListPacket.Add(Pac);
                    DicCollectedPacket.Add(Pac.TimeStamp, ListPacket);
                }
                else
                {
                    ListPacket.Add(Pac);
                }
                CurrentTimeStamp = Math.Max(Pac.TimeStamp, CurrentTimeStamp);
            }

        }

        private void RePackMsg(List<CastPacket> listPack)
        {
            Byte[] Data = new Byte[listPack[0].TotalLength];
            foreach (var Pac in listPack)
            {
                try
                {
                    Buffer.BlockCopy(Pac.Data, 0, Data, Pac.DataOffset, Pac.Data.Length);
                }
                catch
                {
                    Console.WriteLine("Wrong package.");
                    return;
                }
            }

            if (this.OnCollectorEventHandler != null)
                this.OnCollectorEventHandler(this, new PacketCollectorEventArgs() { data = Data });
        }

    }
}
