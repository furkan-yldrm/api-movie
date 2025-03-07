﻿,using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.application.Features.CQRS.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {
        public GetMovieByIdQuery(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }
    }
}
