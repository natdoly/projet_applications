using System;
#pragma warning disable 8600
namespace ProjetApplication
{
    class Help_cooker : Person
    { 
        // Attributes
        private List<Order> command_list = new List<Order>();

        // Constructor
        public Help_cooker(int personID, string name, string surname, int metierID) : base(personID, name, surname, metierID) 
        {}

        //Getter & Setter
        public void getClientOrder(bool isFirstTimeOrder, Order order) {
            // mettre la commande dans la liste de commande
            command_list.Add(order);
        }

        public void isFirstTimeOrder(Client c, Pizzeria p) {
            Console.WriteLine("is it the first time you order? (y/n)");
            string choiceClient = Console.ReadLine(); //First time ? Client answer
            while(choiceClient != "y" && choiceClient != "n") {
                Console.WriteLine("Please answer y or n");
                choiceClient = Console.ReadLine();
            }
            
            if (choiceClient == "n") { //Case - Not the first time
                Console.WriteLine("Not the first time");
                Console.WriteLine("Verification of the phone number");
                
                string phone = Console.ReadLine();//Input of the phone number
                
                if(p.isClientInList(phone)) { //Case - Client is in the list
                    Console.WriteLine("Client is in the list");
                    
                    c.printAddress();
                    Console.WriteLine("Is it your address ? (y/n)");
                    String addressConfirmation = Console.ReadLine(); //Answer of the Client

                    if (addressConfirmation == "y") { //Case - Good address
                        Console.WriteLine("Good Address");
                        Console.WriteLine("<======Take the order======>"); //Prise de commande
                        Order order = new Order(this, c);

                    } else if (addressConfirmation == "n") { //Case - Bad address
                        Console.WriteLine("Enter the correct address :"); //Updating address
                        c.enterAddress();
                        Console.WriteLine("your address : " + c.Address);
  
                        Console.WriteLine("<======Take the order======>"); //Prise de commande
                        Order order = new Order(this, c);
                    }
                }

            } else if(choiceClient == "y")  { //Case - The first time OR Not in the list
                Console.WriteLine("Collecting Client's information"); //First time OR Not in the list
                c.enterClient();
                Console.WriteLine("<======Take the order======>"); //Prise de commande
                Order order = new Order(this, c);
            }
        }
    }
}