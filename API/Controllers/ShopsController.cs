using BLL.BLO;
using Core.Interfaces;
using DAL.DAO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopsController : ControllerBase
{
    private IRepository<ShopDao> _repository;
    private IMapper<ShopBlo, ShopDao> _mapper;

    public ShopsController(IRepository<ShopDao> repository, IMapper<ShopBlo, ShopDao> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpPost]
    public ActionResult Create([FromBody]ShopBlo bloShop)
    {
        _repository.Create(_mapper.ToDao(bloShop));
        
        return NoContent();
    }
    
    [HttpGet]
    public ActionResult<List<ShopBlo>> GetAll()
    {
        var daoShops = _repository.ReadAll();
        var bloShops = daoShops.Select(o => _mapper.ToBlo(o)).ToList();
        
        return Ok(bloShops);
    }
    
    [HttpGet("{id:guid}")]
    public ActionResult<ShopBlo> GetById(Guid id)
    {
        var daoShop = _repository.Read(id);
        
        return daoShop is null ? NotFound() : _mapper.ToBlo(daoShop);
    }
    
    [HttpPut("{id:guid}")]
    public ActionResult Update(Guid id, [FromBody] ShopBlo bloShop)
    {
        var existing = _repository.Read(id);
        if (existing is null) return NotFound();
        
        var daoShop = _mapper.ToDao(bloShop);
        daoShop.Id = id;
        
        _repository.Update(daoShop);
        
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