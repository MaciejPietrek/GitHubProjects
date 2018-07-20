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
		static View mainView = new View(mainWindow.GetView());
		static List<LogicEntity> logicEntities = new List<LogicEntity>();
		static List<Node> nodes = new List<Node>();
		static Grid mainGrid = new Grid(25, 25, new Color(200, 200, 200), 2);
		static Grid nodeGrid = new Grid(5, 5, new Color(240, 240, 240), 1);

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
				mainView.Move(new Vector2f(-25, 0));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Right)
			{
				mainView.Move(new Vector2f(25, 0));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Up)
			{
				mainView.Move(new Vector2f(0, -25));
				mainWindow.SetView(mainView);
			}
			if (e.Code == Keyboard.Key.Down)
			{
				mainView.Move(new Vector2f(0, 25));
				mainWindow.SetView(mainView);
			}
		}

		static void OnMouseScroll(object sender, MouseWheelEventArgs e)
		{
			if(e.Delta < 0)
			{
				mainView.Move(new Vector2f(9, 15));
				mainView.Zoom(3);
			}
			else
			{
				mainView.Zoom((float)0.3333333333);
				mainView.Move(new Vector2f(-9, -15));
			}
			mainWindow.SetView(mainView);
		}
		static void OnClick(object sender, MouseButtonEventArgs e)
		{
			if(e.Button == Mouse.Button.Left)
			{
				Vector2f tmp = mainWindow.MapPixelToCoords(new Vector2i(e.X, e.Y));

				logicEntities.Add(new LogicEntity(2, 2, mainGrid.PositionAcordingToGrid(mainWindow, tmp), mainGrid, mainWindow));
			}
			else if(e.Button == Mouse.Button.Right)
			{
				Vector2f tmp = mainWindow.MapPixelToCoords(new Vector2i(e.X, e.Y));
				
				nodes.Add(new Node());
				nodes.Last().MoveTo(nodeGrid.PositionAcordingToGrid(mainWindow,tmp));
			}
		}
		static void Main(string[] args)
		{
			mainWindow.Closed				+= new EventHandler(OnClose);
			mainWindow.KeyPressed			+= new EventHandler<KeyEventArgs>(OnKeyPressed);
			mainWindow.MouseWheelMoved		+= new EventHandler<MouseWheelEventArgs>(OnMouseScroll);
			mainWindow.MouseButtonPressed	+= new EventHandler<MouseButtonEventArgs>(OnClick);

			


			while (mainWindow.IsOpen)
			{
				mainWindow.DispatchEvents();



				mainWindow.Clear(SFML.Graphics.Color.White);

				mainWindow.SetView(mainWindow.DefaultView);
				mainWindow.Draw(nodeGrid);
				mainWindow.Draw(mainGrid);
				mainWindow.SetView(mainView);

				for (int index = 0; index < logicEntities.Count; index++)
					mainWindow.Draw(logicEntities[index]);
				for (int index = 0; index < nodes.Count; index++)
					mainWindow.Draw(nodes[index]);

				mainWindow.Display();
			}
		}
	}
}
