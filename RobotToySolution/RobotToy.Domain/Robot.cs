using RobotToy.Domain.Interfaces;

namespace RobotToy.Domain
{
    public class Robot : IRobot
    {
        private readonly int _xLowerBoundary;
        private readonly int _xUpperBoundary;
        private readonly int _yLowerBoundary;
        private readonly int _yUpperBoundary;
        private Position _position;
        public Robot(TableDimensions tableDimensions)
        {
            _xLowerBoundary = 0;
            _yLowerBoundary = 0;
            _xUpperBoundary = tableDimensions.Length - 1;
            _yUpperBoundary = tableDimensions.Width - 1;
        }

        public Position CurrentPosition()
        {
            return _position;
        }

        public RobotPlaceMoveTurnResult TurnLeft()
        {
            if (_position == null)
                return RobotPlaceMoveTurnResult.NotPlacedOnTable;

            switch (_position.Direction)
            {
                case Direction.North:
                    _position.Direction = Direction.West;
                    break;
                case Direction.West:
                    _position.Direction = Direction.South;
                    break;
                case Direction.South:
                    _position.Direction = Direction.East;
                    break;
                case Direction.East:
                    _position.Direction = Direction.North;
                    break;
            }

            return RobotPlaceMoveTurnResult.SuccessfulAction;
        }

        public RobotPlaceMoveTurnResult TurnRight()
        {
            if (_position == null)
                return RobotPlaceMoveTurnResult.NotPlacedOnTable;

            switch (_position.Direction)
            {
                case Direction.North:
                    _position.Direction = Direction.East;
                    break;
                case Direction.East:
                    _position.Direction = Direction.South;
                    break;
                case Direction.South:
                    _position.Direction = Direction.West;
                    break;
                case Direction.West:
                    _position.Direction = Direction.North;
                    break;
            }

            return RobotPlaceMoveTurnResult.SuccessfulAction;
        }

        public RobotPlaceMoveTurnResult Move()
        {
            if (_position == null)
                return RobotPlaceMoveTurnResult.NotPlacedOnTable;

            switch (_position.Direction)
            {
                case Direction.North:
                    if (_position.Y == _yUpperBoundary)
                        return RobotPlaceMoveTurnResult.PreventedAction;
                    else
                        _position.Y++;
                    break;

                case Direction.West:
                    if (_position.X == _xLowerBoundary)
                        return RobotPlaceMoveTurnResult.PreventedAction;
                    else
                        _position.X--;
                    break;

                case Direction.South:
                    if (_position.Y == _yLowerBoundary)
                        return RobotPlaceMoveTurnResult.PreventedAction;
                    else
                        _position.Y--;
                    break;

                case Direction.East:
                    if (_position.X == _xUpperBoundary)
                        return RobotPlaceMoveTurnResult.PreventedAction;
                    else
                        _position.X++;
                    break;
            }

            return RobotPlaceMoveTurnResult.SuccessfulAction;
        }

        public bool SetPosition(Position newPosition)
        {
            if (!IsValidPosition(newPosition))
                return false;

            _position = newPosition;
            return true;
        }

        private bool IsValidPosition(Position position)
        {
            return position.X >= _xLowerBoundary &&
                   position.X <= _xUpperBoundary &&
                   position.Y >= _yLowerBoundary &&
                   position.Y <= _yUpperBoundary;
        }
    }
}