using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiSep.Bl.BaseClasses;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;
using ApiSep.Wcf.Contracts;

namespace ApiSep.Wcf.BaseClasses
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TDto : class, new() where TEntity : class, new()
    {
        public LogicBase<TDto, TEntity> LogicBase { get; set; } = new LogicBase<TDto, TEntity>();

        public virtual CreateResponse<TDto> Create(CreateRequest<TDto> request)
        {
            return LogicBase.Create(request);
        }

        public DeleteResponse<TDto> Delete(DeleteRequest<TDto> request)
        {
            return LogicBase.Delete(request);
        }

        public UpdateResponse<TDto> Update(UpdateRequest<TDto> request)
        {
            return LogicBase.Update(request);
        }

        public GetAllResponse<TDto> GetAll(GetAllRequest request)
        {
            return LogicBase.GetAll(request);
        }

        public GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request)
        {
            return LogicBase.GetById(request);
        }

        public SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TEntity> request)
        {
            return LogicBase.SearchFirst(request);
        }

        public SearchForResponse<TDto> SearchFor(SearchForRequest<TEntity> request)
        {
            return LogicBase.SearchFor(request);
        }

        public GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request)
        {
            return LogicBase.GetAllPaged(request);
        }

        public GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request)
        {
            return LogicBase.GetAllPagedAndFiltered(request);
        }
    }
}