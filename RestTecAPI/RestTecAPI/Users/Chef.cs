using System.Numerics;

namespace RestTecAPI.Entities
{
    public class Chef : Person
    {
        LinkedList<Order> orders;

        LinkedList<Order> currents;

        const string data_base = "C:\\Users\\manue\\Escritorio\\RestTec-TareaCorta\\RestTecAPI\\RestTecAPI\\DataBases\\Users.txt";

        public Chef()
        { 
            orders = Order.orders;

        }

        public void register(string email, string password)
        {
            using (StreamWriter writer = new StreamWriter(data_base))
            {
                writer.WriteLine($"{email},{password},chef");
            }
        }

        public bool login(string email, string password)
        {
            bool isChef = false;

            using (StreamReader reader = new StreamReader(data_base))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    // Verificar si el correo electrónico y la contraseña coinciden
                    if (parts.Length == 3 && parts[0] == email && parts[1] == password)
                    {
                        // Verificar si el último campo es "chef"
                        if (parts[2].Trim().ToLower() == "chef")
                        {
                            isChef = true;
                        }
                        // Se encontró una coincidencia, puedes salir del bucle
                        break;
                    }
                }
            }

            return isChef;
        }
        public LinkedList<Order> see_all_orders()
        {
            return orders;
        }
        public bool take_order(Order order)
        {
            if (orders.Contains(order))
            {
                order.assigned = true;
                currents.AddLast(order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedList<Order> see_assing_orders()
        {
            return currents;
        }
        public bool reassing_order(int index, Chef other_chef)
        {
            int currentIndex = 0;
            foreach (Order order in currents)
            {
                if (currentIndex == index)
                {
                    this.orders.Remove(order);
                    other_chef.orders.AddLast(order);
                    return true;
                }
                currentIndex++;
            }
            return false;
        }
    }
}
