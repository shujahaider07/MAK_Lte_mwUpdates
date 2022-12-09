using BusinessLogic;

namespace repository
{
    public interface IAssociation
    {

        public Task<Association> Addassociation(Association a);
        public Task<IEnumerable<Association>> Listassociation();
        public Task<IEnumerable<Association>> Edit(Association a);

        public Task<Association> GetAssociationByID(int Id);
        public void DeleteAssociation(int Id);


    }
}
