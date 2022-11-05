using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Classess
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string Order_composition { get; set; }

        public DateTime Order_date { get; set; }

        public DateTime Delivery_date {get;set;}

        public int Point_of_issue { get; set; }

        public string UserName { get; set; }

        public string Code_to_get { get; set; }

        public string Status_Order { get; set; }

        public OrderModel (int id, string order_composition, DateTime order_date, DateTime delivery_date, int point_of_issue, string userName, string code_to_get, string status_Order)
        {
            if(order_composition.Length == 0 || point_of_issue < 0  || code_to_get.Length == 0 || status_Order.Length == 0)
            {
                throw new ArgumentNullException("sad");
            }

            Id = id;
            Order_composition = order_composition;
            Order_date = order_date;
            Delivery_date = delivery_date;
            Point_of_issue = point_of_issue;
            UserName = userName;
            Code_to_get = code_to_get;
            Status_Order = status_Order;
        }
    }
}
