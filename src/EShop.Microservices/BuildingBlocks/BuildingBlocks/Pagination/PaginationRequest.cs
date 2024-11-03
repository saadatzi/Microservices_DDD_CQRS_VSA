// <fileheader>
//     <copyright file="PaginationRequest.cs" company="SSS">
//         Copyright (c) 2024 SSS. All rights reserved.
//     </copyright>
// </fileheader>
namespace BuildingBlocks.Pagination;

/// <summary>
/// Represents a request for paginated data, specifying the page index and the page size.
/// </summary>
public record PaginationRequest(int PageIndex = 0, int PageSize = 10);