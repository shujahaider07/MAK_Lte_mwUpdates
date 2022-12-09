using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IGeneralConfigurations 
    {

        public Task<GeneralConfigurations> AddGeneralConfigurations(GeneralConfigurations g);
        public Task<IEnumerable<GeneralConfigurations>> ListGeneralConfigurations();
        public Task<IEnumerable<GeneralConfigurations>> Edit(GeneralConfigurations g);

        public Task<GeneralConfigurations> GetGeneralConfigurationsByID(int Id);
        public void DeleteGeneralConfigurations(int Id);
    }
}
