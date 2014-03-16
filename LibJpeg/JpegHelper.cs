using System;
using System.Collections.Generic;
using System.Drawing;


namespace BitMiracle.LibJpeg
{
	/// <summary>
	/// Singleton helper methods for quick one-liner access to LibJpeg.
	/// </summary>
	public class JpegHelper
	{
		#region Singleton
		// http://codereview.stackexchange.com/questions/79/implementing-a-singleton-pattern-in-c
		/// <summary>
		/// Singleton
		/// </summary>
		public static JpegHelper Current { get { return Nested.instance; } }

		class Nested
		{
			static Nested()
			{
			}

			internal static readonly JpegHelper instance = new JpegHelper();
		}
		#endregion

		/// <summary>
		/// One-liner to save Bitmaps to JPEG using LibJpeg.
		/// </summary>
		/// <param name="image">Bitmap</param>
		/// <param name="filename">Path to save to. Creates or overwrites if existing.</param>
		/// <param name="compression">Compression parameters.</param>
		public void Save(Bitmap image, string filename, CompressionParameters compression = null)
		{
			using(var jpeg = new JpegImage(image))
			{
				jpeg.Save(filename, compression);
			}
		}
	}
}
