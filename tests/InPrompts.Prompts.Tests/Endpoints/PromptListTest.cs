using FastEndpoints;
using FastEndpoints.Testing;

using FluentAssertions;

using InPrompts.Prompts.PromptEndpoints;

namespace InPrompts.Prompts.Tests.Endpoints;

[Collection(nameof(Fixture))]
public class PromptListTest(Fixture fixture) : TestBase<Fixture>
{
  [Fact]
  public async Task ReturnsThreeBooksAsync()
  {
    var testResult = await fixture.Client.GETAsync<List, ListPromptResponse>();
    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Prompts.Should().HaveCount(3);
  }
}