using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextToPhoneticAPI.Models;

namespace TextToPhoneticAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhoneticConversionController(HttpClient httpClient) : ControllerBase
{
    private const string Path = "http://localhost:3000/convert";
    [HttpPost]
    public async Task<ActionResult<PhoneticOutputModel>> ConvertToPhonetic([FromBody] TextInputModel? input)
    {
        if (input == null || string.IsNullOrEmpty(input.Text))
        {
            return BadRequest("Input is null or empty");
        }

        var response = await httpClient.PostAsJsonAsync(Path, new { text = input.Text });

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Error calling converting service.");
        }
        
        var output = await response.Content.ReadFromJsonAsync<PhoneticOutputWrapper>();

        return output != null ? Ok(output.Result) : StatusCode((int)response.StatusCode, "Error calling converting service.");
    }
}