using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Player
{
  class ThreadSuperClass
  {
    //VOLATILE BOOL BECOZ MULTIPLE THREADS WILL ACCESS IT
    public static volatile bool running;

    //CONSTRUCTOR
    public ThreadSuperClass() 
    {
      running = true;
    }

    //CALLED WHEN THREAD IS RUNNING
    public virtual void DoWork() 
    {
      while (running) 
      { 
        //DO SOME WORK
      }
    }

    //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
    //DISPOSE OF ALL CAMERA OBJECTS
    public virtual bool RequestStop()
    {
      running = false;
      return true;
    }
  }
}
