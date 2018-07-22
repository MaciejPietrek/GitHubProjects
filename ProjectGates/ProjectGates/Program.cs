using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace ProjectGates
{
	class Program
	{
		static RenderWindow mainWindow = new RenderWindow(VideoMode.DesktopMode, "ProjectGates", Styles.Fullscreen);
		static View mainView = new View(mainWindow.DefaultView);
		static List<LogicEntity> logicEntities = new List<LogicEntity>();
		static List<Node> nodes = new List<Node>();
		static Grid mainGrid = new Grid(25, 25, 2, new Color(200, 200, 200), mainWindow);
		static Grid nodeGrid = new Grid(5, 5, 1, new Color(240, 240, 240), mainWindow);
		static Cursor mainCursor = new Cursor(mainGrid, GraphicElements.BackgroundTexture);
		static Cursor nodeCursor = new Cursor(nodeGrid, GraphicElements.NodeTexture);

		static bool zoom = false;

		static Vector2f FromPixelToGlobalCoord(Vector2f position)
		{
			return FromPixelToGlobalCoord(new Vector2i((int)position.X, (int)position.Y));
		}
		static Vector2f FromPixelToGlobalCoord(float x, float y)
		{
			return FromPixelToGlobalCoord(new Vector2i((int)x, (int)y));
		}
		static Vector2f FromPixelToGlobalCoord(Vector2i position)
		{
			return mainWindow.MapPixelToCoords(position);
		}

		static void OnClose(object sender, EventArgs e)
		{
			RenderWindow window = (RenderWindow)sender;
			window.Close();
		}
		static void OnKeyPressed(object sender, KeyEventArgs e)
		{
			if (e.Code == Keyboard.Key.Escape)
				((RenderWindow)sender).Close();
			if (e.Code == Keyboard.Key.Left)
			{
				mainView.Move(new Vector2f(-25 * mainView.Size.Y / VideoMode.DesktopMode.Height, 0));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Right)
			{
				mainView.Move(new Vector2f(25 * mainView.Size.Y / VideoMode.DesktopMode.Height, 0));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Up)
			{
				mainView.Move(new Vector2f(0, -25 * mainView.Size.X / VideoMode.DesktopMode.Width));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Down)
			{
				mainView.Move(new Vector2f(0, 25 * mainView.Size.X / VideoMode.DesktopMode.Width));
				mainWindow.SetView(mainView);
			}
		}
		static void OnMouseScroll(object sender, MouseWheelEventArgs e)
		{
			if(e.Delta < 0)
			{
				if (!zoom)
				{
					mainView.Move(new Vector2f(9, 15));
					mainView.Zoom(3);
					zoom = !zoom;
				}
			}
			else
			{
				if (zoom)
				{
					mainView.Zoom((float)0.3333333333);
					mainView.Move(new Vector2f(-9, -15));
					zoom = !zoom;
				}
			}
			mainWindow.SetView(mainView);
		}
		static void OnClick(object sender, MouseButtonEventArgs e)
		{
			if(e.Button == Mouse.Button.Left)
			{
				logicEntities.Add(new LogicEntity(mainGrid, new Vector2f(e.X, e.Y), new Vector2i(3, 10)));
				logicEntities.Last().Rotation = 90;
			}
			else if(e.Button == Mouse.Button.Right)
			{
				nodes.Add(new Node(nodeGrid, new Vector2f(e.X, e.Y)));
			}
		}
		

		static void Main(string[] args)
		{
			mainWindow.Closed				+= new EventHandler(OnClose);
			mainWindow.KeyPressed			+= new EventHandler<KeyEventArgs>(OnKeyPressed);
			mainWindow.MouseWheelMoved		+= new EventHandler<MouseWheelEventArgs>(OnMouseScroll);
			mainWindow.MouseButtonPressed	+= new EventHandler<MouseButtonEventArgs>(OnClick);

			mainWindow.SetMouseCursorVisible(false);


			while (mainWindow.IsOpen)
			{
				mainWindow.DispatchEvents();



				mainWindow.Clear(Color.White);
				mainWindow.Draw(nodeGrid);
				mainWindow.Draw(mainGrid);

				mainWindow.SetView(mainView);
				mainWindow.Draw(mainCursor);
				mainWindow.Draw(nodeCursor);

				for (int index = 0; index < logicEntities.Count; index++)
					mainWindow.Draw(logicEntities[index]);
				for (int index = 0; index < nodes.Count; index++)
					mainWindow.Draw(nodes[index]);
				mainWindow.Display();
			}
		}
	}
}
