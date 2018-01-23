using System;

namespace AdapterPattern
{
	class MainApp
	{
		static void Main()
		{
			Target target = new Adapter();
			target.Request();
			
			Consoler.ReadKey();
		}
	}
	
	class Target
	{
		public virtual void Request()
		{
			Console.WriteLine("Called Target Request()");
		}
	}
	
	class Adapter : Target
	{
		private Adaptee _adaptee = new Adaptee();
		
		public override voir Request()
		{
			_adaptee.SpecificRequest();
		}
	}
	
	class Adaptee
	{
		public void SpecificRequest()
		{
			Console.WriteLine("Called SpecificRequest");
		}
	}
	
}