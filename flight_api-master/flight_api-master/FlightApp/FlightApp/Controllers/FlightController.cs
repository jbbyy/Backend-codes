using FlightApp.Filter;
using FlightApp.Model;
using FlightApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FlightApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exception] 
    //using AOP to filter the exceptions
    public class FlightsController : ControllerBase
    {

        //dependency injection of IFlightService into FlightsController
        private readonly IFlightService service;

        public FlightsController(IFlightService service)
        {
            this.service = service;
        }   

        [HttpPost]
        public IActionResult Add(Flight flights)
        {
            service.AddFlight(flights);
            return Ok("Flight added successfully");
        }

        [HttpDelete("flight_number")]
        public IActionResult Delete(string flightnumber)
        {
            service.DeleteFlight(flightnumber);
            return Ok("Flight deleted successfully");
        }

        [HttpPut("flight_number")]
        public IActionResult Modify(Flight flight, string flightnumber)
        {
            service.ModifyFlight(flight, flightnumber);
            return Ok("Flight updated successfully");
        }

        [HttpGet("flight_number")]
        public IActionResult GetById(string flightnumber)
        {

            return Ok(service.GetFlightByNum(flightnumber));
        }

        [HttpGet("bydate/flight_date")]
        public IActionResult GetDate(DateTime date)
        {
            return Ok(service.GetFlightByDate(date));
        }

        [HttpGet("operational /flight_date")]
        public IActionResult GetCount(DateTime date)
        {
            return Ok(service.GetFlightCount(date));
        }

        [HttpGet]
        public IActionResult GetSD(string source, string destination)
        {
            return Ok(service.GetFlightSourceDest(source, destination));
        }
    }
}
