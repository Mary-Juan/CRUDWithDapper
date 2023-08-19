using CRUDWithDapper.Models;
using CRUDWithDapper.Repositories;
using CRUDWithDapper.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithDapper.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _branchRepository.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _branchRepository.GetByIdAsync(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {

                await _branchRepository.CreateAsync(branch);
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var _Branch = await _branchRepository.GetByIdAsync(id);
            return View(_Branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Branch branch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    branch.Id = id;

                    await _branchRepository.UpdateAsync(branch);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var _Branch = await _branchRepository.GetByIdAsync(id);
            return View(_Branch);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _branchRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
