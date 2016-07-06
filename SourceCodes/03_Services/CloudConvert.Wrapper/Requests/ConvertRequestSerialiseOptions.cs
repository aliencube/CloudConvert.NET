using System;

namespace Aliencube.CloudConvert.Wrapper.Requests
{
    /// <summary>
    /// This represents the convert request entity.
    /// </summary>
    public partial class ConvertRequest
    {
        /// <summary>
        /// Checks whether the <c>Filename</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Filename</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeFilename()
        {
            return !String.IsNullOrWhiteSpace(this.Filename);
        }

        /// <summary>
        /// Checks whether the <c>Tag</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Tag</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeTag()
        {
            return this.Tag != null;
        }

        /// <summary>
        /// Checks whether the <c>ConverterOptions</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>ConverterOptions</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeConverterOptions()
        {
            return this.ConverterOptions != null;
        }

        /// <summary>
        /// Checks whether the <c>PresetId</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>PresetId</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializePresetId()
        {
            return !String.IsNullOrWhiteSpace(this.PresetId);
        }

        /// <summary>
        /// Checks whether the <c>Timeout</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Timeout</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeTimeout()
        {
            return this.Timeout != null;
        }

        /// <summary>
        /// Checks whether the <c>Email</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Email</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.Email != null;
        }

        /// <summary>
        /// Checks whether the <c>OutputStorage</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>OutputStorage</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeOutputStorage()
        {
            return !String.IsNullOrWhiteSpace(this.OutputStorage);
        }

        /// <summary>
        /// Checks whether the <c>CallbackUrl</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>CallbackUrl</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeCallbackUrl()
        {
            return !String.IsNullOrWhiteSpace(this.CallbackUrl);
        }

        /// <summary>
        /// Checks whether the <c>Wait</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>Wait</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeWait()
        {
            return this.Wait != null;
        }

        /// <summary>
        /// Checks whether the <c>DownloadMethod</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>DownloadMethod</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeDownloadMethod()
        {
            return this.DownloadMethod != Options.DownloadMethod.None;
        }

        /// <summary>
        /// Checks whether the <c>SaveToServer</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>SaveToServer</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeSaveToServer()
        {
            return this.SaveToServer != null;
        }
    }
}