namespace BLL.Helpers;

public static class Rules
{
    public static bool CanMoveWrist(string elbowState)
    {
        return elbowState != "Fortemente Contraído";
    }

    public static bool RotateHead(string headTilt)
    {
        return headTilt != "Para Baixo";
    }

    public static bool StateProgression(int lastState, int newState)
    {
        if (newState == lastState + 1 || newState == lastState - 1)
        {
            return true;
        }
        return false;
    }
}