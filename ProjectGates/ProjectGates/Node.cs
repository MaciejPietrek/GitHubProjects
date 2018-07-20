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
		//Fields and attributes

		protected Sprite sprite;

		public Vector2f Position
		{
			get
			{
				return sprite.Position;
			}
			set
			{
				sprite.Position = value;
			}
		}

		//Interface Drawable

		public void Draw(RenderTarget renderTarget, RenderStates renderStates)
		{
			sprite.Draw(renderTarget, renderStates);
		}
		
		//Interface IMoveable

		public void MoveTo(Vector2f realocationVector)
		{
			sprite.Position = realocationVector;
		}
		public void MoveBy(Vector2f realocationVector)
		{
			sprite.Position += realocationVector;
		}

		//Constructors

		public Node()
		{
			sprite = new Sprite();
			sprite.Texture = GraphicElements.NodeTexture;
		}
	}
}
