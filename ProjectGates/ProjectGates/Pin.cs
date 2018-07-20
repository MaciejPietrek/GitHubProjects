using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace ProjectGates
{
	abstract class Pin : Connectable, Drawable, IMoveable
	{
		//Fields and attributes

		private Sprite sprite;

		private LogicEntity owner;
		
		public LogicEntity Owner
		{
			get
			{
				return owner;
			}
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

		protected Pin(LogicEntity owner)
		{
			this.owner = owner;
			sprite = new Sprite();
			sprite.Texture = GraphicElements.PinTextureError;
		}
		public void Draw(RenderTarget renderTarget, RenderStates renderStates)
		{
			sprite.Draw(renderTarget, renderStates);
		}
	}

	sealed class InputPin : Pin
	{
		//Constructors

		public InputPin(LogicEntity owner)
			: base(owner)
		{

		}
	}

	sealed class OutputPin : Pin
	{
		LogicLevel logicLevel;

		//Constructors

		public OutputPin(LogicEntity owner)
			: base(owner)
		{
			logicLevel = LogicLevel.ERROR;
		}
	}
}
