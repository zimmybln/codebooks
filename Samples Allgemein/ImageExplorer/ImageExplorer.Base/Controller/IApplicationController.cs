namespace ImageExplorer.Base
{
    public interface IApplicationController
    {
        void Initialize(string[] args);
        void Run();
        void Close();
        void Shutdown();
    }
}