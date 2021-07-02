using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErroMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]

        [Required]
        [StringLength(100, MinimumLength = 1, ErroMessage = "O nome da Produtora deve conter entre 3 e 100 caracteres")]

        [Required]
        [Range(1, 1000, ErroMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]

        public double Preco { get; set; }
        
        ]
    }
}
