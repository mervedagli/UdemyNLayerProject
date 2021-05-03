using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }  //Categorye bağlı olacağından dolayı
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; }   //Categorye bağlı olacağından dolayı category sınıfına referans verdik. Virtualın sebebi entity framework bu kategori üzerinden inherit kullanarak tracking yapacak yani değişiklikleri izleyecek hafızasında tutabilecek. O yüzden virtual olarak belirtiyoruz.
    }
}
