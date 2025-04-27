using System;
using MediatR;

namespace RO.DevTest.Application.Features.Common
{
    public abstract class BaseQuery<TResponse> : IRequest<TResponse>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}