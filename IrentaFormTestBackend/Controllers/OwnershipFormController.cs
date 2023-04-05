using AutoMapper;
using IrentaFormTestBackend.Data;
using IrentaFormTestBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IrentaFormTestBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnershipFormController : ControllerBase
{
    private readonly ILogger<OwnershipFormController> _logger;
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public OwnershipFormController(ILogger<OwnershipFormController> logger, ApplicationDbContext applicationDbContext, IMapper iMapper)
    {
        _logger = logger;
        _db = applicationDbContext;
        _mapper = iMapper;
    }

    [HttpPost(Name = "ownership-form")]
    public async Task<ActionResult> CreateOwnershipForm([FromBody] CreateOwnershipFormModelDto createOwnershipFormModelDto)
    {
        var ownershipFormModel = _mapper.Map<OwnershipFormModel>(createOwnershipFormModelDto);

        _db.OwnershipFormModels.Add(ownershipFormModel);
        await _db.SaveChangesAsync();
        _logger.LogTrace("Insert ownershipFormModel");

        return Ok();
    }


    [HttpGet("ownership-form")]
    public async Task<ActionResult<List<OwnershipFormModel>>> GetAllOwnershipForms()
    {
        List<OwnershipFormModel> ownershipFormModel = await _db.OwnershipFormModels.Include(o => o.OwnershipBankDetailsList).ToListAsync();

        return ownershipFormModel;
    }
    [HttpGet("ownership-form/[[id]]")]
    public async Task<ActionResult<OwnershipFormModel>> GetOwnershipForm(ulong id)
    {
        OwnershipFormModel ownershipFormModel = await _db.OwnershipFormModels.Where(o => o.Id == id).Include(o => o.OwnershipBankDetailsList)
            .FirstOrDefaultAsync();

        if (ownershipFormModel == null) return NotFound();
        return ownershipFormModel;
    }
}