using System.Text;
using System.Text.Json.Nodes;
using AutoMapper;
using Dadata;
using IrentaFormTestBackend.Data;
using IrentaFormTestBackend.Models;
using IrentaFormTestBackend.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IrentaFormTestBackend.Controllers;

[ApiController]
[Route("api/ownership-form")]
public class OwnershipFormController : ControllerBase
{
    private readonly ILogger<OwnershipFormController> _logger;
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _appEnvironment;
    private readonly IConfiguration _config;

    public OwnershipFormController(ILogger<OwnershipFormController> logger, ApplicationDbContext applicationDbContext, IMapper iMapper, IWebHostEnvironment appEnvironment, IConfiguration config)
    {
        _logger = logger;
        _db = applicationDbContext;
        _mapper = iMapper;
        _appEnvironment = appEnvironment;
        _config = config;
    }

    [HttpPost ( "upload-img")]
    public async Task<ActionResult<ulong>> UploadOwnershipFormImg(IFormFile uploadedFile)
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

    [HttpPost ("ip")]
    public async Task<ActionResult> CreateOwnershipIpForm([FromBody]CreateOwnershipFormIpModelDto createOwnershipFormIpModelDto)
    {
        var ownershipFormModel = _mapper.Map<OwnershipFormModel>(createOwnershipFormIpModelDto);

        _db.OwnershipFormModels.Add(ownershipFormModel);
        await _db.SaveChangesAsync();

        return Ok();
    }
    [HttpPost ("ooo")]
    public async Task<ActionResult> CreateOwnershipOooForm([FromBody]CreateOwnershipFormOooModelDto createOwnershipFormOooModelDto)
    {
        var ownershipFormModel = _mapper.Map<OwnershipFormModel>(createOwnershipFormOooModelDto);

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
            .Include(o => o.ScanOgrn)
            .Include(o => o.ScanOgrnip)
            .Include(o => o.ScanEgrip)
            .Include(o => o.ScanLeaseAgreement)
            .ToListAsync();

        return ownershipFormModel;
    }
    [HttpGet ("{id}")]
    public async Task<ActionResult<OwnershipFormModel>> GetOwnershipForm(ulong id)
    {
        OwnershipFormModel ownershipFormModel = await _db.OwnershipFormModels.Where(o => o.Id == id)
            .Include(o => o.OwnershipBankDetailsList)
            .Include(o => o.ScanInn)
            .Include(o => o.ScanOgrn)
            .Include(o => o.ScanOgrnip)
            .Include(o => o.ScanEgrip)
            .Include(o => o.ScanLeaseAgreement)
            .FirstOrDefaultAsync();

        if (ownershipFormModel == null) return NotFound();
        return ownershipFormModel;
    }

    [HttpGet ("org-data-by-inn/{inn}")]
    public async Task<ActionResult> GetOrganizationDataByInn(ulong inn)
    {
        if (inn.ToString().Length != 10 && inn.ToString().Length != 12)
            return BadRequest("Value must have 10 or 12 symbols!");

        var token = _config.GetValue<string>("DadataAPIKey");

        var request = new HttpRequestMessage() {
            RequestUri = new Uri("https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party"),
            Method = HttpMethod.Post,
            Headers =
            {
                { "Accept", "application/json" },
                { "Authorization", $"Token {token}" }
            },
            Content = new StringContent("{\"query\": \"" + inn + "\"}", Encoding.UTF8, "application/json")
        };

        HttpClient httpClient = new HttpClient();

        var response  = await httpClient.SendAsync(request);
        string resultJson = await response.Content.ReadAsStringAsync();
        var jsonObject = JObject.Parse(resultJson);
        return Content(jsonObject.ToString(), "application/json");
    }
}