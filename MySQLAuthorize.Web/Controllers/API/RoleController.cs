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
    public class RoleController : BaseEntityController<NesopsAuthorizeContext, AspNetRoles, AspNetRolesReadModel, AspNetRolesCreateModel, AspNetRolesUpdateModel, RoleRequestModel>
    {
        public readonly AuthorizeService _authorizeService;

        public RoleController(NesopsAuthorizeContext dbContext, IMapper mapper, AuthorizeService authorizeService) : base(dbContext, mapper)
        {
            _authorizeService = authorizeService;
        }

        [HttpGet]
        //[Authorize(Roles = "NesopsAdministrator")]
        public async Task<ActionResult<GetResponseModel<AspNetRolesReadModel, RoleRequestModel>>> GetAll([FromQuery]RoleRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModels = await ListModel(requestModel, cancellationToken);
            return Ok(readModels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetResponseModel<AspNetRolesReadModel, RoleRequestModel>>> GetOne(int id, [FromQuery]RoleRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModel = await ReadModel(id, requestModel, cancellationToken);
            if (readModel == null)
                return NotFound(new BaseResponseModel<object> { message = "Not found", code = 404 });
            return Ok(readModel);
        }

        [HttpPost]
        public async Task<ActionResult<AspNetRolesReadModel>> Add([FromBody]AspNetRolesCreateModel createModel, CancellationToken cancellationToken)
        {
            var nesopsRole = new NesopsRole()
            {
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Description = createModel.Description,
                DisplayName = createModel.DisplayName,
                Name = createModel.Name
            };
            var result = await _authorizeService.CreateRoleAsync(nesopsRole);
            if (result.Succeeded)
                return Ok(new BaseResponseModel<NesopsRole> { message = "Create Role Successful", data = nesopsRole, code = 200 });
            var responseModel = new BaseResponseModel<object> { message = "Create Role Fail", code = 400 };
            foreach (var err in result.Errors)
                responseModel.SetError(err.Code, err.Description);
            return BadRequest(responseModel);
        }
#if Debug
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<AspNetRolesReadModel>> Delete(long id, CancellationToken cancellationToken)
        {
            var readModel = await DeleteModel(id, cancellationToken);
            return Ok(new BaseResponseModel<object> { message = "Delete Successful", code = 404 });
        }
        [HttpPut]
        [Route("{id}")]
        //[Authorize(Roles = "Web Application")]
        public async Task<ActionResult<AspNetRolesReadModel>> Update(long id, CcCallUpdateModel updateModel, CancellationToken cancellationToken)
        {
            var readModel = await UpdateModel(id, updateModel, cancellationToken);
            return Ok(new BaseResponseModel<AspNetRolesReadModel> { message = "Update Successful", data = readModel, code = 404 });
        }
#endif
    }
}