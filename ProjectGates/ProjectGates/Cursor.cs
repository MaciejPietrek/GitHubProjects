using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace ProjectGates
{
	class Cursor : Drawable
	{
		private Sprite sprite;
		private Grid grid;
		private Texture Texture
		{
			get
			{
				return sprite.Texture;
			}
			set
			{
				sprite.Texture = Texture;
			}
		}

		public Cursor(Grid grid, Texture texture)
		{
			this.grid = grid;
			this.sprite = new Sprite();
			this.sprite.Texture = texture;
			this.sprite.Color = new Color(0, 0, 0, 30);
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			Vector2i tmp = SFML.Window.Mouse.GetPosition();
			this.sprite.Position = grid.OnGrid(new Vector2f(tmp.X - (float)0.5 * sprite.Texture.Size.X, tmp.Y - (float)0.5 * sprite.Texture.Size.Y));
			this.sprite.Draw(target, states);
		}
	}
}
