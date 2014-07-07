/* Author: Luke Familo */
using System;
using System.Drawing;

namespace Screener
{
    /// <summary>
    /// Flip type for an image reflection.
    /// </summary>
    public enum FlipType
    {
        None,
        Horizontal,
        Verticle,
        Both
    }
    
    /// <summary>
    /// Holds a Fliptype and a rotation as a convienince way to store and change a Drawing.RotateFlipType.
    /// </summary>
    public class RotationFlipPair
    {
        #region Fields

        private FlipType flip;
        private int rotation;

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets or sets the current fliptype to use.
        /// </summary>
        public FlipType Flip
        { get { return flip; } set { flip = value; } }

        /// <summary>
        /// Gets or sets the current rotation to use 
        /// Only valid numbers are 0, 90, 180, and 360; any others will be rounded to these values.
        /// </summary>
        public int Rotation
        { 
            get { return rotation; } 
            set 
            { 
                rotation = value%360;
                if (rotation < 0) rotation -= 360;

                if (rotation < 45) rotation = 0;
                else if (rotation < 135) rotation = 90;
                else if (rotation < 225) rotation = 180;
                else if (rotation < 315) rotation = 270;
                else rotation = 0;
            } 
        }

        /// <summary>
        /// Gets the <code> Drawing.RotateFlipType </code> made from this objects Rotation and Flip type.
        /// </summary>
        public RotateFlipType DrawingFlipType
        {
            get
            {
                string s = "Rotate" + ((rotation == 0) ? "None" : rotation.ToString()) + "Flip";

                switch (flip)
                {
                    case FlipType.Horizontal: s += "X"; break;
                    case FlipType.Verticle: s += "Y"; break;
                    case FlipType.Both: s += "XY"; break;
                    case FlipType.None:
                    default: s += "None"; break;
                }

                return (RotateFlipType)Enum.Parse(typeof(RotateFlipType), s);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creats a new <code>RotateFlipPair</code>.
        /// </summary>
        /// <param name="flip"> Fliptype value of the pair (optional - defaults to <code>FlipType.None</code>). </param>
        /// <param name="rotation"> Rotation value of the pair (optional - defaults to <code>0</code>)</param>
        public RotationFlipPair(FlipType flip = FlipType.None, int rotation = 0)
        {
            Flip = flip;
            Rotation = rotation;
        }

        #endregion

        #region StaticConstructor

        /// <summary>
        /// Creates a new rotation flip pair based on the <code>Drawing.RotateFlipType</code>.
        /// NOTE - Slight error when converting : For any <code>RotateFlipType</code>, theres another <code>RotateFlipType</code> that has the exact same effect (and enum value).
        /// </summary>
        /// <param name="type"> The <code>Drawing.RotateFlipType</code>. </param>
        /// <returns> The new <code>RotateFlipPair</code>. </returns>
        public static RotationFlipPair FromDrawingFlipType(RotateFlipType type)
        {
            FlipType flip = FlipType.None;
            int rotation = 0;

            switch (type)
            {
                case RotateFlipType.Rotate180FlipNone:
                case RotateFlipType.Rotate180FlipX:
                case RotateFlipType.Rotate180FlipXY:
                case RotateFlipType.Rotate180FlipY:
                    rotation = 180; break;

                case RotateFlipType.Rotate270FlipNone:
                case RotateFlipType.Rotate270FlipX:
                case RotateFlipType.Rotate270FlipXY:
                case RotateFlipType.Rotate270FlipY:
                    rotation = 270; break;
                // Rest of the cases have same values as above. (cause the rotation would be equal).
                default: rotation = 0; break;
            }

            switch (type)
            {
                case RotateFlipType.Rotate180FlipNone:
                case RotateFlipType.Rotate270FlipNone:
                default: flip = FlipType.None; break;

                case RotateFlipType.Rotate180FlipX:
                case RotateFlipType.Rotate270FlipX:
                    flip = FlipType.Horizontal; break;

                case RotateFlipType.Rotate180FlipXY:
                case RotateFlipType.Rotate270FlipXY:
                    flip = FlipType.Both; break;

                case RotateFlipType.Rotate180FlipY:
                case RotateFlipType.Rotate270FlipY:
                    flip = FlipType.Verticle; break;
                // Rest of the cases have same values as above. (cause the rotation would be equal).
            }
            return new RotationFlipPair(flip, rotation);
        }

        #endregion
    }
}
