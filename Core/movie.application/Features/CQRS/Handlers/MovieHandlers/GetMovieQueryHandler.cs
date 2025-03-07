using Microsoft.EntityFrameworkCore;
using movie.application.Features.CQRS.Results.MovieResults;
using movie.persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace movie.application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task <List<GetMovieQueryResult>> Handle()
        {
            var values = await _context.Movies.ToListAsync();
            return values.Select(x => new GetMovieQueryResult
            {
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Rating = x.Rating,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status
            }).ToList();
        }
    }
}
