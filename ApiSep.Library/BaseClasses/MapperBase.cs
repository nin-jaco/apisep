using System;
using System.Linq.Expressions;

namespace ApiSep.Library.BaseClasses
{
    public abstract class MapperBase<TEntity, TDto>
    {
        public abstract Expression<Func<TEntity, TDto>> SelectorExpression { get; }

        public abstract void MapToModel(TDto dto, TEntity model);
    }
}