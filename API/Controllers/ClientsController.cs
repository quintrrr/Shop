using BLL.BLO;
using Core.Interfaces;
using DAL.DAO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private IRepository<AccountDao> _repository;
    private IMapper<ClientBlo, AccountDao> _mapper;

    public ClientsController(IRepository<AccountDao> repository, IMapper<ClientBlo, AccountDao> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult Create([FromBody]ClientBlo bloClient)
    {
        _repository.Create(_mapper.ToDao(bloClient));
        
        return NoContent();
    }
    
    [HttpGet]
    public ActionResult<List<ClientBlo>> GetAll()
    {
        var daoAccounts = _repository.ReadAll();
        var bloClients = daoAccounts.Select(o => _mapper.ToBlo(o)).ToList();
        
        return Ok(bloClients);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ClientBlo> GetById(Guid id)
    {
        var daoAccount = _repository.Read(id);
        
        return daoAccount is null ? NotFound() : _mapper.ToBlo(daoAccount);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Update(Guid id, [FromBody] ClientBlo bloClient)
    {
        var existing = _repository.Read(id);
        if (existing is null) return NotFound();
        
        var daoAcoount = _mapper.ToDao(bloClient);
        daoAcoount.Id = id;
        
        _repository.Update(daoAcoount);
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var existing = _repository.Read(id);
        if (existing is null) return NotFound();
        
        _repository.Delete(id);
        
        return NoContent();
    }
}