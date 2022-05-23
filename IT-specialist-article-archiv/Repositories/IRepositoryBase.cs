using IT_specialist_article_archiv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_specialist_article_archiv.Repositories
{
    public interface IRepositoryBase<TId, TModel>
    {
        public bool Delete(TId id);
        public bool Delte(TModel obj);
        public ObservableCollection<Archiv> GetAll();
        public Archiv Get(TId id);
        public bool Save(TModel obj);
    }
}
