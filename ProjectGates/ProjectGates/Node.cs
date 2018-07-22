using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace ProjectGates
{
	class Node : Connectable, Drawable, IMoveable
	{
		private Vector2f center;
		private float rotation;
		//Fields and attributes
		private Grid grid;
		protected Sprite sprite;
		//Interface Drawable
		public void Draw(RenderTarget renderTarget, RenderStates renderStates)
		{
			sprite.Draw(renderTarget, renderStates);
		}
		//Interface IMoveable
		public Vector2f Position
		{
			get
			{
				return sprite.Position;
			}
			set
			{
				sprite.Position = grid.OnGrid(value);
			}
		}
		public float Rotation
		{
			get
			{
				return rotation;
			}
			set
			{
				float tmp = value % 360;
				rotation = tmp;
			}
		}
		//Constructors
		public Node(Grid grid, Vector2f position)
		{
			this.grid = grid;
			this.sprite = new Sprite();
			this.sprite.Position = grid.OnGrid(position);
			this.sprite.Texture = GraphicElements.NodeTexture;
		}
	}
}
