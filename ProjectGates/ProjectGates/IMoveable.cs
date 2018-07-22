using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates
{
	interface IMoveable
	{
		SFML.System.Vector2f Position{ get; set; }
		float Rotation { get; set; }
	}
}
