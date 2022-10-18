using System;
using System.Threading;

namespace ProjetApplication
{
    class Delivery_man : Person
    {
        public Delivery_man(){}
        public async void deliverOrder(Order o, Pizzeria pizzeria) {
            Console.WriteLine("Order in delivery");
            if(o.State == order_type.in_delivery) {
                Console.WriteLine("Sending the order " + o.OrderID + " to the client ");
                await Task.Delay(10000);

                o.State = order_type.delivered;
                if(o.State == order_type.delivered) {
                    Console.WriteLine("The order " + o.OrderID + " is delivered");
                    Console.WriteLine("Deliver received : " + o.computePrice() + "€");
                    await Task.Delay(5000);
                    pizzeria.Help_cooker.endOrder(o);
                }
            }
        }
    }
}


