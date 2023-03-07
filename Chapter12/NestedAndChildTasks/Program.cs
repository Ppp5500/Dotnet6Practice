using static System.Console;

Task myTask = new(OuterMethod);
myTask.Start();
myTask.Wait();
WriteLine("myTask finished...");

static void OuterMethod()
{
    WriteLine("Outer method starting...");
    Task innerTask = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent); // CreationOption!
    Thread.Sleep(1000);
    WriteLine("Outer method finished.");
}
static void InnerMethod()
{
    WriteLine("Inner method starting...");
    Thread.Sleep(2000);
    WriteLine("Inner method finished.");
}
