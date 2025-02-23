﻿using System.Text.RegularExpressions;
using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) => 
                         await dbContext.Genres
                             .Select(genre => genre.ToDto())
                             .AsNoTracking()
                             .ToListAsync());
        
        return group;
    }
}