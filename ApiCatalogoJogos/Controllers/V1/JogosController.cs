using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;
    
       public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
           var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();
               
            return Ok(jogos);
        }        

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>>> Obter(Guid idJogo)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);
            if (jogos.Count() == 0)
                return NoContent();
        }
        public async Task<ActionResult<List<JogoViewModel>>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody]) JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(JogoInputModel);
                
                return Ok(jogo)
            }
            //catch (JogoIaCadastradoException ex)
            {
                return UnprocessableEntity ("Já existe um jogo com este nome para esta produtora" )
            }
        }
        
        [HttpPut("{idJogo: guid})")]
        public async Task<ActionResult>AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPatch("{idJogo: guid}/preco/{preco:double})")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<AcceptedAtActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }


    }
}
