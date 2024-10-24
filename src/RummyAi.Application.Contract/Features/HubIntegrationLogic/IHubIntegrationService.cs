using RummyAi.Domain.Features.GameDto.Models;
using RummyAi.Domain.Features.PlayerDto.Model;

namespace RummyAi.Application.Contract.Features.HubIntegrationLogic;

public interface IHubIntegrationService
{
    void AddPlayerToGroup(Game game, PlayerConnection playerConnection);
    void SendNewGameStatusToGroup(Game game);
}