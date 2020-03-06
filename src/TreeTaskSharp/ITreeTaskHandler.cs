using System.Collections.Generic;

namespace TreeTaskSharp
{
    public interface ITreeTaskHandler
    {
        List<ITreeTask> TreeTasks { get; set; }
        void Execute();
        void Reset();
    }
}
