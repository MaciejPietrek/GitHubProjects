using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates
{
	abstract class Connectable
	{
		private List<Connectable> connectables;

		private bool Set(Connectable connectable)
		{
			if (!connectables.Contains(connectable))
			{
				connectables.Add(connectable);
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool SetConnection(Connectable connectable)
		{
			if (!connectables.Contains(connectable))
			{
				connectables.Add(connectable);
				connectable.Set(this);
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool Remove(Connectable connectable)
		{
			if (connectables.Contains(connectable))
			{
				connectables.Remove(connectable);
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool RemoveConnection(Connectable connectable)
		{
			if (connectables.Contains(connectable))
			{
				connectable.Remove(this);
				connectables.Remove(connectable);
				return true;
			}
			else
			{
				return false;
			}
		}

		public int ConnectionNumber()
		{
			return connectables.Count();
		}

		public int PositionOfConnection(Connectable connectable)
		{
			return connectables.IndexOf(connectable);
		}

		public Connectable this[int index]
		{
			get
			{
				return connectables.ElementAt(index);
			}
		}

		protected Connectable()
		{
			connectables = new List<Connectable>();
		}
	}
}
