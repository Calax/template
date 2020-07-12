using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Template.Client.Dto;
using Service.Template.Repository.Bo.Sample;

namespace Service.Template.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleTableRepository    repository;
        private readonly ILogger<SampleController> logger;

        public SampleController(ISampleTableRepository repository, ILogger<SampleController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sample>>> ListAsync()
        {
            return (await repository.ListAsync(CancellationToken.None))
                .Select(Adapt)
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Sample>> GetAsync(long id)
        {
            return Adapt(await repository.GetAsync(id, CancellationToken.None));
        }

        [HttpPost]
        public async Task<ActionResult<Sample>> PostAsync([FromBody] SampleInput input)
        {
            var id = await repository.InsertAsync(new SampleTable {IndexedColumn = DateTime.Now, CustomTypeColumn = input.Text},
                CancellationToken.None);
            return Adapt(await repository.GetAsync(id, CancellationToken.None));
        }

        private static Sample Adapt(SampleTable source)
        {
            return new Sample
            {
                Id = source.Id,
                IndexedColumn = source.IndexedColumn,
                CustomTypeColumn = source.CustomTypeColumn
            };
        }
    }
}