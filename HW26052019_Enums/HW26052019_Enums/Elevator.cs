using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW26052019_Enums
{
    class Elevator
    {
        private ElevatorState _elevatorState;
        private  int _currentFloor;
        private int _gotoFloor;

        public Elevator(ElevatorState elavatorState, int currentFloor)
        {
            _elevatorState = elavatorState;
            _currentFloor = currentFloor;
        }
        public bool GotoFloor(int newFloor)
        {
            _gotoFloor = newFloor;
            if(_elevatorState == ElevatorState.RESTING)
            {
                if(_currentFloor == newFloor)
                {
                    Console.WriteLine("Same Floor");
                    _elevatorState = ElevatorState.OPEN_DOORS;
                }
                if(_currentFloor < newFloor)
                {
                    Console.WriteLine("Need Go Down");
                    _elevatorState = ElevatorState.GOING_DOWN;
                }
                return true;

            }
            Console.WriteLine("Elevator In Other Action Right Now.");
            return false;
        }
        private void OnReachedFloor()
        {

        }
        public void FloorReached(object sender, EventArgs e)
        {
            if(_elevatorState == ElevatorState.OPEN_DOORS || _elevatorState == ElevatorState.RESTING)
            {
                Console.WriteLine($"The Elevator Already In {_currentFloor} Floor, Or Doors Are Already Open");
            }
            else
            {
                _elevatorState = ElevatorState.OPEN_DOORS;
                _currentFloor = _gotoFloor;
                Console.WriteLine($"The Elevator Reach Floor {_currentFloor}");
            }
        }
        public bool CloseDoor()
        {
            if(_elevatorState == ElevatorState.OPEN_DOORS)
            {
                Console.WriteLine($"Elevator Closing The Doors");
                _elevatorState = ElevatorState.RESTING;
                return true;
            }
            return false;
        }
    }
}
