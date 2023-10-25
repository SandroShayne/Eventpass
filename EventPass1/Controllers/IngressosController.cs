using EventPass1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventPass1.Controllers
{
    [Authorize] 
    public class IngressosController : Controller
    {
        private readonly AppDbContext _context;

        public IngressosController(AppDbContext context)
        {
            _context = context;
        }

        // Método para resgatar ingressos de um evento
        public async Task<IActionResult> Ingressos(int idEvento, int quantidade)
        {
            
            var evento = await _context.Eventos.FindAsync(idEvento);

            if (evento == null)
            {
                return NotFound(); // Evento não encontrado
            }

            // Verifique se a quantidade solicitada é válida (até 3 ingressos)
            if (quantidade <= 0 || quantidade > 3)
            {
                return BadRequest("A quantidade de ingressos é inválida.");
            }

            // Verifique se ainda há ingressos disponíveis
            if (evento.TotalIngressos < quantidade)
            {
                return BadRequest("Não há ingressos disponíveis suficientes.");
            }

            // Faça a lógica para reservar os ingressos aqui
            // Por exemplo, você pode criar uma tabela de reservas e associá-las ao usuário logado

            // Reduza a contagem de ingressos disponíveis
            evento.TotalIngressos -= quantidade;

            // Salve as alterações no banco de dados
            _context.SaveChanges();

            // Redirecione o usuário para alguma página de confirmação
            return RedirectToAction("Confirmacao");
        }

        public IActionResult Confirmacao()
        {
            return View();
        }
    }
}
