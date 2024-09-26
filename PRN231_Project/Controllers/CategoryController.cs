using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231_Project.Models;

namespace PRN231_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly PRN231_ProjectContext _context;
        public CategoryController(PRN231_ProjectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetAllCategory()
        {
            var list = _context.Categories.ToList();
            return Ok(list);
        }
        [HttpGet]
        public ActionResult GetCategoryById(int id)
        {
            var list = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddCategory(string categoryName, string description)
        {
            try
            {
                Category newCate = new Category()
                {
                    CategoryName = categoryName,
                    Description = description
                };
                _context.Categories.Add(newCate);
                _context.SaveChanges();
                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult UpdateCategory(int id, string name, string description)
        {
            try
            {
                var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (cate == null)
                {
                    return BadRequest("Category not found");
                }
                cate.CategoryName = name;
                cate.Description = description;
                _context.SaveChanges();
                return Ok("Change name succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult UpdateCategoryName(int id, string CategoryName)
        {
            try
            {
                var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (cate == null)
                {
                    return BadRequest("Category not found");
                }
                cate.CategoryName = CategoryName;
                _context.SaveChanges();
                return Ok("Change name succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult UpdateCategoryDescription(int id, string description)
        {
            try
            {
                var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (cate == null)
                {
                    return BadRequest("Category not found");
                }
                cate.Description = description;
                _context.SaveChanges();
                return Ok("Change description successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                //include them ca product
                if (cate == null)
                {
                    return BadRequest("Category not found");
                }
                _context.Categories.Remove(cate);
                _context.SaveChanges();
                return Ok("Delete successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
