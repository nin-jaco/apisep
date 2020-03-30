using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApiSep.Library.RequestObjects;

namespace ApiSep.Bl.Interfaces
{
    public interface ICrud<TDto, TModel>
    {
        TDto Create(TDto item, CrudRequest crudRequest);
        TDto Delete(TDto item, CrudRequest crudRequest);
        TDto Update(TDto item, CrudRequest crudRequest);
        IQueryable<TDto> GetAll();
        TDto GetById(int id);
        TDto SearchFirst(Expression<Func<TModel, bool>> predicate);
        List<TDto> SearchFor(Expression<Func<TModel, bool>> predicate);
        TModel MapDtoToModel(TDto dto);
        TDto MapModelToDto(TModel model);
    }
}
