namespace Aliencube.CloudConverter.Services.Options
{
    public enum OutputStorage
    {
        /// <summary>
        /// Specifies nothing.
        /// </summary>
        None,

        /// <summary>
        /// Specifies Google Drive is used for the output storage.
        /// </summary>
        GoogleDrive,

        /// <summary>
        /// Specifies Dropbox is used for the output storage.
        /// </summary>
        Dropbox,

        /// <summary>
        /// Specifies OneDrive is used for the output storage.
        /// </summary>
        OneDrive,

        /// <summary>
        /// Specifies Amazon S3 is used for the output storage.
        /// </summary>
        S3,

        /// <summary>
        /// Specifies FTP is used for the output storage.
        /// </summary>
        Ftp,
    }
}