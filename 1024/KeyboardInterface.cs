using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024
{
    public class KeyboardInterface : IControler
    {
        protected Direction currentDirection;
        protected bool shouldMove;

        public KeyboardInterface()
        {
            this.shouldMove = false;
        }

        public void Move(Direction direction)
        {
            CurrentDirection = direction;
            ShouldMove = true;
        }

        public Direction CurrentDirection
        {
            get
            {
                return this.currentDirection;
            }
            protected set
            {
                this.currentDirection = value;
            }
        }


        public bool ShouldMove
        {
            get
            {
                return this.shouldMove;
            }
            set
            {
                this.shouldMove = value;
            }
        }
    }
}
