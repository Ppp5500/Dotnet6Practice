using System.Diagnostics; // Stopwatch
using static System.Console;

OutputTrheadInfo();
Stopwatch timer = Stopwatch.StartNew();
/*
WriteLine("Running methods synchronously on one thread");
MethodA();
MethodB();
MethodC();
*/
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");

// Output information about current thread
static void OutputTrheadInfo()
{
    Thread t = Thread.CurrentThread;
    WriteLine(
        "Thread Id: {0}, Priority: {1}, Background: {2}, Name: {3}",
        t.ManagedThreadId, t.Priority, t.IsBackground, t.Name ?? "null");
}

static void MethodA()
{
    WriteLine("Starting Method A...");
    OutputTrheadInfo();
    Thread.Sleep(3000); // simulate threed secondds of work
    WriteLine("Finished Method A.");
}
static void MethodB()
{
    WriteLine("Starting Method B...");
    OutputTrheadInfo();
    Thread.Sleep(2000); // simulate threed secondds of work
    WriteLine("Finished Method B.");
}
static void MethodC()
{
    WriteLine("Starting Method C...");
    OutputTrheadInfo();
    Thread.Sleep(1000); // simulate threed secondds of work
    WriteLine("Finished Method C.");
}

// 각 task 들은 status 속성과 CreationOptions 속성을 가진다.
// task는 ContineueWith 메소드를 가지며 이 메소드는 TaskContinuationOptions eunm을 사용하여 커스텀할 수 있다.
// 또한 TaskFactory 클래스를 이용하여 관리할 수 있다.