using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        //// Marks an entity as new
        //void Add(T entity);

        //// Marks an entity as modified
        //void Update(T entity);

        //// Marks an entity to be removed
        //void Delete(T entity);

        //void Delete(int id);

        ////Delete multi records
        //void DeleteMulti(Expression<Func<T, bool>> where);

        //// Get an entity by int id
        //T GetSingleById(int id);

        //T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        //IQueryable<T> GetAll(string[] includes = null);

        //IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        //IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        //int Count(Expression<Func<T, bool>> where);

        //bool CheckContains(Expression<Func<T, bool>> predicate);
        
        //thêm một thực thể mới
        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int id);

        //func là 1 delegate lưu trữ các method anonymous
        //biểu thị một delegatemà là khá nhiều một con trỏ đến một phương thức 
        //và Expression<Func<T>>biểu thị một cấu trúc dữ liệu cây cho một biểu thức lambda
        //Expression<Func<T, bool>> where:hàm deletemulti nhận đầu vào là 1 biểu thức lamda where kiểu T là bool
        void DeleteMulti(Expression<Func<T, bool>> where);

        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expresstion, string[] include = null);

        IEnumerable<T> GetAll(string[] include = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] incllude = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}