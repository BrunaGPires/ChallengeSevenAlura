using AutoMapper;
using Challenge.Data;
using Challenge.Data.Dtos;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Services
{
    public class DepoimentoService
    {
        private DepoimentoContext _context;
        private IMapper _mapper;

        public DepoimentoService(IMapper mapper, DepoimentoContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task AdicionaDepoimento(CreateDepoimento dto)
        {
            Depoimentos depoimentos = _mapper.Map<Depoimentos>(dto);
            var resultado = await _context.Depoimentos.AddAsync(depoimentos);
            if(resultado.State != EntityState.Added)
            {
                throw new Exception("Falha ao cadastrar depoimento.");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadDepoimento>> RecuperaDepoimentosAleatorios()
        {
            Random rnd = new Random();
            var depoimentos = await RecuperaDepoimentos();
            var resultado = depoimentos.OrderBy(x => Guid.NewGuid()).Take(3);
            return resultado;
        }

        public async Task<IEnumerable<ReadDepoimento>> RecuperaDepoimentos()
        {
            IEnumerable<Depoimentos> depoimentos = await _context.Depoimentos.ToListAsync();
            IEnumerable<ReadDepoimento> depoimentosDto = _mapper.Map<List<ReadDepoimento>>(depoimentos);
            return depoimentosDto;
        }

        public async Task AtualizaDepoimento(UpdateDepoimento dto, int id)
        {
            var depoimento = await _context.Depoimentos.FirstOrDefaultAsync(depoimento => depoimento.Id == id);
            if(depoimento == null) throw new Exception("Id invalido.");
            Depoimentos depoimentos = _mapper.Map(dto,depoimento);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDepoimento(int id)
        {
            var depoimento = await _context.Depoimentos.FirstOrDefaultAsync(depoimento => depoimento.Id == id);
            if(depoimento == null) throw new Exception("Id invalido.");
            _context.Remove(depoimento);
            await _context.SaveChangesAsync();
        }
    }
}