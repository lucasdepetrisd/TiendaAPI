﻿using Domain.DTOs;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : BaseController<CreateColorDTO, ColorDTO>
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
            : base(colorService)
        {
            _colorService = colorService;
        }
    }
}
