using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nesops.MySQLAuthorize.Models;
using Nesops.MySQLAuthorize.Services;
using Nesops.MySQLAuthorize.ViewModels;
using NesopsService.Base.Controller;
using NesopsService.Base.Model;
using NesopsService.Data;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;
using NesopsService.Models.RequestModels;

namespace MySQLAuthorize.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<NesopsAuthorizeContext, AspNetUsers, AspNetUsersReadModel, AspNetUsersCreateModel, AspNetUsersUpdateModel, UserRequestModel>
    {
        public readonly AuthorizeService _authorizeService;
        public UserController(NesopsAuthorizeContext dbContext, IMapper mapper, AuthorizeService authorizeService) : base(dbContext, mapper)
        {
            _authorizeService = authorizeService;
        }

        [HttpGet]
        //[Authorize(Roles = "NesopsAdministrator")]
        public async Task<ActionResult<GetResponseModel<AspNetUsersReadModel, RoleRequestModel>>> GetAll([FromQuery]UserRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModels = await ListModel(requestModel, cancellationToken);
            return Ok(readModels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetResponseModel<AspNetUsersReadModel, RoleRequestModel>>> GetOne(int id, [FromQuery]UserRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModel = await ReadModel(id, requestModel, cancellationToken);
            if (readModel == null)
                return NotFound(new BaseResponseModel<object> { message = "Not found", code = 404 });
            return Ok(readModel);
        }

        [HttpPost]
        public async Task<ActionResult<AspNetRolesReadModel>> Add([FromBody]AspNetUsersCreateModel createModel, CancellationToken cancellationToken)
        {
            var user = new NesopsUser
            {
                UserName = createModel.UserName
            };
            var userRoles = new List<string>()
            {
                "ActiveUser"
            };
            var result = await _authorizeService.CreateUserAsync(user, createModel.Password, userRoles);
            if (result.Succeeded)
                return Ok(new BaseResponseModel<object> { message = "Create User Successful", code = 200 });
            var responseModel = new BaseResponseModel<object> { message = "Create User Fail", code = 400 };
            foreach (var err in result.Errors)
                responseModel.SetError(err.Code, err.Description);
            return BadRequest(responseModel);
        }
    }
}