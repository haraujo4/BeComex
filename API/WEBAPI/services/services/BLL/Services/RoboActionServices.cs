using BLL.DTO;
using BLL.Helpers;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Models;

namespace BLL.Services;

public class RoboActionServices:IRoboActionServices
{
    private readonly IRoboActionRepository _repository;
    public RoboActionServices(IRoboActionRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<Robo> GetRoboAction()
    {
        return _repository.GetRoboAction();
    }

    public async Task<bool> SendAction(RoboDTO action, int LastActionOrder, string lastAction)
    {
        var robo = new Robo
        {
            Body_Name = action.Body_Name,
            Body_Item_Name = action.Body_Item_Name,
            Side = action.Side,
            Action_Order = action.Action_Order,
            Action = action.Action
        };

        var result = await _repository.SendAction(robo);

        if (!result)
        {
            return false;
        }

        switch (action.Body_Name)
        {
            case "BRACO":
                if (action.Body_Item_Name == "PULSO" && !Rules.CanMoveWrist(lastAction))
                {
                    return Rules.StateProgression(action.Action_Order, LastActionOrder);
                }
                else if(action.Body_Item_Name == "COTOVELO")
                {
                    return Rules.StateProgression(action.Action_Order, LastActionOrder);
                }
                break;

            case "CABECA":
                if (Rules.RotateHead(lastAction))
                {
                    return Rules.StateProgression(action.Action_Order, LastActionOrder);
                }
                break;
        }

        return false;
    }

}