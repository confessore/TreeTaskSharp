using System.Collections.Generic;
using System.Linq;

namespace TreeTaskSharp
{
    public class TreeTaskHandler : ITreeTaskHandler
    {
        #region Constructors

        public TreeTaskHandler(params ITreeTask[] treeTasks)
        {
            foreach (var treeTask in treeTasks)
                TreeTasks.Add(treeTask);
        }

        public TreeTaskHandler(IEnumerable<ITreeTask> treeTasks)
        {
            foreach (var treeTask in treeTasks)
                TreeTasks.Add(treeTask);
        }

        public TreeTaskHandler(params IEnumerable<ITreeTask>[] treeTaskLists)
        {
            foreach (var treeTaskList in treeTaskLists)
                foreach (var treeTask in treeTaskList)
                    TreeTasks.Add(treeTask);
        }

        public TreeTaskHandler(params ITreeTaskHandler[] treeTaskHandlers)
        {
            foreach (var treeTaskHandler in treeTaskHandlers)
                foreach (var treeTask in treeTaskHandler.TreeTasks)
                    TreeTasks.Add(treeTask);
        }

        public TreeTaskHandler(IEnumerable<ITreeTaskHandler> treeTaskHandlers)
        {
            foreach (var treeTaskHandler in treeTaskHandlers)
                foreach (var treeTask in treeTaskHandler.TreeTasks)
                    TreeTasks.Add(treeTask);
        }

        public TreeTaskHandler(params IEnumerable<ITreeTaskHandler>[] treeTaskHandlerLists)
        {
            foreach (var treeTaskHandlerList in treeTaskHandlerLists)
                foreach (var treeTaskHandler in treeTaskHandlerList)
                    foreach (var treeTask in treeTaskHandler.TreeTasks)
                        TreeTasks.Add(treeTask);
        }

        #endregion

        public List<ITreeTask> TreeTasks { get; set; } = new List<ITreeTask>();

        public void Execute() =>
            TreeTasks.Where(x => x.Activate()).OrderBy(x => x.Priority).LastOrDefault().Execute();

        public void Reset() =>
            TreeTasks = new List<ITreeTask>();
    }
}
