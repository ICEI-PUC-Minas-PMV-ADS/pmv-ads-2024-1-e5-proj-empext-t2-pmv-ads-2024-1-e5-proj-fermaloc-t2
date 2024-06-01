using AutoMapper;
using Fermaloc.Application.DTOs.EquipamentClicksDTO;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class EquipamentClicksService : IEquipamentClicksService
{
    private readonly IEquipamentClicksRepository _equipamentClicksRepository;
    private readonly IEquipamentService _equipamentService;
    private readonly IMapper _mapper;

    public EquipamentClicksService(IEquipamentClicksRepository equipamentClicksRepository, IMapper mapper, IEquipamentService equipamentService)
    {
        _equipamentClicksRepository = equipamentClicksRepository;
        _equipamentService = equipamentService;
        _mapper = mapper;
    }
    

    public async Task AddClickAsync(EquipamentClicksDto equipamentClicksDto)
    {
        var equipament = await _equipamentService.GetEquipamentByIdAsync(equipamentClicksDto.EquipamentId);
        if (equipament == null)
        {
            throw new InvalidDataException("Equipamento não encontrado");
        }
        var equipamentClicks = await _equipamentClicksRepository.GetEquipamentClickOnDate(equipamentClicksDto.Date, equipamentClicksDto.EquipamentId);
        if (equipamentClicks == null)
        {
            await _equipamentClicksRepository.CreateClickAsync(equipamentClicksDto.EquipamentId, equipamentClicksDto.Date);
            return;
        }
        await _equipamentClicksRepository.AddClickAsync(equipamentClicksDto.Date, equipamentClicks);
    }

    public async Task<IEnumerable<EquipamentClicks>> GetClicksBetweenDatesAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _equipamentClicksRepository.GetClicksBetweenDatesAsync(startDate, endDate);
         
    }
}