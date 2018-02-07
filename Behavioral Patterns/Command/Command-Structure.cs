using System;

namespace CommandStructure
{
    class MainApp
    {
        static void Main()
        {
            Receiver receiver = new Receiver();
            Command command  = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver )
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }
 
        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    class invoker
    {
        private Command _command;

        public void SetComand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}