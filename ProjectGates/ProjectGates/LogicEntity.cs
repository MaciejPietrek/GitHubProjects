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
		private float rotation;
		private Vector2f center;

		private List<InputPin> inputPins;
		private List<OutputPin> outputPins;
		private Grid grid;

		private Sprite background;
		private Sprite body;

		private Vector2f BodyRelativePosition()
		{
			return background.Position + (float)0.5 * new Vector2f(background.Texture.Size.X, background.Texture.Size.Y) - (float)0.5 * new Vector2f(body.Texture.Size.X, body.Texture.Size.Y);
		}
		private Vector2f inputPinPosition(int index, int numberOfPins)
		{
			return new Vector2f(background.Position.X, (float)(index + 1) / (numberOfPins + 1) * background.Texture.Size.Y + background.Position.Y - (float)0.5 * GraphicElements.PinTextureError.Size.Y);
		}
		private Vector2f outputPinPosition(int index, int numberOfPins)
		{
			return new Vector2f(background.Position.X + background.Texture.Size.X - GraphicElements.PinTextureError.Size.X, (float)(index + 1) / (numberOfPins + 1) * background.Texture.Size.Y + background.Position.Y - (float)0.5 * GraphicElements.PinTextureError.Size.Y);
		}
		
		public Vector2f Position
		{
			get
			{
				return background.Position;
			}
			set
			{
				background.Position = grid.OnGrid(value);
				body.Position = BodyRelativePosition();
				for (int i = 0; i < inputPins.Count; i++)
					inputPins[i].Position = inputPinPosition(i, inputPins.Count);
				for (int i = 0; i < outputPins.Count; i++)
					outputPins[i].Position = outputPinPosition(i, outputPins.Count);
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
				background.Rotation = tmp;
				body.Rotation = tmp;
			}
		}

		public LogicEntity(Grid grid, Vector2f position, Vector2i pinsSize)
		{
			int newInSize = pinsSize.X;
			int newOutSize = pinsSize.Y;

			inputPins	= new List<InputPin>(newInSize);
			outputPins	= new List<OutputPin>(newOutSize);

			background	= new Sprite();
			body		= new Sprite();

			background.Texture	= GraphicElements.BackgroundTexture;
			body.Texture		= GraphicElements.BodyTexture;

			body.Position = BodyRelativePosition();

			
			this.grid = grid;
			background.Position = grid.OnGrid(position);
			body.Position = BodyRelativePosition();

			for (int i = 0; i < newInSize; i++)
			{
				inputPins.Add(new InputPin(this));
				inputPins.Last().Position = inputPinPosition(i, newInSize);
			}

			for (int i = 0; i < newOutSize; i++)
			{
				outputPins.Add(new OutputPin(this));
				outputPins.Last().Position = outputPinPosition(i, newOutSize);
			}
		}
		public void Draw(RenderTarget renderTarget, RenderStates renderStates)
		{
			background.Draw(renderTarget, renderStates);
			body.Draw(renderTarget, renderStates);

			for(int index = 0; index < inputPins.Count; index++)
				inputPins[index].Draw(renderTarget, renderStates);

			for (int index = 0; index < outputPins.Count; index++)
				outputPins[index].Draw(renderTarget, renderStates);
		}
	}
}
