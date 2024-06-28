using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Renovate.Client.Tests;

[Collection("Collection")]
public class RenovateClientUtilTests : FixturedUnitTest
{
    private readonly IRenovateClient _util;

    public RenovateClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRenovateClient>(true);
    }
}
