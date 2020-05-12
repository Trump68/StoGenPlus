using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Frames
{
   
        //
        // Summary:
        //     Specifies the size mode of the image contained within a DevExpress.XtraEditors.PictureEdit
        //     or DevExpress.XtraEditors.ImageEdit editor.
        public enum PictureSizeMode
        {
            //
            // Summary:
            //     A picture is not stretched.
            Clip = 0,
            //
            // Summary:
            //     A picture is stretched in order to fit within the area of an editor (or editor's
            //     dropdown window).
            Stretch = 1,
            //
            // Summary:
            //     A picture is stretched proportionally. The picture fits within the area of an
            //     editor (or editor's dropdown window) at least in one direction.
            Zoom = 2,
            //
            // Summary:
            //     A picture is stretched horizontally. Its height remains unchanged.
            StretchHorizontal = 3,
            //
            // Summary:
            //     A picture is stretched vertically. Its width remains unchanged.
            StretchVertical = 4,
            //
            // Summary:
            //     An image is displayed as is if its actual size is smaller than the size of the
            //     container. If the image size is larger than the container's size, the image is
            //     shrunk proportionally to fit the container's bounds.
            Squeeze = 5
        }
    
}
