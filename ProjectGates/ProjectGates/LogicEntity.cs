using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace ProjectGates
{
	class LogicEntity : IMoveable, Drawable
	{
		private List<InputPin> inputPins;
		private List<OutputPin> outputPins;
		private RenderWindow window;
		private Grid grid;

		/*
		public List<InputPin> InputPins
		{
			get
			{
				return inputPins;
			}
		}
		public List<OutputPin> OutputPins
		{
			get
			{
				return outputPins;
			}
		}
		*/

		private Sprite background;
		private Sprite body;

		private Vector2f BodyRelativePosition()
		{
			return background.Position + (float)0.5 * new Vector2f(background.Texture.Size.X, background.Texture.Size.Y) - (float)0.5 * new Vector2f(body.Texture.Size.X, body.Texture.Size.Y);
		}

		public void MoveTo(Vector2f realocationVector)
		{
			background.Position = realocationVector;
			body.Position = BodyRelativePosition();
		}
		public void MoveBy(Vector2f realocationVector)
		{
			background.Position += realocationVector;
			body.Position = BodyRelativePosition();
		}

		public LogicEntity(int newInSize, int newOutSize)
		{
			inputPins	= new List<InputPin>();
			outputPins	= new List<OutputPin>();

			background	= new Sprite();
			body		= new Sprite();

			background.Texture = GraphicElements.BackgroundTexture;
			body.Texture = GraphicElements.AndTexture;

			body.Position = BodyRelativePosition();
		}
		public LogicEntity(int newInSize, int newOutSize, Vector2f mousePosition, Grid grid, RenderWindow window)
			: this(newInSize, newOutSize)
		{
			this.window = window;
			this.grid = grid;
			background.Position = mousePosition;
			body.Position = BodyRelativePosition();
		}

		public void Draw(RenderTarget renderTarget, RenderStates renderStates)
		{
			background.Draw(renderTarget, renderStates);
			body.Draw(renderTarget, renderStates);
			for(int index = 0; index < inputPins.Count; index++)
			{
				inputPins[index].Draw(renderTarget, renderStates);
			}
			for (int index = 0; index < outputPins.Count; index++)
			{
				outputPins[index].Draw(renderTarget, renderStates);
			}
		}
	}
}
