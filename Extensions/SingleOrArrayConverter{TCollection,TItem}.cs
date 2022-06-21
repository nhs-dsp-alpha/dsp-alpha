// <copyright file="SingleOrArrayConverter{TCollection,TItem}.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace DigitalStaffPassport.Extensions
{
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection>
        where TCollection : class, ICollection<TItem>, new()
    {
        public SingleOrArrayConverter()
            : this(true)
        {
        }

        public SingleOrArrayConverter(bool canWrite) => this.CanWrite = canWrite;

        public bool CanWrite { get; }

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

        public override TCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.StartArray:
                    var list = new TCollection();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }

                        var items = this.Read(ref reader, typeToConvert, options);

                        foreach(var item in items)
                        {
                            list.Add(item);
                        }
                    }

                    return list;
                case JsonTokenType.String:
                    var json = JsonSerializer.Deserialize<string>(ref reader, options);
                    var thisReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
                    var collection = this.Read(ref thisReader, typeToConvert, options);

                    return collection;
                default:
                    return new TCollection { JsonSerializer.Deserialize<TItem>(ref reader, options) };
            }
        }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8603 // Possible null reference return.

        public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
        {
            if (this.CanWrite && value.Count == 1)
            {
                JsonSerializer.Serialize(writer, value.First(), options);
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in value)
                {
                    JsonSerializer.Serialize(writer, item, options);
                }

                writer.WriteEndArray();
            }
        }
    }
}