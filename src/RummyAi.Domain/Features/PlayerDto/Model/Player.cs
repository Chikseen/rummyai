using RummyAi.Domain.Features.GameDto;
using RummyAi.Domain.Features.PlayerDto.Enum;
using System.Text.Json.Serialization;

namespace RummyAi.Domain.Features.PlayerDto.Model;

public class Player
{
    public PlayerId PlayerId { get; init; }
    public PlayerType PlayerType { get; init; }

    public Player(PlayerId id, PlayerType playerType)
    {
        PlayerId = id;
        PlayerType = playerType;
    }

    [JsonConstructor]
    public Player()
    { }
}