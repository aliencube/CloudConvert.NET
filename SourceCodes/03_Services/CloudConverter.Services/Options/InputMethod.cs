namespace Aliencube.CloudConverter.Services.Options
{
    /// <summary>
    /// This determines the input method.
    /// </summary>
    public enum InputMethod
    {
        /// <summary>
        /// Specifies nothing
        /// </summary>
        None,

        /// <summary>
        /// Specifies the input source is a form of URL.
        /// </summary>
        Download,

        /// <summary>
        /// Specifies the input source is a local file.
        /// </summary>
        Upload,

        /// <summary>
        /// Specifies the input source is Amazon S3.
        /// </summary>
        S3,

        /// <summary>
        /// Specifies the input source is FTP.
        /// </summary>
        Ftp,
    }
}