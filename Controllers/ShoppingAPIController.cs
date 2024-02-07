using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingAPIController : ControllerBase
    {
        private readonly DbHelper dbHelper;
        public ShoppingAPIController(EF_DataContext eF_DataContext) {
            dbHelper=new DbHelper(eF_DataContext);
        }

        // GET: api/<ShoppingAPIController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type= ResponseType.Success;
            try { 
                IEnumerable<ProductModel> data=dbHelper.GetProducts();

                if (!data.Any()) {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex) {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ShoppingAPIController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = dbHelper.GetProductsById(id);

                if (data==null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ShoppingAPIController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody]  OrderModel model)
        {
            try { 
                ResponseType type=ResponseType.Success;
                dbHelper.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type,model));

            } catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ShoppingAPIController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                dbHelper.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ShoppingAPIController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try {
                ResponseType type = ResponseType.Success;
                dbHelper.DeleteOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));
            }
            catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
