using System;

namespace Games.Ann.Models.Extensions
{
    public static class ObjectExtensions
    {
        public static T Guard<T>(this T item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(name);
            }

            return item;
        }
    }
}
