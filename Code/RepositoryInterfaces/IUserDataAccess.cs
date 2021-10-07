namespace RepositoryInterfaces
{
    public interface IUserDataAccess<T>
    {
        public T Create(T newUser);
    }
}
