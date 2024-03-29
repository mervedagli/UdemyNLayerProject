﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if(product!=null)
            {
                await next();   //next metoduyla gelen requesti bir sonraki adıma aktarıyoruz.
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;
                errorDto.Errors.Add($"Id değeri {id} olan ürün veritabanında bulunamadı.");

                context.Result = new NotFoundObjectResult(errorDto);

            }
        }
    }
}
