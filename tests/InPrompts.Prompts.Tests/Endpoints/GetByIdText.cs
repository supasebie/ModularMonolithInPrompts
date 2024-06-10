

using FastEndpoints;
using FastEndpoints.Testing;

using FluentAssertions;

using InPrompts.Prompts.PromptEndpoints;

namespace InPrompts.Prompts.Tests.Endpoints;

[Collection(nameof(Fixture))]
public class GetByIdTests(Fixture fixture) : TestBase<Fixture>
{
  [Theory]
  [InlineData("DFFE455B-8F20-4B08-9EC5-3B4A1FFC4D18", "What is your favorite color?")]
  [InlineData("F8E9B841-E4AD-45ED-A68C-04E5EDD375FC", "What is your favorite food?")]
  [InlineData("BBB5A494-3CED-4E39-9BC9-59E1AC8123A1", "What is your favorite movie?")]

  public async Task ReturnsExpectedPromptGivenId(string promptId, string expectedText)
  {
    var request = new GetPromptByIdRequest(Guid.Parse(promptId));
    var testResult = await fixture.Client.GETAsync<GetById, GetPromptByIdRequest, PromptDto>(request);

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Text.Should().Be(expectedText);
  }
}
