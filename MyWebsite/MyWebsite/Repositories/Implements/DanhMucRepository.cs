

using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class DanhMucRepository : IDanhMucRepository
    {
        public Task AddDM(Danhmuc danhmuc)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDM(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Danhmuc>> getAllDM()
        {
            throw new NotImplementedException();
        }

        public Task<Danhmuc> getDMbyID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDM(Danhmuc danhmuc)
        {
            throw new NotImplementedException();
        }
    }
}
