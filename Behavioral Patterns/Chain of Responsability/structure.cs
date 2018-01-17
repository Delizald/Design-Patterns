using System;

namespace app
{
    class MainApp
    {
        static void Main()
        {
            //Setting the chain of responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.SetSuccessor(h2);
            h2.SetSuccesor(h3);

            //Generate and process requests
            int[] requests = {2,5,14,22,18,3,27,20};

            foreach(int request in requests)
            {
                h1.HandleRequest(request);
            }

            Console.ReadKey();
        }
    }

    abstract class Handler
    {
        protected Hanlder succesor;

        public void SetSuccesor(Handler)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    class ConcreteHandler1: Handler
    {
        public override void HandleRequest(int request)
        {
            if(request >=0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",this.GetType().Name, request);
            }
            else if (succesor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if(request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",this.GetType().Name, request);
            }
            else if (succesor != null)
            {
                successor.HandleRequest(request);
            }    
        }
    }

    class ConreteHandler3: HandleRequest
    {
        public override HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }    
}