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
	class Grid : Drawable
	{
		private float width;
		private float height;
		private float lineWidth;

		private RectangleShape horizontalLines;
		private RectangleShape verticalLines;

		private Vector2f horizontalLineMoveVector;
		private Vector2f verticalLineMoveVector;

		private Vector2f startingPosition;
		private Vector2f endPosition;

		private RenderWindow window;

		public Grid(float height, float width, int lineWidth, Color color, RenderWindow window)
		{
			this.width	= width;
			this.height		= height;
			this.lineWidth	= lineWidth;
			this.window		= window;

			startingPosition	= new Vector2f(0, 0);
			endPosition			= new Vector2f(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height);

			horizontalLines		= new RectangleShape(new Vector2f(endPosition.X, lineWidth));
			verticalLines		= new RectangleShape(new Vector2f(lineWidth, endPosition.Y));

			horizontalLineMoveVector	= new Vector2f(0, height);
			verticalLineMoveVector		= new Vector2f(width, 0);

			horizontalLines.FillColor	= color;
			verticalLines.FillColor		= color;
		}
		public void Draw(RenderTarget target, RenderStates states)
		{
			target.SetView(target.DefaultView);
			horizontalLines.Position = startingPosition;
			verticalLines.Position = startingPosition;

			while(horizontalLines.Position.Y < endPosition.Y)
			{
				horizontalLines.Draw(target, states);
				horizontalLines.Position += horizontalLineMoveVector;
			}
			while (verticalLines.Position.X < endPosition.X)
			{
				verticalLines.Draw(target, states);
				verticalLines.Position += verticalLineMoveVector;
			}
		}
		public Vector2f OnGrid(Vector2f position)
		{
			Vector2f tmp = position - position % this + new Vector2f(lineWidth / 2 + lineWidth % 2, lineWidth / 2 + lineWidth % 2);
			return window.MapPixelToCoords(new Vector2i((int)tmp.X, (int)tmp.Y));
		}
		static public Vector2f operator % (Vector2f vector, Grid grid)
		{
			return new Vector2f(vector.X % grid.width, vector.Y % grid.height);
		}
	}
}
