namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();

        private static readonly List<Category> _categories = new();



        static Repository()
        {
            _categories.Add(new Category { CategoryID = 1 , Name = "Telefon"});
            _categories.Add(new Category { CategoryID = 2 , Name = "Bilgisayar"});

            _products.Add(new Product {ProductID = 1 , Name = "IPhone 14" , Price = 35000 , isActive = true , CategoryID = 1 , Image = "1.jpg"});
            _products.Add(new Product {ProductID = 2 , Name = "IPhone 15 Pro", Price = 38800 , isActive = false , CategoryID = 1, Image = "2.jpg"});
            _products.Add(new Product {ProductID = 3 , Name = "IPhone 15 Pro-Max" , Price = 42000 , isActive = true , CategoryID = 1, Image = "3.jpg"});
            _products.Add(new Product {ProductID = 4 , Name = "Samsung S-23" , Price = 48000 , isActive = true , CategoryID = 1 , Image = "4.jpg"});


            _products.Add(new Product {ProductID = 5 , Name = "Macbook Air" , Price = 57700 , isActive = false , CategoryID = 2 , Image = "5.jpg"});
            _products.Add(new Product {ProductID = 6 , Name = "Macbook Pro" , Price = 79000 , isActive = true , CategoryID = 2 , Image = "6.jpg"});
            
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }


        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }


        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);

            if(entity != null)
            {
                if(!string.IsNullOrEmpty(updatedProduct.Name))
                {
                    entity.Name = updatedProduct.Name;
                }
                
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryID = updatedProduct.CategoryID;
                entity.isActive = updatedProduct.isActive;
            }
        }


        public static void EditisActive(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);

            if(entity != null)
            {
                entity.isActive = updatedProduct.isActive;
            }
        }


        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductID == deletedProduct.ProductID);

            if(entity != null)
            {
                _products.Remove(entity);
            }
        }


        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}