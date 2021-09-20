using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMA.Business.Factory.ViewModels;
using EMA.Data;

namespace EMA.Business.Factory.Repository
{
    public class MenuRepository
    {
        /// <summary>
        /// get the list of menu items from database
        /// </summary>
        /// <returns></returns>
        public List<MainMenuModel> GetList()
        {
            List<MainMenuModel> lst = new List<MainMenuModel>();
            List<MenuModel> menulist = new List<MenuModel>();
            try
            {
                using (EMSEntities db = new EMSEntities())
                {
                    var menus = db.tblMenus.ToList();
                    menulist = menus.Select(x => new MenuModel
                    {
                        Id = x.Id,
                        MenuText = x.MenuText,
                        ParentId = x.ParentId,
                        Active = x.Active
                    }).ToList();

                    List<MainMenuItemModel> lstmainitems = new List<MainMenuItemModel>();
                    var mainitems = menulist.Where(x => x.ParentId == null).ToList();
                    lstmainitems = mainitems.Select(x => new MainMenuItemModel
                    {
                        Id = x.Id,
                        MenuText = x.MenuText
                    }).ToList();
                    foreach (var items in lstmainitems)
                    {
                        MainMenuModel mainMenuModel = new MainMenuModel();
                        mainMenuModel.MainMenuId = items.Id;
                        mainMenuModel.MainMenuText = items.MenuText;
                        mainMenuModel.SubMenuList = menulist.Where(x => x.ParentId == items.Id).Select(y => new SubMenu
                        {
                            SubMenuId = y.Id,
                            SubMenuText = y.MenuText
                        }).ToList();
                        lst.Add(mainMenuModel);
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return lst;

        }
    }
}
