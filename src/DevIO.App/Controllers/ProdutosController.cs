#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevIO.App.Data;
using DevIO.App.ViewModels;
using DevIO.Data.Repository;
using AutoMapper;

namespace DevIO.App.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoRepository _ProdutoRepository;
        private readonly FornecedorRepository _FornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(ProdutoRepository context, FornecedorRepository fcontext, IMapper mapper)
        {
            _ProdutoRepository = context;
            _FornecedorRepository = fcontext;
            _mapper = mapper;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdutoViewModel.Include(p => p.Fornecedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorViewModel, "Id", "Documento");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,FornecedorId,Descricao,Imagem,Valor,Ativo")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                produtoViewModel.Id = Guid.NewGuid();
                _context.Add(produtoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorViewModel, "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel.FindAsync(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorViewModel, "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,FornecedorId,Descricao,Imagem,Valor,Ativo")] ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoViewModelExists(produtoViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.FornecedorViewModel, "Id", "Documento", produtoViewModel.FornecedorId);
            return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModel
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await _context.ProdutoViewModel.FindAsync(id);
            _context.ProdutoViewModel.Remove(produtoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _ProdutoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _FornecedorRepository.ObterTodos());
            return produto;
        }
    }
}
