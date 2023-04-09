using AutoMapper;
using IrentaFormTestBackend.Data;
using IrentaFormTestBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IrentaFormTestBackend.Controllers;

[ApiController]
[Route("api/ownership-form")]
public class OwnershipFormController : ControllerBase
{
    private readonly ILogger<OwnershipFormController> _logger;
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _appEnvironment;

    public OwnershipFormController(ILogger<OwnershipFormController> logger, ApplicationDbContext applicationDbContext, IMapper iMapper, IWebHostEnvironment appEnvironment)
    {
        _logger = logger;
        _db = applicationDbContext;
        _mapper = iMapper;
        _appEnvironment = appEnvironment;
    }

    [HttpPost ( "upload-imgs")]
    public async Task<ActionResult<ulong>> UploadOwnershipFormImgs(IFormFile uploadedFile)
    {
        if (uploadedFile.Length > 1024 * 1024 * 1) return BadRequest("Max file size: 1MB");
        if (!uploadedFile.ContentType.Contains("image") && !uploadedFile.ContentType.Contains("pdf"))
            return BadRequest($"{uploadedFile.ContentType} not allowed!");
        FileModel file = new FileModel { Path = "" };
        _db.FileModels.Add(file);
        await _db.SaveChangesAsync(); // Or we can make guid

        var directory = Directory.GetCurrentDirectory();

        Directory.CreateDirectory(Path.Combine(directory, "OwnershipFormUploads"));
        file.Path = Path.Combine("OwnershipFormUploads", file.Id.ToString()+ Path.GetExtension(uploadedFile.FileName));
        _db.FileModels.Update(file);

        using (var fileStream = new FileStream(Path.Combine(directory, file.Path), FileMode.Create))
        {
            await uploadedFile.CopyToAsync(fileStream);
        }

        _db.SaveChanges();
        return file.Id;
    }

    [HttpPost ("")]
    public async Task<ActionResult> CreateOwnershipForm([FromBody]CreateOwnershipFormModelDto createOwnershipFormModelDto)
    {
        var ownershipFormModel = _mapper.Map<OwnershipFormModel>(createOwnershipFormModelDto);

        _db.OwnershipFormModels.Add(ownershipFormModel);
        await _db.SaveChangesAsync();

        return Ok();
    }


    [HttpGet ("")]
    public async Task<ActionResult<List<OwnershipFormModel>>> GetAllOwnershipForms()
    {
        List<OwnershipFormModel> ownershipFormModel = await _db.OwnershipFormModels
            .Include(o => o.OwnershipBankDetailsList)
            .Include(o => o.ScanInn)
            .Include(o => o.ScanOgrnip)
            .Include(o => o.ScanEgrip)
            .Include(o => o.ScanLeaseAgreement)
            .ToListAsync();

        return ownershipFormModel;
    }
    [HttpGet ("[[id]]")]
    public async Task<ActionResult<OwnershipFormModel>> GetOwnershipForm(ulong id)
    {
        OwnershipFormModel ownershipFormModel = await _db.OwnershipFormModels.Where(o => o.Id == id)
            .Include(o => o.OwnershipBankDetailsList)
            .Include(o => o.ScanInn)
            .Include(o => o.ScanOgrnip)
            .Include(o => o.ScanEgrip)
            .Include(o => o.ScanLeaseAgreement)
            .FirstOrDefaultAsync();

        if (ownershipFormModel == null) return NotFound();
        return ownershipFormModel;
    }
}