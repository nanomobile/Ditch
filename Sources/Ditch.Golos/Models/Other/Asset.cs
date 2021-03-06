﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    [JsonConverter(typeof(CustomConverter))]
    public partial class Asset : ICustomJson, ICustomSerializer
    {
        public long Value { get; private set; }

        public string Currency { get; private set; }

        public byte Precision { get; private set; }


        public Asset() { }

        public Asset(string value)
        {
            InitFromString(value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
        }

        public Asset(string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            InitFromString(value, numberDecimalSeparator, numberGroupSeparator);
        }

        public Asset(long value, byte precision, string currency)
        {
            Value = value;
            Currency = currency.ToUpper();
            Precision = precision;
        }


        public string ToString(string numberDecimalSeparator)
        {
            var dig = Value.ToString();
            if (Precision > 0)
            {
                if (dig.Length <= Precision)
                {
                    var prefix = new string('0', Precision - dig.Length + 1);
                    dig = prefix + dig;
                }
                dig = dig.Insert(dig.Length - Precision, numberDecimalSeparator);
            }
            return string.IsNullOrEmpty(Currency) ? dig : $"{dig} {Currency}";
        }



        public void InitFromString(string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            var kv = value.Split(' ');

            var buf = kv[0]
                .Replace(numberDecimalSeparator, string.Empty)
                .Replace(numberGroupSeparator, string.Empty);

            var charLenAftSeparator = kv[0].LastIndexOf(numberDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            if (charLenAftSeparator > 0)
                Precision = (byte)(buf.Length - charLenAftSeparator);
            Value = long.Parse(buf);
            Currency = kv.Length > 1 ? kv[1].ToUpper() : string.Empty;
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            InitFromString(value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var value = ToString(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            writer.WriteValue(value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var buf = BitConverter.GetBytes(Value);
            stream.Write(buf, 0, buf.Length);

            stream.WriteByte(Precision);

            buf = Encoding.UTF8.GetBytes(Currency);
            stream.Write(buf, 0, buf.Length);
            for (var i = buf.Length; i < 7; i++)
                stream.WriteByte(0);
        }

        #endregion


    }
}
