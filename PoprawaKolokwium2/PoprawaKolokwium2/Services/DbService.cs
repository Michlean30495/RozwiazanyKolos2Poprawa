using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2.Data;
using PoprawaKolokwium2.DTOs;
using PoprawaKolokwium2.Models;

namespace PoprawaKolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CharacterDto> GetCharacterById(int characterId)
    {
        var thisCharacter = await _context.Character
            .Where(c => c.CharacterId == characterId)
            .Select(c => new CharacterDto
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CurrentWeight = c.CurrentWeight,
                MaxWeight = c.MaxWeight,
                BackpackItems = c.Backpacks.Select(b => new ItemDto
                {
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount
                }).ToList(),
                Titles = c.CharacterTitles.Select(c => new TitleDto
                {
                    Title = c.Title.Name,
                    AquiredAt = c.AcquiredAt
                }).ToList()
                
            }).FirstOrDefaultAsync();
        
        if (thisCharacter is null)
            throw new Exception("Character not found");
        
        return thisCharacter;
    }

    public async Task AddItemToCharacterBackpack(List<int> itemIds, int characterId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            int udzwig = 0;
            int characterWeight = 0;
            var characterFromReq = _context.Character.FirstOrDefault(c => c.CharacterId == characterId);
            if (characterFromReq is null)
                throw new Exception("Character not found");

            characterWeight += characterFromReq.CurrentWeight;
            foreach (var id in itemIds)
            {
                var item = _context.Item.FirstOrDefault(i => i.ItemId == id);
                if (item is null)
                    throw new Exception("Item not found");

                udzwig += item.Weight;
            }
            
            if (characterFromReq.MaxWeight < (characterWeight + udzwig))
                throw new Exception("Max weight exceded");

            foreach (var itemId in itemIds)
            {
                var ExistingItem = _context.Item.FirstOrDefault(i => i.ItemId == itemId);
                if (ExistingItem is null)
                {
                    await _context.Backpack.AddAsync(new Backpack
                    {
                        CharacterId = characterId,
                        ItemId = itemId,
                        Amount = 1
                    });
                }
                else
                {
                    var thisBackpack = _context.Backpack.FirstOrDefault(b => b.ItemId == itemId);
                    if (thisBackpack is null)
                        throw new Exception("Item not found");
                    thisBackpack.Amount++;
                }
            }
            characterFromReq.CurrentWeight = characterWeight + udzwig;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("transakcja nie tak");
        }
    }
}