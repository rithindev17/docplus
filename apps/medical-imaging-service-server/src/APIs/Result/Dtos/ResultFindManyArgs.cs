using MedicalImagingService.APIs.Common;
using MedicalImagingService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ResultFindManyArgs : FindManyInput<Result, ResultWhereInput> { }
