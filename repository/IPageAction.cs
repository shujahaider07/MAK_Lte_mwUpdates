using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IPageAction
    {

        public Task<PageAction> AddPageAction(PageAction p);

        public Task<IEnumerable<PageAction>> ListPageAction();
        public Task<IEnumerable<PageAction>> Edit(PageAction p);

        public Task<PageAction> GetPageActionByID(int Id);
        public void DeletePageAction(int Id);
    }
}
