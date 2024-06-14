using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext context)
        {
            _db = context;
        }


        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;

            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        //POST: Emprestimo/Cadastrar
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(EmprestimosModel model)
        {
            
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(model);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro Realizado com sucesso";

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimos = _db.Emprestimos.FirstOrDefault(emp => emp.Id == id);

            if (emprestimos == null)
            {
                return NotFound();
            }

            return View(emprestimos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EmprestimosModel memprestimo)
        {

            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(memprestimo);
                _db.SaveChanges();
                //msg
                TempData["MensagemSucesso"] = "Edição Realizado com sucesso";

                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Ocorreu um erro com a solicitação.";

            return View(memprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
       
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null) {
                return NotFound();  
            }

            

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Excluido com sucesso";
            return RedirectToAction("Index");

            return View(emprestimo);
        }
    }
}
