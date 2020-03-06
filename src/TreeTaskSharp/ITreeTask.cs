namespace TreeTaskSharp
{
    public interface ITreeTask
    {
        int Priority { get; }
        bool Activate();
        void Execute();
    }
}
