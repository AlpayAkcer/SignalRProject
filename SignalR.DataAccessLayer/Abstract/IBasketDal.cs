using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        //Her sepet değil, hangi masanın ürünlerini getirmesi gerektiğinin listesi
        //id değeri MenuTable bağlı olduğu id numarasını alacağız. 
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
