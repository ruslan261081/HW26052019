using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW26052019_Enums
{
    class Program
    {
        static public event EventHandler<EventArgs> TheFloorReached;

        static void Main(string[] args)
        {
            Elevator elevator = new Elevator(ElevatorState.RESTING, 1);

            TheFloorReached += elevator.FloorReached;
            if(elevator.GotoFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
            if(elevator.GotoFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
            elevator.CloseDoor();
            if(elevator.GotoFloor(3))
            {
                Thread.Sleep(2000);
                TheFloorReached.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
