using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StoGenClasses
{
   // [Serializable]
    public class PictureItem
    {
        public Texture2D image { get; set; }
        public PictureSourceProps Props { get; set; }
        public PictureItem()
        {
            this.Props = new PictureSourceProps();
        }
    }
    //
    // Summary:
    //     Specifies alignment of content on the drawing surface.

    public enum ContentAlignment
    {
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned on the left.
        TopLeft = 1,
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned at the center.
        TopCenter = 2,
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned on the right.
        TopRight = 4,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned on the
        //     left.
        MiddleLeft = 16,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned at the
        //     center.
        MiddleCenter = 32,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned on the
        //     right.
        MiddleRight = 64,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned on the
        //     left.
        BottomLeft = 256,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned at the
        //     center.
        BottomCenter = 512,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned on the
        //     right.
        BottomRight = 1024
    }
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
    //
    // Summary:
    //     Specifies how much an image is rotated and the axis used to flip the image.
    public enum RotateFlipType
    {
        //
        // Summary:
        //     Specifies no clockwise rotation and no flipping.
        RotateNoneFlipNone = 0,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate180FlipXY = 0,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation without flipping.
        Rotate90FlipNone = 1,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate270FlipXY = 1,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation without flipping.
        Rotate180FlipNone = 2,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a horizontal and vertical flip.
        RotateNoneFlipXY = 2,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation without flipping.
        Rotate270FlipNone = 3,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate90FlipXY = 3,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a horizontal flip.
        RotateNoneFlipX = 4,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a vertical flip.
        Rotate180FlipY = 4,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a horizontal flip.
        Rotate90FlipX = 5,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a vertical flip.
        Rotate270FlipY = 5,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a horizontal flip.
        Rotate180FlipX = 6,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a vertical flip.
        RotateNoneFlipY = 6,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a horizontal flip.
        Rotate270FlipX = 7,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a vertical flip.
        Rotate90FlipY = 7
    }
    public class PictureSourceDataProps : PictureSourceProps
    {

        public PictureSourceDataProps() : base()
        {

        }

        public PictureSourceDataProps(string fnname)
            : base(fnname)
        {

        }

        public PictureSourceDataProps(string fnname, PictureProps position) : base(fnname, position)
        {

        }

        public string RawData { get; set; }

    }
    public class PictureSourceProps : PictureProps
    {
        internal bool SizeChanged = false;



        //public System.Windows.Point ScreenCenter { get; internal set; }

        public PictureSourceProps() : base() { }
        public PictureSourceProps(PictureProps sourceApperance)
            : this()
        {
            this.Assign(sourceApperance);
        }
        public PictureSourceProps(PictureSourceProps sourceApperance)
            : this()
        {
            this.Assign(sourceApperance);
        }
        public void Assign(PictureProps sourceApperance)
        {
            if (sourceApperance.X != 0) this.X = sourceApperance.X;
            if (sourceApperance.Y != 0) this.Y = sourceApperance.Y;
            if (sourceApperance.SizeX != 0) this.SizeX = sourceApperance.SizeX;
            if (sourceApperance.SizeY != 0) this.SizeY = sourceApperance.SizeY;
            this.Z = sourceApperance.Z;
            this.Level = sourceApperance.Level;
            this.Rotate = sourceApperance.Rotate;
            this.Align = sourceApperance.Align;
            this.SizeMode = sourceApperance.SizeMode;
            this.BackColor = sourceApperance.BackColor;
            this.BackFileName = sourceApperance.BackFileName;
            this.NextCadre = sourceApperance.NextCadre;
            this.Opacity = sourceApperance.Opacity;
            this.SetName = sourceApperance.SetName;
            this.Flip = sourceApperance.Flip;
            this.Merge = sourceApperance.Merge;
            this.Timer = sourceApperance.Timer;
            this.Timer2 = sourceApperance.Timer2;
            this.Blur = sourceApperance.Blur;
            this.isVideo = sourceApperance.isVideo;
            this.Active = sourceApperance.Active;
            this.OnlyName = sourceApperance.OnlyName;
            this.Description = sourceApperance.Description;
            this.isMain = sourceApperance.isMain;
            this.Reload = sourceApperance.Reload;
            this.Flash = sourceApperance.Flash;
            this.ClipH = sourceApperance.ClipH;
            this.ClipW = sourceApperance.ClipW;
            this.ClipX = sourceApperance.ClipX;
            this.ClipY = sourceApperance.ClipY;
            this.Transition = sourceApperance.Transition;
            this.ParFlip = sourceApperance.ParFlip;
            this.Animations.Clear();
            this.Animations.AddRange(sourceApperance.Animations);
            this.Parent = sourceApperance.Parent;
        }
        public void Assign(PictureSourceProps sourceApperance)
        {
            this.Assign(sourceApperance as PictureProps);
            this.FileName = sourceApperance.FileName;
        }
        public PictureSourceProps(string fn, PictureProps sourceApperance)
            : this(sourceApperance)
        {
            this.FileName = fn;
        }
        public PictureSourceProps(string fn)
            : this()
        {
            this.FileName = fn;
        }

    }
    public class PictureProps : PictureBaseProp
    {

        public string FileName { get; set; }
        private string _Name = string.Empty;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_Name))
                {
                    return this.FileName;
                }
                return _Name;
            }
            set { _Name = value; }
        }
        public string Description = string.Empty;
        public string OnlyName
        {
            get
            {
                return _Name;
            }
            set { _Name = value; }
        }
        public string Parent { get; set; }
        internal string SetName { get; set; }
        public bool AutoShift { get; set; }


        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public bool ScreenStretch { get; set; } = false;
        public int Opacity { get; set; } = 100;

        public double NextCadre { get; set; }

        public int Rotate { get; set; }

        public int Zoom
        {
            get { return Z; }
            set { Z = value; }
        }
        public ContentAlignment Align { get; set; }
        public PictureSizeMode SizeMode { get; set; }
        public string BackFileName { get; set; }
        public System.Drawing.Color BackColor { get; set; }
        public RotateFlipType Flip { get; set; }


        public PictureProps()
        {
            BackColor = System.Drawing.Color.Transparent;
            this.Align = ContentAlignment.TopLeft;
            this.SizeMode = PictureSizeMode.Clip;
            this.Zoom = 100;
            this.Rotate = 0;
            //this.RateMax = AnimationRate.VeryFast;
            //this.RateMin = AnimationRate.VerySlow;
            //this.Rate = AnimationRate.Default;
            this.Flip = RotateFlipType.RotateNoneFlipNone;
        }
        internal bool isMain = false;
        public string Flash = null;
        public string Transition = null;
        public string ParFlip = null;
        public List<AP> Animations = new List<AP>();
        private AP _CurrentAnimation;
        public AP CurrentAnimation
        {
            get
            {
                if (_CurrentAnimation == null)
                {
                    _CurrentAnimation = Animations.FirstOrDefault();
                }
                return _CurrentAnimation;
            }
        }
    }
    public class AP
    {
        public AP() { }
        public AP(string file) : this()
        {
            this.File = file;
        }
        public string File { set; get; }
        public int AR { set; get; } = 100;//animation ratio
        public int AV { set; get; } = 100;//animation volume
        public double APS { set; get; } //animation start pos
        public double APE { set; get; } //animation end pos
        public int AWS { set; get; } //animation wait start
        public int AWE { set; get; } //animation wait end
        public int ALM { set; get; } = -1;//animation loop mode
        public int ALC { set; get; } = 0; //loop count, 0 - endless
        public string Source { get; set; } = null;
    }
    public class PictureBaseProp
    {
        public PictureBaseProp()
        {

        }
        public PictureBaseProp(int x, int y, int zoom, PicLevel level)
        {
            this.X = x;
            this.Y = y;
            this.Z = zoom;
            this.Level = level;
        }
        public double ClipW { get; set; }
        public double ClipH { get; set; }
        public double ClipX { get; set; }
        public double ClipY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public PicLevel Level { get; set; } = PicLevel.None;
        public bool Merge = false;
        public int Timer = 0;
        public int Timer2 = 0;
        public int Blur = 0;
        public bool isVideo = false;
        public bool Active = true;
        public bool Reload = false;
    }
    public enum PicLevel : int
    {
        None = -1,
        Background = 0,
        OnBackground = 1,
        UnderActor0 = 2,
        Actor0 = 3,
        OnActor0 = 4,
        UnderActor1 = 5,
        Actor1 = 6,
        OnActor1 = 7,
        UnderActor2 = 8,
        Actor2 = 9,
        OnActor2 = 10,
        Foreground = 11,
        L01 = 12,
        L02 = 13,
        L03 = 14,
        L04 = 15,
        L05 = 16,
        L06 = 17,
        L07 = 18,
        L08 = 19,
        L09 = 20
    }
    public class AlignData
    {
        public string Parent;
        public string Name;
        public string Tag;
        public bool Processed = false;
        public DifData Im;
        public seIm Fact;
        public AlignData(string name) : this(name, null, null, null) { }
        public AlignData(string name, DifData im) : this(name, null, null, im) { }
        public AlignData(string name, string parent) : this(name, parent, null, null) { }
        public AlignData(string name, string parent, DifData im) : this(name, parent, null, im) { }
        public AlignData(string name, string parent, string tag, DifData im)
        {
            Parent = parent;
            Name = name;
            Tag = tag;
            Im = im;
        }
    }

}
