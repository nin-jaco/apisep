using System.Linq;
using ApiSep.Library.BaseClasses;
using ApiSep.Library.RequestObjects;

namespace ApiSep.Bl.Interfaces
{
    public interface IRepository<TModel> where TModel : class, new()
    {
        TModel Add(CreateRequest<TModel> request);
        TModel Remove(DeleteRequest<TModel> request);
        TModel Update(UpdateRequest<TModel> request);
        IQueryable<TModel> GetAll(GetAllRequest request);
        TModel Get(GetByIdRequest<TModel> request);
        TModel SearchFirst(SearchFirstRequest<TModel> request);
        IQueryable<TModel> SearchFor(SearchForRequest<TModel> request);
        void SaveChanges(RequestBase requestBase);
    }
}
