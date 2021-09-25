namespace RobotWars
{

    /// <summary>Class <c>Robot</c> represents a robot in a two-dimensional arena.
    /// The robot is bounded by the arena's <c>boundaries</c> and has a current <c>position</c> and <c>orientation</c> within that arena.
    /// This class also handles movements and turns </summary>
    ///
    class Robot
    {
        /// <summary>
        /// X and Y coordinates of robot in two-dimensional arena
        /// </summary>
        /// 
        public Coordinates position { get; private set; }

        /// <summary>
        /// Boundaries of arena in X and Y axis
        /// </summary>
        /// 
        public Coordinates boundaries { get; private set; }


        /// <summary>
        /// Orientation of the robot at specific location
        /// </summary>
        /// 
        public Orientation orientation { get; private set; }
        
        /// <summary>
        /// Initialises Robot class with initial <c>position</c> and <c>orientation</c> of robot within an arena bounded by <c>boundaries</c>
        /// </summary>
        /// <param name="position">Initial position of robot</param>
        /// <param name="boundaries">Boundaries of arena</param>
        /// <param name="orientation">Initial orientation of robot</param>
        /// 
        public Robot(Coordinates position, Coordinates boundaries, Orientation orientation)
        {
            this.position = position;
            this.boundaries = boundaries;
            this.orientation = orientation;
        }

        /// <summary>
        /// Moves Robot forward in the direction it is facing
        /// Triggered by 'M' in input
        /// </summary>
        public void MoveForward()
        {
            //initializes new position
            Coordinates newPosition = position;

            switch (this.orientation)
            {
                //If robot is facing North then it moves one unit forwards (positive) in the direction of y-axis
                case Orientation.N:
                    newPosition = new Coordinates(position.x, position.y + 1);
                    break;
                //If robot is facing South then it moves one unit backwards (negative) in the direction of y-axis
                case Orientation.S:
                    newPosition = new Coordinates(position.x, position.y - 1);
                    break;
                //If robot is facing West then it moves one unit forwards (positive) in the direction of x-axis
                case Orientation.W:
                    newPosition = new Coordinates(position.x + 1, position.y);
                    break;
                //If robot is facing East then it moves one unit backwards (negative) in the direction of x-axis
                case Orientation.E:
                    newPosition = new Coordinates(position.x - 1, position.y);
                    break;

            }

            //checks if new position is within boundaries of arena 
            //moves robot if it is 
            if (newPosition.x >=0 && newPosition.y >=0 && newPosition.x <= boundaries.x && newPosition.y <= boundaries.y)
                position = newPosition;
            //does not move robot if new position would be outside arena boundaries
        }

        /// <summary>
        /// Spins robot either Left or Right as specified by turn
        /// This is triggered by L or R in input line
        /// </summary>
        /// <param name="turn">Turn</param>
        public void Spin(Turn turn)
        {
            //Treats orientations as a closed group under operation + (modulus 4) where turning right is adding 1 and turning left is subtracting 1
            Orientation newOrientation = (Orientation)((((int)orientation) + ((int)turn)) % 4);

            orientation = newOrientation;
        }
    }

}