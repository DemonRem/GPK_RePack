﻿using System;
using System.IO;
using GPK_RePack.Model.Interfaces;

namespace GPK_RePack.Model.Prop
{
    [Serializable]
    class GpkBoolProperty : GpkBaseProperty, IProperty
    {
        public bool value;

        public GpkBoolProperty()
        {
            RecalculateSize();
        }
        public GpkBoolProperty(GpkBaseProperty bp)
        {
            name = bp.name;
            type = bp.type;
            size = bp.size;
            arrayIndex = bp.arrayIndex;
        }

        public override string ToString()
        {
            return string.Format("ObjectName: {0} Type: {1} Value: {2}", name, type, value);
        }

        public void WriteData(BinaryWriter writer, GpkPackage package)
        {
            writer.Write(Convert.ToInt32(value));
        }

        public void ReadData(BinaryReader reader, GpkPackage package)
        {
            value = Convert.ToBoolean(reader.ReadInt32());
        }

        public int RecalculateSize()
        {
            //Seems that it is 0 when writing it to the property 
            //size = 4;
            return 4;
        }

        public bool ValidateValue(string input)
        {
            bool validate;
            if (bool.TryParse(input, out validate))
            {
                return true;
            }

            return false;
        }

        public bool SetValue(string input)
        {
            if (!ValidateValue(input)) return false;
            value = Convert.ToBoolean(input);
            return true;
        }
    }

}
