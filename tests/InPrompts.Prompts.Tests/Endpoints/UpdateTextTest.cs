using System.Net;

using FastEndpoints;
using FastEndpoints.Testing;

using FluentAssertions;

using InPrompts.Prompts.PromptEndpoints;

namespace InPrompts.Prompts.Tests.Endpoints;

// [Collection(nameof(Fixture))]
// public class UpdateTextTests(Fixture fixture) : TestBase<Fixture>
// {
//   [Fact]
//   public async Task UpdatesTextExpectedly()
//   {
//     var createdPrompt = await CreatePrompt();
//     var updatePromptRequest = new UpdatePromptTextRequest(createdPrompt.Id, "Text from update endpoint testbed");
//     var updateResponse = await fixture.Client.POSTAsync<UpdatePromptText, UpdatePromptTextRequest, PromptDto>(updatePromptRequest);
//     updateResponse.Response.EnsureSuccessStatusCode();
//     updateResponse.Result.Text.Should().Be("Text from update endpoint testbed");
//   }

//   [Fact]
//   public async Task DoesNotAllowEmptyText()
//   {
//     var createdPrompt = await CreatePrompt();
//     var updatePromptRequest = new UpdatePromptTextRequest(createdPrompt.Id, "");
//     var updateResponse = await fixture.Client.POSTAsync<UpdatePromptText, UpdatePromptTextRequest, PromptDto>(updatePromptRequest);
//     updateResponse.Response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
//   }

//   // private async Task<PromptDto> CreatePrompt()
//   // {
//   //   var createPromptRequest = new Prompt
//   //   {
//   //     Id = Guid.NewGuid(),
//   //     Text = "Modular Monoliths - Getting Started",
//   //     User = "Steve Smith",
//   //     ViewCount = 238
//   //   };
//   //   var createResponse = await fixture.Client.POSTAsync<Create, CreatePromptRequest, PromptDto>(createPromptRequest);
//   //   createResponse.Response.EnsureSuccessStatusCode();
//   //   return createResponse.Result;
//   // }
// }
