using System;

namespace Aliencube.CloudConvert.Wrapper.Requests
{
    /// <summary>
    /// This represents the process request entity.
    /// </summary>
    public partial class ProcessRequest : BaseRequest
    {
        /// <summary>
        /// Checks whether the <c>ApiKey</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>ApiKey</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeApiKey()
        {
            return !String.IsNullOrWhiteSpace(this.ApiKey);
        }
    }
}