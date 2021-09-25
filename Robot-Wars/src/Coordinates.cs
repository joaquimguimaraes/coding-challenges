namespace RobotWars {
    struct Coordinates {
        /// <summary>
        /// coordinate in x axis
        /// </summary>
        /// 
        public readonly int x { get; init; }

        /// <summary>
        /// coordinate in y axis
        /// </summary>
        /// 
        public readonly int y { get; init; }

        public Coordinates (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

}