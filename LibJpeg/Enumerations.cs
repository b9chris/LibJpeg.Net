using System;
using System.Collections.Generic;
using System.Text;

namespace BitMiracle.LibJpeg
{
	/// <summary>
	/// Known color spaces.
	/// </summary>
#if EXPOSE_LIBJPEG
	public
#endif
	enum Colorspace
	{
		/// <summary>
		/// Unspecified colorspace
		/// </summary>
		Unknown,

		/// <summary>
		/// Grayscale
		/// </summary>
		Grayscale,

		/// <summary>
		/// RGB
		/// </summary>
		RGB,

		/// <summary>
		/// YCbCr (also known as YUV)
		/// </summary>
		YCbCr,

		/// <summary>
		/// CMYK
		/// </summary>
		CMYK,

		/// <summary>
		/// YCbCrK
		/// </summary>
		YCCK
	}

	/// <summary>
	/// Chroma Subsampling
	/// 
	/// RGB and YCbCr only.
	/// </summary>
#if EXPOSE_LIBJPEG
	public
#endif
	enum Subsampling
	{
		/// <summary>
		/// No subsampling. Uses 4:4:4 (1x1, 1x1, 1x1), maximizing preservation of edges.
		/// </summary>
		HighDetail_4_4_4 = 0,

		/// <summary>
		/// Medium subsampling. Uses 4:2:2 (2x1, 1x1, 1x1), reducing file size by 1/3 at the cost of fuzzier edges.
		/// Reduces the horizontal sampling of changes in luminance.
		/// </summary>
		MediumDetail_4_2_2 = 1,

		/// <summary>
		/// High subsampling. Uses 4:1:1 (2x2, 1x1, 1x1), reducing file size at the cost of fuzzy edges and denatured colors.
		/// Reduces the sampling of changes in luminance, both horizontally and vertically.
		/// </summary>
		LowDetail_4_1_1 = 2,

		/// <summary>
		/// Manual subsampling. Requires setting YHSamp, YVSamp, CbHSamp, CbVSamp, CrHSamp, CrVSamp.
		/// </summary>
		Manual = 3
	}


	/// <summary>
	/// DCT/IDCT algorithm options.
	/// </summary>
	enum DCTMethod
	{
		IntegerSlow,     /* slow but accurate integer algorithm */
		IntegerFast,     /* faster, less accurate integer method */
		Float            /* floating-point: accurate, fast on fast HW */
	}

	/// <summary>
	/// Dithering options for decompression.
	/// </summary>
	enum DitherMode
	{
		None,               /* no dithering */
		Ordered,            /* simple ordered dither */
		FloydSteinberg      /* Floyd-Steinberg error diffusion dither */
	}
}
