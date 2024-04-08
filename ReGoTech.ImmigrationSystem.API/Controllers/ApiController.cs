﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReGoTech.ImmigrationSystem.API.Controllers
{
	[Route("api/v1/[controller]" + "s")]
	[ApiController]
	[Authorize]

	public class ApiController : ControllerBase
	{
		public ApiController() { }
	}
}
