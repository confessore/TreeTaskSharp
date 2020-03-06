# TreeTaskSharp
A library for prioritizing and executing large numbers of tasks.
# How To Use
This is the simplest way to use **TreeTaskSharp** is to pass a **TreeTask** to a **TreeTaskHandler**.
```c
    public class WalkTheDog : TreeTask
    {
        public override int Priority =>
	        100;

        public override bool Activate() =>
            true;

        public override void Execute() =>
            Console.WriteLine("Walking the dog");
    }
```
```c
    class Program
    {
        static void Main(string[] args)
        {
            var treeTask = new WalkTheDog();
            var treeTaskHandler = new TreeTaskHandler(treeTask);
            treeTaskHandler.Execute();
        }
    }
```
## Getting More Complex
Pass multiple **TreeTasks** to a **TreeTaskHandler**.
```c
    public class WalkTheDog : TreeTask
    {
        public override int Priority =>
	        100;

        public override bool Activate() =>
            true;

        public override void Execute() =>
            Console.WriteLine("Walking the dog");
    }
```
```c
    public class RecordNewMixTape : TreeTask
    {
        public override int Priority =>
	        200;

        public override bool Activate() =>
            false;

        public override void Execute() =>
            Console.WriteLine("Recording new mix tape");
    }
```
```c
    class Program
    {
        static void Main(string[] args)
        {
            var treeTask = new WalkTheDog();
            var treeTask2 = new RecordNewMixTape();
            var treeTaskHandler = new TreeTaskHandler(treeTask, treeTask2);
            treeTaskHandler.Execute();
        }
    }
```
## Going Wild!
Add **TreeTasks** to **Lists** and then pass them to **TreeTaskHandlers** or pass **TreeTaskHandlers** to **TreeTaskHandlers** to **TreeTaskHandlers** to **TreeTaskHandlers**. The possibilities are endless!
```c
    class Program
    {
        static void Main(string[] args)
        {
            var treeTaskList = new List<ITreeTask>() { new WalkTheDog() };
            var treeTaskList2 = new List<ITreeTask>() { new RecordNewMixTape() };
            var treeTaskHandler = new TreeTaskHandler(treeTaskList, treeTaskList2);
            var treeTaskHandler2 = new TreeTaskHandler(treeTaskHandler);
            treeTaskHandler2.Execute();
        }
    }
```