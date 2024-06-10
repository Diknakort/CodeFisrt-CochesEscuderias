
using System;
using System.Threading;
using System.Threading.Tasks;
using SolucionMultiproceso;

public class Lambda
{
    public static void Main()
    {
        Thread.CurrentThread.Name = "Main";

        // Create a task and supply a user delegate by using a lambda expression.
        Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
        //Task<Action<> taskB = Task.Run( new Motor().arranca());

        // Start the task.
        taskA.Start();

        // Output a message from the calling thread.
        Console.WriteLine("Hello from thread '{0}'.",
            Thread.CurrentThread.Name);
        taskA.Wait();
    }
}
// The example displays output as follows:
//       Hello from thread 'Main'.
//       Hello from taskA.
// or
//       Hello from taskA.
//       Hello from thread 'Main'.