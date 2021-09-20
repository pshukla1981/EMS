using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMA.Business.Factory.ViewModels
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string MenuText { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<bool> Active { get; set; }
    }
    public class MainMenuModel
    {
        public MainMenuModel()
        {
            this.SubMenuList = new List<SubMenu>();
        }
        public int MainMenuId { get; set; }
        public string MainMenuText { get; set; }
        public List<SubMenu> SubMenuList { get; set; }

    }
    public class SubMenu
    {
        public int SubMenuId { get; set; }
        public string SubMenuText { get; set; }
    }
    public class MainMenuItemModel
    {
        public int Id { get; set; }
        public string MenuText { get; set; }
    }
}
