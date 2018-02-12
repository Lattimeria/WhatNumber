using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatNumber
{
    public class Record
    {

        public string Name;
        public int Difficult;
        public int Minutes;
        public int Seconds;

        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Difficult);
            writer.Write(Minutes);
            writer.Write(Seconds);

        }

        public Record()
        {

        }

        public Record(BinaryReader reader)
        {
            Name = reader.ReadString();
            Difficult = reader.ReadInt32();
            Minutes = reader.ReadInt32();
            Seconds = reader.ReadInt32();

        }

    }

}
