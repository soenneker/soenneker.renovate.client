using Soenneker.Renovate.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Renovate.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class RenovateClientTests : HostedUnitTest
{
    private readonly IRenovateClient _util;

    public RenovateClientTests(Host host) : base(host)
    {
        _util = Resolve<IRenovateClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
