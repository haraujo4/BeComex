using BLL.DTO;
using BLL.Models;

namespace BLL.Interface.Services;

public interface IRoboActionServices
{
    IEnumerable<Robo> GetRoboAction();
    Task<bool> SendAction(RoboDTO action, int LastActionOrder, string lastAction);
}