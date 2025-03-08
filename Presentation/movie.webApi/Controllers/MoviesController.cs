using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using movie.application.Features.CQRS.Commands.MovieCommands;
using movie.application.Features.CQRS.Handlers.CategoryHandlers;
using movie.application.Features.CQRS.Handlers.MovieHandlers;
using movie.application.Features.CQRS.Queries.MovieQueries;

namespace movie.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieQueryHandler getMovieQueryHandler, 
            GetMovieByIdQueryHandler getMovieByIdQueryHandler, 
            CreateMovieCommandHandler createMovieCommandHandler, 
            UpdateMovieCommandHandler updateMovieCommandHandler, 
            RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Successful!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Successful!");
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Successful!");
        }   
    }
}
