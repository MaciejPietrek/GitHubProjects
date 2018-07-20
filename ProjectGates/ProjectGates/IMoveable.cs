using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates
{
	interface IMoveable
	{
		void MoveBy(SFML.System.Vector2f realocationVector);
		void MoveTo(SFML.System.Vector2f realocationVector);
	}
}
