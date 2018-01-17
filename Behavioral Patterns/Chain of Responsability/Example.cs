using System;

namespace RealApp
{
    class MainApp
    {
        static void Main()
        {
            //The chain of responsibility
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccesor(sam);
            sam.SetSuccesor(tammy);

            //Generate and process purchase requests
            Purchase p = new Purchase(2034,350.5,"Assets");
            larry.ProcessRequest(p);

            p = new new Purchase(2034,2343.4,"Project X");
            larry.ProcessRequest(p);

            Console.ReadKey();
        }
    }

    abstract Class Approver
    {
        protected Approver successor;

        public void SetSuccesor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    class Director : Approver 
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
             if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine("Request# {0} requires an executive meeting!",purchase.Number);
            }
        }
    }

    class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;

        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        } 

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
 
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
 
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }


}