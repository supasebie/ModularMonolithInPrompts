using FastEndpoints.Testing;

using InPrompts.Prompts.PromptEndpoints;

namespace InPrompts.Prompts.Tests.Endpoints;

// [Collection(nameof(Fixture))]
// public class UpdateTextTest(Fixture fixture) : TestBase<Fixture>
// {
//   [Theory]
//   [InlineData("DFFE455B-8F20-4B08-9EC5-3B4A1FFC4D18", "What is your favorite sock type?")]

//   public async Task ReturnsUpdatedPromptWithNewText(string promptId, string newText)
//   {
//     var request = new UpdateTextRequest(Guid.Parse(promptId), newText);
//     var testResult = await fixture.Client.PutAsync<UpdateText, UpdateTextRequest, PromptDto>
//   }

// }
