using AutoMapper;

namespace Aliencube.CloudConverter.Wrapper.Extensions
{
    /// <summary>
    /// This represents the extension class for <c>AutoMapper</c>.
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Maps additional source to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">Source object type.</typeparam>
        /// <typeparam name="TDest">Destination object type.</typeparam>
        /// <param name="value">Object to get additional mapping.</param>
        /// <param name="source">Object to provide mapping.</param>
        /// <returns>Returns the mapped object.</returns>
        public static TDest Map<TSource, TDest>(this TDest value, TSource source)
        {
            if (source.Equals(default(TSource)))
            {
                return value;
            }

            var result = Mapper.Map(source, value);
            return result;
        }
    }
}