using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
            
    }



    [HttpGet]
    public IActionResult Index(string searchq, string category)
    {
        var products = Repository.Products;
        
        
        if(!String.IsNullOrEmpty(searchq))
        {
            ViewBag.Searchq = searchq;
            products = products.Where(p => p.Name.ToLower().Contains(searchq)).ToList();
        }
        

        if(!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryID == int.Parse(category)).ToList();
        }

        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryID", "Name", category);

        var model = new ProductViewModel 
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        
        return View(model);
    }


    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories =  new SelectList(Repository.Categories, "CategoryID", "Name");
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)

    {  
        var extension = "";
        if(imageFile != null) {
            var allowedExtensions = new[] {".jpg", "jpeg", "png"};
            extension = Path.GetExtension(imageFile.FileName);    
            
            if(!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Geçerli bir Görsel seçiniz.");
            }
        }

       
        if(ModelState.IsValid)
        
        {   
            if(imageFile != null)
            {
                var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = randomFileName;
                model.ProductID = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }
       
        }
        ViewBag.Categories =  new SelectList(Repository.Categories, "CategoryID", "Name");
        return View(model);
    }



    public IActionResult Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductID == id);
        if(entity == null)
        {
            return NotFound();
        }
        ViewBag.Categories =  new SelectList(Repository.Categories, "CategoryID", "Name");
        return View(entity);
    }



    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {
        if(id != model.ProductID)
        {
            return NotFound();
        }
        
        if(ModelState.IsValid)

        {

            if(imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = randomFileName;
            }
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories =  new SelectList(Repository.Categories, "CategoryID", "Name");
        return View(model);
    }



    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductID == id);
        if(entity == null)
        {
            return NotFound();
        }
        
        return View("DeleteConfirm", entity);
    }

    [HttpPost]
    public IActionResult Delete(int id, int ProductID)
    {
        if(id != ProductID)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
        if(entity == null)
        {
            return NotFound();
        }

        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");

    }

    [HttpPost]
    public IActionResult EditProducts(List<Product> Products)
    {
        foreach (var product in Products)
        {
            Repository.EditisActive(product);
        }
        return RedirectToAction("Index");
    }

}
