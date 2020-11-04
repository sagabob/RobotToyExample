namespace RobotToy.Domain.Interfaces
{
    public interface IRobot
    {
        RobotPlaceMoveTurnResult TurnLeft();
        RobotPlaceMoveTurnResult TurnRight();
        RobotPlaceMoveTurnResult Move();
        bool SetPosition(Position newPosition);
        Position CurrentPosition();
    }
}