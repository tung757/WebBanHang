using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IGioHangItemRepository
    {
        Task<List<GiohangSanpham>> GetAllItemsGioHang();
        Task AddItemGioHang(GiohangSanpham ghsp);
        Task RemoveItemGioHang(int IdGh, int MaSp);
        Task UpdateItemGioHang(GiohangSanpham ghsp);
    }
}
