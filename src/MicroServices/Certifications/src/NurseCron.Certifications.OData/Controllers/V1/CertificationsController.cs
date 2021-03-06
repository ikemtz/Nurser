using NurseCron.Certifications.Abstraction.Models;
using NurseCron.Certifications.OData.Data;
using IkeMtz.NRSRx.Core.Authorization;
using IkeMtz.NRSRx.Core.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;
using NurseCron.Certifications.Abstraction;
using NurseCron.Seurity;

namespace NurseCron.Certifications.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.V1_0)]
  [Authorize]
  [ODataRoutePrefix(nameof(Certifications))]
  public class CertificationsController : ODataController
  {
    private readonly ICertificationsContext _ctx;
    public CertificationsController(ICertificationsContext ctx)
    {
      _ctx = ctx;
    }

    [PermissionsFilter(new[] { Permissions.ReadCertifications })]
    [Produces("application/json")]
    [ODataRoute]
    [ProducesResponseType(typeof(ODataEnvelope<Certification>), Status200OK)]
    [EnableQuery(MaxTop = 100, AllowedQueryOptions = All)]
    public IActionResult Get()
    {
      return Ok(_ctx.Certifications.Where(t => t.IsEnabled));
    }
  }
}
