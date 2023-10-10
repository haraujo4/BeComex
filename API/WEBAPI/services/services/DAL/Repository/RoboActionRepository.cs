using System.Data;
using BLL.DTO;
using BLL.Interface.Repository;
using BLL.Models;
using Dapper;

namespace DAL.Repository;

public class RoboActionRepository:IRoboActionRepository
{
    private readonly IDbConnection _connection;
    
    public RoboActionRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    private string query = @"SELECT RB.ID, BD.BODY_NAME, BI.BODY_ITEM_NAME, SD.SIDE, RB.ACTION_ORDER, AC.ACTION FROM ROBO RB
                    INNER JOIN BODY BD ON RB.BODY_ID = BD.ID
                    INNER JOIN BODY_ITEM BI ON RB.BODY_ITEM_ID = BI.ID
                    INNER JOIN SIDE SD ON RB.BODY_SIDE_ID = SD.ID
                    INNER JOIN ACTION AC ON RB.ACTION_ID = AC.ID";
    
    public IEnumerable<Robo> GetRoboAction()
    {
        try
        {
            var result = _connection.Query<Robo>(query);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in RoboActionRepository: " + ex.Message);
        }
    }

    public async Task<bool> SendAction(Robo action)
    {
        var where = query + " WHERE BODY_NAME = @Body_Name AND BODY_ITEM_NAME = @Body_Item_Name AND SIDE = @Side AND ACTION_ORDER = @Action_Order AND ACTION = @Action";
        try
        {
            var result = await _connection.QueryAsync(where, action);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error in RoboActionRepository: " + ex.Message);
        }
    }
}