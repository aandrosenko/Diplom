namespace WebUI.Context
{
    public interface IContextManager<T> where T:class 
    {
        void LoadContext();
        void ClearContext();

        T GetContext();
    }
}
