using HPlusSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Web.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderItemViewModel> Orders { get; set; }
    }
}
