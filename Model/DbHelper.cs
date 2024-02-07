using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Model
{
    public class DbHelper
    {
        private EF_DataContext dataContext;

        public DbHelper(EF_DataContext context) {
        
        dataContext = context;

        }
        //GET
        public List<ProductModel> GetProducts() { 
        List<ProductModel> response = new List<ProductModel>();
           var productList = dataContext.Products.ToList();

            productList.ForEach(product => response.Add(new ProductModel()
            {
                Brand = product.Brand,
                Id = product.Id,
                Name = product.Name,
                Size = product.Size,  
                price=product.price
            }));
            return response;
        }

        public ProductModel GetProductsById(int Id)
        {
            ProductModel response = new ProductModel();

            var productModel = dataContext.Products.Where(d => d.Id.Equals(Id)).FirstOrDefault();
            return new ProductModel() {
                Brand = productModel.Brand,
                Id = productModel.Id,
                Name = productModel.Name,
                Size = productModel.Size,
                price=productModel.price
        };
        }
        public void SaveOrder(OrderModel orderModel) {
            
            Order dbTable=new Order();
            if (orderModel.Id > 0) {
                //PUT
                dbTable = dataContext.Orders.Where(d => d.Id.Equals(orderModel.Id)).FirstOrDefault();

                if (dbTable != null)
                {
                    dbTable.Phone = orderModel.Phone;
                    dbTable.Address = orderModel.Address;
                }
   
            }
            else
            {
                //POST
                dbTable.Phone = orderModel.Phone;
                dbTable.Name = orderModel.Name;
                dbTable.Address = orderModel.Address;
                dbTable.Product = dataContext.Products.Where(f => f.Id.Equals(orderModel.Product_Id)).FirstOrDefault();
                dataContext.Orders.Add(dbTable);
            }
            dataContext.SaveChanges();
            {


            }
        }
        //DELETE
        public void DeleteOrder(int Id) {

            var order = dataContext.Orders.Where(d => d.Id.Equals(Id)).FirstOrDefault();
            if (order!=null) {
                dataContext.Orders.Remove(order);
                dataContext.SaveChanges();
            }
        }
    }
}
