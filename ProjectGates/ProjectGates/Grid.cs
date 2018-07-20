using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace ProjectGates
{
	class Grid : SFML.Graphics.Drawable
	{
		private int height;
		private int width;
		private int size;

		private RectangleShape verticalLines;
		private RectangleShape horizontalLines;


		public Grid(int newHeight, int newWidth, SFML.Graphics.Color newColor, int size)
		{
			height = newHeight;
			width = newWidth;
			this.size = size;
			verticalLines = new RectangleShape(new Vector2f(VideoMode.DesktopMode.Width, size));
			horizontalLines = new RectangleShape(new Vector2f(size, VideoMode.DesktopMode.Height));

			verticalLines.FillColor = newColor;
			horizontalLines.FillColor = newColor;
		}

		public void Draw(SFML.Graphics.RenderTarget renderTarget, SFML.Graphics.RenderStates renderStates)
		{
			RenderWindow mainWindow = (RenderWindow)renderTarget;
			Vector2f tmp = mainWindow.MapPixelToCoords(new Vector2i(0, 0));
			
			horizontalLines.Position = new Vector2f(tmp.X, tmp.Y);
			verticalLines.Position = new Vector2f(tmp.X, tmp.Y);

			while (verticalLines.Position.Y < VideoMode.DesktopMode.Height)
			{
				verticalLines.Draw(renderTarget, renderStates);
				verticalLines.Position += new Vector2f(0, height);
			}
			while(horizontalLines.Position.X < VideoMode.DesktopMode.Width)
			{
				horizontalLines.Draw(renderTarget, renderStates);
				horizontalLines.Position += new Vector2f(width, 0);
			}
		}

		public Vector2f PositionAcordingToGrid(RenderWindow window, Vector2f position)
		{
			return PositionAcordingToGrid(window, position.X, position.Y);
		}
		public Vector2f PositionAcordingToGrid(RenderWindow window, float X, float Y)
		{
			Vector2i tmp1 = window.MapCoordsToPixel(new Vector2f(X, Y));
			Vector2i tmp2 = new Vector2i(tmp1.X - tmp1.X % width + size / 2 + size % 2, tmp1.Y - tmp1.Y % height + size / 2 + size % 2);
			return window.MapPixelToCoords(tmp2);
		}
	}
}
