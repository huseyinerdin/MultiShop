namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
