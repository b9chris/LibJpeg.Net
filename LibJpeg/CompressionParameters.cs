using System;
using System.Collections.Generic;
using System.Text;

using BitMiracle.LibJpeg.Classic;

namespace BitMiracle.LibJpeg
{
	/// <summary>
	/// Parameters of compression.
	/// </summary>
	/// <remarks>Being used in <see cref="M:BitMiracle.LibJpeg.JpegImage.WriteJpeg(System.IO.Stream,BitMiracle.LibJpeg.CompressionParameters)"/></remarks>
#if EXPOSE_LIBJPEG
	public
#endif
	class CompressionParameters
	{
		/// <summary>
		/// Quality. 0-100, 100 being best.
		/// </summary>
		protected int m_quality = 75;

		/// <summary>
		/// Smoothing factor
		/// </summary>
		protected int m_smoothingFactor;

		/// <summary>
		/// Whether to emit a Progressive JPEG; defaults to false, not Progressive.
		/// </summary>
		protected bool m_simpleProgressive;


		/// <summary>
		/// Initializes a new instance of the <see cref="CompressionParameters"/> class.
		/// </summary>
		public CompressionParameters()
		{
			Subsampling =
				//LibJpeg.Subsampling.HighDetail_4_4_4;
				LibJpeg.Subsampling.LowDetail_4_1_1;
		}

		internal CompressionParameters(CompressionParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException("parameters");

			m_quality = parameters.m_quality;
			m_smoothingFactor = parameters.m_smoothingFactor;
			m_simpleProgressive = parameters.m_simpleProgressive;
			
			YHSamp = parameters.YHSamp;
			YVSamp = parameters.YVSamp;
			CbHSamp = parameters.CbHSamp;
			CbVSamp = parameters.CbVSamp;
			CrHSamp = parameters.CrHSamp;
			CrVSamp = parameters.CrVSamp;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			CompressionParameters parameters = obj as CompressionParameters;
			if (parameters == null)
				return false;

			return (m_quality == parameters.m_quality &&
					m_smoothingFactor == parameters.m_smoothingFactor &&
					m_simpleProgressive == parameters.m_simpleProgressive);
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms 
		/// and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>
		/// Gets or sets the quality of JPEG image.
		/// </summary>
		/// <remarks>Default value: 75<br/>
		/// The quality value is expressed on the 0..100 scale.
		/// </remarks>
		/// <value>The quality of JPEG image.</value>
		public int Quality
		{
			get { return m_quality; }
			set { m_quality = value; }
		}

		/// <summary>
		/// Gets or sets the coefficient of image smoothing.
		/// </summary>
		/// <remarks>Default value: 0<br/>
		/// If non-zero, the input image is smoothed; the value should be 1 for
		/// minimal smoothing to 100 for maximum smoothing.
		/// </remarks>
		/// <value>The coefficient of image smoothing.</value>
		public int SmoothingFactor
		{
			get { return m_smoothingFactor; }
			set { m_smoothingFactor = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether to write a progressive-JPEG file.
		/// </summary>
		/// <value>
		/// <c>true</c> for writing a progressive-JPEG file; <c>false</c> 
		/// for non-progressive JPEG files.
		/// </value>
		public bool SimpleProgressive
		{
			get { return m_simpleProgressive; }
			set { m_simpleProgressive = value; }
		}

		/// <summary>
		/// Luma (Luminance, Brightness, Y) horizontal chroma subsampling
		/// </summary>
		public int YHSamp { get; set; }

		/// <summary>
		/// Luma (Luminance, Brightness, Y) vertical chroma subsampling
		/// </summary>
		public int YVSamp { get; set; }

		/// <summary>
		/// Blue difference (Cb) horizontal chroma subsampling
		/// </summary>
		public int CbHSamp { get; set; }

		/// <summary>
		/// Blue difference (Cb) vertical chroma subsampling
		/// </summary>
		public int CbVSamp { get; set; }

		/// <summary>
		/// Red difference (Cr) horizontal chroma subsampling
		/// </summary>
		public int CrHSamp { get; set; }

		/// <summary>
		/// Red difference (Cr) vertical chroma subsampling
		/// </summary>
		public int CrVSamp { get; set; }

		/// <summary>
		/// Chroma Subsampling. Affects RGB and YCbCr images only. Defaults to HighDetail.
		/// Reflects the underlying RHSamp, RVSamp, GHSamp, etc values - changing them to match HighDetail will cause this property
		/// to return HighDetail; changing them to other settings will cause this property to return Manual.
		/// </summary>
		public Subsampling Subsampling
		{
			get
			{
				if (CbHSamp == 1 && CbVSamp == 1 && CrHSamp == 1 && CrVSamp == 1)
				{
					if (YHSamp == 1 && YVSamp == 1)
						return LibJpeg.Subsampling.HighDetail_4_4_4;

					if (YHSamp == 2)
					{
						if (YVSamp == 2)
							return LibJpeg.Subsampling.LowDetail_4_1_1;
						if (YVSamp == 1)
							return LibJpeg.Subsampling.MediumDetail_4_2_2;
					}
				}

				return Subsampling.Manual;
			}
			set
			{
				switch(value)
				{
					case Subsampling.HighDetail_4_4_4:
						YHSamp = 1; YVSamp = 1;
						CbHSamp = 1; CbVSamp = 1;
						CrHSamp = 1; CrVSamp = 1;
						break;
					case Subsampling.MediumDetail_4_2_2:
						YHSamp = 2; YVSamp = 1;
						CbHSamp = 1; CbVSamp = 1;
						CrHSamp = 1; CrVSamp = 1;
						break;
					case Subsampling.LowDetail_4_1_1:
						YHSamp = 2; YVSamp = 2;
						CbHSamp = 1; CbVSamp = 1;
						CrHSamp = 1; CrVSamp = 1;
						break;
				}
			}
		}
	}
}