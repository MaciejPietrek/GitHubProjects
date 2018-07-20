using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace ProjectGates
{
	static class GraphicElements
	{
		private static Texture bodyTexture;
		private static Texture pinTextureLow;
		private static Texture pinTextureHigh;
		private static Texture pinTextureError;
		private static Texture nodeTexture;

		private static Texture andTexture;
		private static Texture nandTexture;
		private static Texture orTexture;
		private static Texture norTexture;
		private static Texture xorTexture;
		private static Texture xnorTexture;
		private static Texture notTexture;

		private static Font genericFont;
		private static Texture backgroundTexture;


		public static Texture BodyTexture
		{
			get
			{
				return bodyTexture;
			}
		}
		public static Texture PinTextureLow
		{
			get
			{
				return pinTextureLow;
			}
		}
		public static Texture PinTextureHigh
		{
			get
			{
				return pinTextureHigh;
			}
		}
		public static Texture PinTextureError
		{
			get
			{
				return pinTextureError;
			}
		}
		public static Texture NodeTexture
		{
			get
			{
				return nodeTexture;
			}
		}

		public static Texture AndTexture
		{
			get
			{
				return andTexture;
			}
		}
		public static Texture NandTexture
		{
			get
			{
				return nandTexture;
			}
		}
		public static Texture OrTexture
		{
			get
			{
				return orTexture;
			}
		}
		public static Texture NorTexture
		{
			get
			{
				return norTexture;
			}
		}
		public static Texture XorTexture
		{
			get
			{
				return xorTexture;
			}
		}
		public static Texture XnorTexture
		{
			get
			{
				return xnorTexture;
			}
		}
		public static Texture NotTexture
		{
			get
			{
				return notTexture;
			}
		}

		public static Font GenericFont
		{
			get
			{
				return genericFont;
			}
		}
		public static Texture BackgroundTexture
		{
			get
			{
				return backgroundTexture;
			}
		}

		static GraphicElements()
		{
			try
			{
				bodyTexture		= new Texture(@"Textures\bodyTexture.png");
				pinTextureLow	= new Texture(@"Textures\pinTextureLow.png");
				pinTextureHigh	= new Texture(@"Textures\pinTextureHigh.png");
				pinTextureError = new Texture(@"Textures\pinTextureError.png");
				nodeTexture		= new Texture(@"Textures\nodeTexture.png");

				andTexture		= new Texture(@"Textures\andTexture.png");
				nandTexture		= new Texture(@"Textures\nandTexture.png");
				orTexture		= new Texture(@"Textures\orTexture.png");
				norTexture		= new Texture(@"Textures\norTexture.png");
				xorTexture		= new Texture(@"Textures\xorTexture.png");
				xnorTexture		= new Texture(@"Textures\xnorTexture.png");
				notTexture		= new Texture(@"Textures\notTexture.png");

				//genericFont		= new Font(@"Textures\genericFont.png");
				backgroundTexture = new Texture(@"Textures\backgroundTexture.png");
			}
			catch(SFML.LoadingFailedException e)
			{
				Console.WriteLine("Check if all texture files are present in folder Textures");
			}
		}
	}
}
