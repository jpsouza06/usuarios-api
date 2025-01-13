using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtoos;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    async public Task<IActionResult>  CadastraUsuario
        (CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);

        return Ok("Usuário Cadastrado!");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }
}
