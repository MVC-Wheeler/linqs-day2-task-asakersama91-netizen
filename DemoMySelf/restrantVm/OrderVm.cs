using DemoMySelf.Models;

namespace DemoMySelf.restrantVm
{
    public class OrderVm
    {
        public int OrderId { get; set; }
        public string Quantity { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public int MenuItemId { get; set; }

        public List<MenuItem> MenuItem { get; set; }
    }
}
