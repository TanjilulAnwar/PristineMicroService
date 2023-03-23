﻿using MediatR;

namespace CatalogService.Application.Commands
{
    public class DeleteProductCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
