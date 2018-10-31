using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BackgroundThreadThatKeepsTimeTrack
{
  /// <summary>
  /// @Author: Indrit Kello
  /// Simple console to refresh something (ex. cookie) on background using thread.
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Thread t = new Thread(new ThreadStart(KeepTimeTrack));

      t.Start();

      t.IsBackground = true;

      Console.WriteLine("The thread's background status is: " + t.IsBackground.ToString());

      Console.Read();
    }
    static void KeepTimeTrack()

    {

      System.Timers.Timer timer = new System.Timers.Timer(1000 * 30);//30 sec
      timer.Start();

      timer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
      {

        timer.Stop();
        //timer.Dispose();
        Console.WriteLine(timer.Interval / 1000 + " seconds. It is time to refresh!"); //example. To do: add 30 sec to cookie
        timer.Start();//restart the timer
      });


    }

  }
}
