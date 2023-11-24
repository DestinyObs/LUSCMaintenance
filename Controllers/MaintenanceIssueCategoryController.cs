using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;

namespace LUSC_e_Maintenance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceIssueCategoryController : ControllerBase
    {
        private readonly IMaintenanceIssueCategoryRepository _categoryRepository;

        public MaintenanceIssueCategoryController(IMaintenanceIssueCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceIssueCategory>>> GetMaintenanceIssueCategories()
        {
            var categories = await _categoryRepository.GetMaintenanceIssueCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceIssueCategory>> GetMaintenanceIssueCategoryById(int id)
        {
            var category = await _categoryRepository.GetMaintenanceIssueCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> AddMaintenanceIssueCategory([FromBody] MaintenanceIssueCategory category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            await _categoryRepository.AddMaintenanceIssueCategoryAsync(category);
            return Ok("Category added successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaintenanceIssueCategory(int id, [FromBody] MaintenanceIssueCategory category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            var existingCategory = await _categoryRepository.GetMaintenanceIssueCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }

            existingCategory.Name = category.Name;
            await _categoryRepository.UpdateMaintenanceIssueCategoryAsync(existingCategory);
            return Ok("Category updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaintenanceIssueCategory(int id)
        {
            var existingCategory = await _categoryRepository.GetMaintenanceIssueCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }

            await _categoryRepository.DeleteMaintenanceIssueCategoryAsync(id);
            return Ok("Category deleted successfully");
        }
    }
}
