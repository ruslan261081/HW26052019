using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW26052019_Enums
{
    class ElevatorFloorManager
    {
        public event EventHandler TheFloorReached;

        public void OnTheFloorReached()
        {
            if(TheFloorReached != null)
            {
                TheFloorReached.Invoke(this, EventArgs.Empty);
            }
        }
        public void SendElevatorToFloor(Elevator elevator, int floor)
        {
            if(elevator.GotoFloor(floor))
            {
                Thread.Sleep(2000);
                OnTheFloorReached();
            }
        }
    }
}
