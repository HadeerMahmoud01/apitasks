using apilab1.models;
using apilab1.filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apilab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static List<Cars> car = new List<Cars>()
        {   new(1,"toyta","good car",new (1999/2/5),"gas"),
            new(2,"marcedes","exp car",new(2001/5/4),"gas"),
            new(3, "pmw", "high car", new(1998 / 11 / 5), "gas"),

        };

        [HttpGet]
        public ActionResult<List<Cars>> getdata()
        {
            return car;
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cars> getbyid (int id)
        {
            Cars? newcar=car.FirstOrDefault(d=>d.Id==id);
            if (newcar == null)
            {
                return BadRequest();
            }
            return newcar;
        }


        //type=gas
        [HttpPost]
        [Route("api/Car/type1")]
        public ActionResult<Cars> gascar(Cars cars)
        {
            cars.Id = car.Count + 1;
            cars.type = "gas";
            car.Add(cars);
            return NoContent();
        }


        [HttpPost]
        [Route("api/Car/type2")]
        [Typefilter]
        public ActionResult<Cars> getcartypes(Cars cars)
        {
            cars.Id = car.Count + 1;
            car.Add(cars);
            return NoContent();
        }

        [HttpPost]

        public ActionResult addcar (Cars newcar)
        {
            newcar.Id = car.Count + 1;
            car.Add(newcar);
            return CreatedAtAction("getbyid",
                new { id = newcar.Id }
                );
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Cars> update(Cars newcar, int id)
        {
            if (id != newcar.Id)
            {
                return BadRequest();
            }
            Cars oldcar=car.FirstOrDefault(d=> d.Id==id);
            if(oldcar == null)
            {
                return BadRequest();
            }
            oldcar.Name = newcar.Name;
            oldcar.Description = newcar.Description;
            oldcar.productiondate = newcar.productiondate;
            oldcar.type=newcar.type;
          return NoContent();
        }







        [HttpDelete]
        [Route("{id}")]
      public ActionResult delete(int id)
        {
            var desiredcar=car.FirstOrDefault(d=>d.Id== id);
            if (desiredcar == null)
            {
                return BadRequest();
            }
            car.Remove(desiredcar);
            return NoContent();
        }

    }
}
