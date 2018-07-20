using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates
{
	sealed class LogicLevel
	{
		private static LogicLevel _ERROR;
		private static LogicLevel _LOW;
		private static LogicLevel _HIGH;

		static LogicLevel()
		{
			_ERROR = new LogicLevel();
			_LOW = new LogicLevel();
			_HIGH = new LogicLevel();
		} 

		public static LogicLevel ERROR
		{
			get
			{
				return _ERROR;
			}
		}
		public static LogicLevel LOW
		{
			get
			{
				return _LOW;
			}
		}
		public static LogicLevel HIGH
		{
			get
			{
				return _HIGH;
			}
		}

		public LogicLevel(string description)
		{
			this.description = description;
		}

		public LogicLevel()
		{

		}

		private string description;

		public string Description
		{
			get
			{
				return description;
			}
		}

	}
}
