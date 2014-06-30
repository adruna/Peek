namespace Screener
{
    /// <summary>
    /// Specifies an object that recieves the kinds of user input that a FileProperties form takes.
    /// </summary>
    public interface IReceivesImageFileProperties
    {
        /// <summary>
        /// Gets or Sets the file format of the image.
        /// </summary>
        System.Drawing.Imaging.ImageFormat FileFormat { get; set; }

        /// <summary>
        /// Gets or sets the SaveDirectory folder of the file.
        /// </summary>
        System.IO.DirectoryInfo SaveDirectory { get; set; }

        /// <summary>
        /// Gets or sets the <code>RotationFlipPair</code> to use when rotating the image.
        /// </summary>
        RotationFlipPair FlipPair { get; set; }

        /// <summary>
        /// Gets or sets the root filename to use.
        /// </summary>
        System.String RootName { get; set; }

        /// <summary>
        /// Re-enables this object when property modifcations are complete.
        /// </summary>
        void Enable();
    }
}
