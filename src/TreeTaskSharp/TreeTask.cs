namespace TreeTaskSharp
{
    public abstract class TreeTask : ITreeTask
    {
        public abstract int Priority { get; }
        public abstract bool Activate();
        public abstract void Execute();
    }
}
