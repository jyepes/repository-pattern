using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Generic;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumesController : Controller
    {
        private readonly IGenericRepository<Album> repository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumesController(IGenericRepository<Album> _repository, IUnitOfWork _unitOfWork)
        {
            repository = _repository;
            unitOfWork = _unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            var albumes = await repository.GetAsync();
            return Ok(albumes);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Album album)
        {
            await repository.CreateAsync(album);
            unitOfWork.Commit();

            return Created("Created", new { Response = StatusCode(201) });
        }
    }
}
