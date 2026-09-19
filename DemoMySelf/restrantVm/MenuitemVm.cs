using DemoMySelf.Models;

namespace DemoMySelf.restrantVm
{
    public class MenuitemVm
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = string.Empty;

        public int Price { get; set; }

        public int CategoryyId { get; set; }

        public List<Categorycs> Category { get; set; }

    }
}
