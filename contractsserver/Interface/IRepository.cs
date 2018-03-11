namespace ContractsServer.Interface
{
    public interface IRepository<T, B>
    {
        void AddingPlane(T TPlane);

        T LastStation(T TPlane, int TStation);
    }
}