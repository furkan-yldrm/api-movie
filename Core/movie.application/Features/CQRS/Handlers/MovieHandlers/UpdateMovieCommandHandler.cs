using movie.application.Features.CQRS.Commands.MovieCommands;
using movie.persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.application.Features.CQRS.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            value.CoverImageUrl = command.CoverImageUrl;
            value.Rating = command.Rating;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.Description = command.Description;
            value.ReleaseDate = command.ReleaseDate;
            value.CreatedYear = command.CreatedYear;
            value.Title = command.Title;
            await _context.SaveChangesAsync();
        }
    }
}
