using AutoMapper;
using IrentaFormTestBackend.Data;
using IrentaFormTestBackend.Models;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult> CreateOwnershipForm(OwnershipFormModelDto ownershipFormModelDto)
    {
        var ownershipFormModel = _mapper.Map<OwnershipFormModel>(ownershipFormModelDto);

        _db.OwnershipFormModels.Add(ownershipFormModel);
        await _db.SaveChangesAsync();
        _logger.LogTrace("Insert ownershipFormModel");

        return Ok();
    }
}