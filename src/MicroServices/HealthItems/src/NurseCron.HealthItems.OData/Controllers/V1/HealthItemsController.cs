using IkeMtz.NRSRx.Core.Models;
using NurseCron.HealthItems.Models;
using NurseCron.HealthItems.OData.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace NurseCron.HealthItems.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.V1_0)]
  [Authorize]
  [ODataRoutePrefix(nameof(HealthItems))]
  public class HealthItemsController : ODataController
  {
    private readonly IHealthItemsContext _ctx;

    public HealthItemsController(IHealthItemsContext ctx)
    {
      _ctx = ctx;
    }

    [Produces("application/json")]
    [ODataRoute]
    [ProducesResponseType(typeof(ODataEnvelope<HealthItem>), Status200OK)]
    [EnableQuery(MaxTop = 100, AllowedQueryOptions = All)]
    public IActionResult Get()
    {
      return Ok(_ctx.HealthItems.Where(t => t.IsEnabled));
    }
  }
}
