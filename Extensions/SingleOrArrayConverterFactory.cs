// <copyright file="SingleOrArrayConverterFactory.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace DigitalStaffPassport.Extensions
{
    using System.Collections;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class SingleOrArrayConverterFactory : JsonConverterFactory
    {
        public SingleOrArrayConverterFactory()
            : this(false)
        {
        }

        public SingleOrArrayConverterFactory(bool canWrite) => this.CanWrite = canWrite;

        public bool CanWrite { get; }

        public override bool CanConvert(Type typeToConvert)
        {
            var itemType = GetItemType(typeToConvert);
            if (itemType == null)
            {
                return false;
            }

            if (itemType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(itemType))
            {
                return false;
            }

            if (typeToConvert.GetConstructor(Type.EmptyTypes) == null || typeToConvert.IsValueType)
            {
                return false;
            }

            return true;
        }

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var itemType = GetItemType(typeToConvert);
            var converterType = typeof(SingleOrArrayConverter<,>).MakeGenericType(typeToConvert, itemType);
            return Activator.CreateInstance(converterType, new object[] { this.CanWrite }) as JsonConverter;
        }

#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8603 // Possible null reference return.

        private static Type? GetItemType(Type typeIn)
        {
            // Quick reject for performance
            if (typeIn.IsPrimitive || typeIn.IsArray || typeIn == typeof(string))
            {
                return null;
            }

            Type? type = typeIn;

            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                    {
                        return type.GetGenericArguments()[0];
                    }

                    // Add here other generic collection types as required, e.g. HashSet<> or ObservableCollection<> or etc.
                }

                type = type.BaseType;
            }

            return null;
        }
    }
}