using BLL.BLO;
using Core.Interfaces;
using DAL.DAO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodsController : ControllerBase
{
    private IRepository<GoodDao> _repository;
    private IMapper<GoodBlo, GoodDao> _mapper;

    public GoodsController(IRepository<GoodDao> repository, IMapper<GoodBlo, GoodDao> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult Create([FromBody]GoodBlo bloGood)
    {
        _repository.Create(_mapper.ToDao(bloGood));
        
        return NoContent();
    }
    
    [HttpGet]
    public ActionResult<List<GoodBlo>> GetAll()
    {
        var daoGoods = _repository.ReadAll();
        var bloGoods = daoGoods.Select(o => _mapper.ToBlo(o)).ToList();
        
        return Ok(bloGoods);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<GoodBlo> GetById(Guid id)
    {
        var daoGood = _repository.Read(id);
        
        return daoGood is null ? NotFound() : _mapper.ToBlo(daoGood);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Update(Guid id, [FromBody] GoodBlo bloGood)
    {
        var existing = _repository.Read(id);
        if (existing is null) return NotFound();
        
        var daoGood = _mapper.ToDao(bloGood);
        daoGood.Id = id;
        
        _repository.Update(daoGood);
        
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