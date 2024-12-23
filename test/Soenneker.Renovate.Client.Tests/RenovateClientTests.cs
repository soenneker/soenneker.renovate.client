using Soenneker.Renovate.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Renovate.Client.Tests;

[Collection("Collection")]
public class RenovateClientTests : FixturedUnitTest
{
    private readonly IRenovateClient _util;

    public RenovateClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRenovateClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
