﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WebApiDemo.Models;
using WebApiDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }


        // GET: api/<BookController>
        [HttpGet]
        [Route("GetBooks")]

        public IActionResult Get()
        {
            try
            {
                var model = service.GetBooks();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetBookById(id);
                if (model == null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddBook")]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                int result = service.AddBook(book); ;
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                int result = service.UpdateBook(book);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }



        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteBook(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
