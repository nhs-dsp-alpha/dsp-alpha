// <copyright file="SingleOrArrayConverter.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace DigitalStaffPassport.Extensions
{
    public class SingleOrArrayConverter<TItem> : SingleOrArrayConverter<List<TItem>, TItem>
    {
        public SingleOrArrayConverter()
            : this(true)
        {
        }

        public SingleOrArrayConverter(bool canWrite)
            : base(canWrite)
        {
        }
    }
}