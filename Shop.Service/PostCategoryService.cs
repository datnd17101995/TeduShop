using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParenrId(int parentId);

        PostCategory GetById(int Id);
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParenrId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int Id)
        {
            return _postCategoryRepository.GetSingleById(Id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}