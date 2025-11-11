using AutoMapper;
using MediatR;
using MerchantApplication.Features.ManagementHierarchies.Dto;
using MerchantApplication.Features.ManagementHierarchies.Interface;
using MerchantApplication.Shared;
using MerchantCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.ManagementHierarchies.Commands.AddManagementHierarchy
{
    //public class AddManagementHierarchyHandler : IRequestHandler<AddManagementHierarchyCommand, ApiResponse<ManagementHierarchyDto>>
    //{
    //    private readonly IManagementHierarchy _repository;
    //    private readonly IMapper _mapper;
    //    private readonly ILogger<AddManagementHierarchyHandler> _logger;
    //    //private readonly IHttpContextAccessor _httpContext;

    //    public AddManagementHierarchyHandler(
    //        IManagementHierarchy repository,
    //        IMapper mapper,
    //        ILogger<AddManagementHierarchyHandler> logger,
    //        //IHttpContextAccessor httpContext)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //        _logger = logger;
    //        //_httpContext = httpContext;
    //    }

    //    public async Task<ApiResponse<ManagementHierarchy>> Handle(AddManagementHierarchyCommand request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            // Map command to entity
    //            var entity = _mapper.Map<ManagementHierarchy>(request);

    //            // Validate mandatory fields
    //            if (string.IsNullOrWhiteSpace(entity.POCEmail))
    //                return ApiResponse<ManagementHierarchy>.Fail("0", "POC Email is required.");

    //            if (string.IsNullOrWhiteSpace(entity.Name))
    //                return ApiResponse<ManagementHierarchy>.Fail("0", "Hierarchy Name is required.");

    //            if (string.IsNullOrWhiteSpace(entity.POCName))
    //                return ApiResponse<ManagementHierarchy>.Fail("0", "POC Name is required.");

    //            // Validate ParentID if provided
    //            if (entity.ParentID.HasValue && entity.ParentID.Value > 0)
    //            {
    //                var parent = await _repository.GetManagementByID(entity.ParentID.Value);
    //                if (parent == null)
    //                    return ApiResponse<ManagementHierarchy>.Fail("0", "ParentId does not exist.");
    //            }

    //            // Set defaults
    //            //entity.CreatedBy = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst("UserID")?.Value ?? Guid.Empty.ToString());
    //            //entity.Status = "Active";
    //            //entity.isDeleted = false;

    //            // Save to DB
    //            var addedEntity = await _repository.AddManagementAsync(entity);

    //            _logger.LogInformation("Management hierarchy added successfully. ID={Id}", addedEntity.ID);

    //            return ApiResponse<ManagementHierarchy>.Success(addedEntity);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Error while adding management hierarchy.");
    //            return ApiResponse<ManagementHierarchy>.Fail("0", "An error occurred while adding the management hierarchy.");
    //        }
    //    }
    //}
}
