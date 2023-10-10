using BLL.DTO;
using BLL.Models;

namespace BLL.Interface.Repository;

public interface IRoboActionRepository
{
    IEnumerable<Robo> GetRoboAction();
    Task<bool> SendAction(Robo action);
}