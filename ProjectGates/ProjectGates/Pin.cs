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
		public float Rotation
		{
			get
			{
				return 0;
			}
			set
			{

			}
		}
		//Constructors
		protected Pin(LogicEntity owner)
		{
			this.owner = owner;
			this.sprite = new Sprite();
			this.sprite.Texture = GraphicElements.PinTextureError;
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
