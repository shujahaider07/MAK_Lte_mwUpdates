using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IRuntimeFieldsCustomization
    {
        public Task<RuntimeFieldsCustomization> AddRuntimeFieldsCustomization(RuntimeFieldsCustomization r);

        public IEnumerable<RuntimeFieldsCustomization> ListRuntimeFieldsCustomization();
        public Task<IEnumerable<RuntimeFieldsCustomization>> Edit(RuntimeFieldsCustomization r);

        public Task<RuntimeFieldsCustomization> GetRuntimeFieldsCustomizationByID(int Id);
        public void DeleteRuntimeFieldsCustomization(int Id);
    }
}
