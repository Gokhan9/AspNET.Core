namespace basics.Models{
    public class Repository{
        private static readonly List<Course> _courses= new();

        static Repository()
        {
            _courses = new List<Course>()
            {
                new Course()  { 
                    Id = 1, 
                    Title = "ASP.NET Core Kursu", 
                    Description = "ASP.Net Core, Microsoft tarafindan geliştirilen açik kaynak kodlu bir yazilim geliştirme platformudur.", 
                    Version = "Asp.NET 8.0", 
                    Image = "aspnet.jpg",
                    Tags = new string[] {"aspnetcore", "web geliştirme", "önyüz geliştirme"},
                    isActive = true,
                    isHome = true
                },
                    
                new Course()  { 
                    Id = 2, 
                    Title = "React Native", 
                    Description = "React Native, Facebook tarafindan geliştirilen açik kaynakli bir mobil uygulama geliştirme çerçevesidir.", 
                    Version = "5.0", 
                    Image = "reactNative.jpg",
                    Tags = new string[] {"reactnative", "react"},
                    isActive = true,
                    isHome = true
                },
                
                new Course()  { 
                    Id = 3, 
                    Title = "Sıfırdan İleri Python Programlama", 
                    Description = "Python; web uygulamalari, yazilim geliştirme, veri bilimi ve makine öğreniminde (ML) yaygin olarak kullanilan bir programlama dilidir.", 
                    Version = "7.0.2", 
                    Image = "python.jpg",
                    Tags = new string[] {"python"},
                    isActive = true,
                    isHome = false
                },
                
                new Course()  { 
                    Id = 4, 
                    Title = "Java", 
                    Description = "Java çok platformlu, nesne odaklı ve ağ merkezli bir dil olup kendisi de bir platform olarak kullanılabilir.", 
                    Version = "8.5", 
                    Image = "java1.jpg",
                    isActive = true,
                    isHome = true
                }

            };
        }   

        public static List<Course> Courses

        {
            get {
                return _courses;
            }
        } 
        public static Course? GetById(int? id){
            return _courses.FirstOrDefault(c => c.Id==id);
        }
    }
}