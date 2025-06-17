using PoprawaKolokwium2.DTOs;

namespace PoprawaKolokwium2.Services;

public interface IDbService
{
    Task<CharacterDto> GetCharacterById(int characterId);
    Task AddItemToCharacterBackpack(List<int> itemIds, int characterId);
}